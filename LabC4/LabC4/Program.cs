using System;
using System.Collections.Generic;
using System.Threading;

namespace LabC4
{
    public class EventData
    {
        public string Message { get; set; }
    }

    public delegate void EventHandler(object sender, EventData eventData);

    public class EventBus
    {
        private readonly Dictionary<string, List<EventHandler>> _eventHandlers;
        private readonly Dictionary<string, Timer> _eventTimers;

        public EventBus()
        {
            _eventHandlers = new Dictionary<string, List<EventHandler>>();
            _eventTimers = new Dictionary<string, Timer>();
        }

        public void RegisterHandler(string eventName, EventHandler eventHandler)
        {
            if (!_eventHandlers.TryGetValue(eventName, out var handlers))
            {
                handlers = new List<EventHandler>();
                _eventHandlers[eventName] = handlers;
            }

            handlers.Add(eventHandler);
        }

        public void UnregisterHandler(string eventName, EventHandler eventHandler)
        {
            if (_eventHandlers.TryGetValue(eventName, out var handlers))
            {
                handlers.Remove(eventHandler);
            }
        }

        public void RaiseEvent(string eventName, EventData eventData, int throttleMilliseconds)
        {
            if (_eventHandlers.TryGetValue(eventName, out var handlers))
            {
                if (_eventTimers.TryGetValue(eventName, out var timer))
                {
                    timer.Dispose();
                }

                var throttledEventHandler = new EventHandler((sender, args) =>
                {
                    foreach (var handler in handlers)
                    {
                        handler(sender, args);
                    }
                });

                timer = new Timer(state =>
                {
                    throttledEventHandler.Invoke(this, eventData);
                }, null, throttleMilliseconds, Timeout.Infinite);

                _eventTimers[eventName] = timer;
            }
        }
    }

    public class PriorityEventBus
    {
        private readonly Dictionary<int, List<Delegate>> _subscriptions;

        public PriorityEventBus()
        {
            _subscriptions = new Dictionary<int, List<Delegate>>();
        }

        public void Subscribe(int priority, Delegate handler)
        {
            if (!_subscriptions.ContainsKey(priority))
            {
                _subscriptions[priority] = new List<Delegate>();
            }

            _subscriptions[priority].Add(handler);
        }

        public void Unsubscribe(int priority, Delegate handler)
        {
            if (_subscriptions.ContainsKey(priority))
            {
                _subscriptions[priority].Remove(handler);

                if (_subscriptions[priority].Count == 0)
                {
                    _subscriptions.Remove(priority);
                }
            }
        }

        public void Publish(int priority, EventData eventData)
        {
            if (_subscriptions.ContainsKey(priority))
            {
                foreach (var handler in _subscriptions[priority])
                {
                    handler.DynamicInvoke(eventData);
                }
            }
        }
    }

    public class LowPrioritySubscriber
    {
        public void HandleEvent(EventData eventData)
        {
            Console.WriteLine($"Low priority event handled: {eventData.Message}");
        }
    }

    public class HighPrioritySubscriber
    {
        public void HandleEvent(EventData eventData)
        {
            Console.WriteLine($"High priority event handled: {eventData.Message}");
        }
    }

    public class EventPublisher
    {
        public event Action<int> PriorityEvent;

        private readonly Random _random = new Random();

        public void PublishEvent(int priority)
        {
            PriorityEvent?.Invoke(priority);
        }

        public void SubscribeToEvent(Action<int> eventHandler)
        {
            PriorityEvent += eventHandler;
        }

        public void UnsubscribeFromEvent(Action<int> eventHandler)
        {
            PriorityEvent -= eventHandler;
        }

        public void PublishEventWithRetry(int priority, Func<int, int> retryPolicy)
        {
            Action<int> handler = null;
            handler = new Action<int>((p) =>
            {
                try
                {
                    PublishEvent(p);
                }
                catch
                {
                    int retries = retryPolicy(p);
                    int delay = GetRandomDelay(retries);
                    Thread.Sleep(delay);
                    handler(p);
                }
            });

            handler(priority);
        }

        private int GetRandomDelay(int retries)
        {
            int baseDelay = 1000;
            int maxDelay = 10000;
            int delay = (int)Math.Min(baseDelay * Math.Pow(2, retries), maxDelay);

            double jitter = _random.NextDouble() * delay / 2;
            delay = (int)(delay + jitter);

            return delay;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var eventData = new EventData { Message = "Test message" };

            var eventBus = new EventBus();

            var eventHandler1 = new EventHandler((sender, EventData) =>
            {
                Console.WriteLine($"Event handler 1 received message: {EventData.Message}");
            });

            var eventHandler2 = new EventHandler((sender, EventData) =>
            {
                Console.WriteLine($"Event handler 2 received message: {EventData.Message}");
            });

            eventBus.RegisterHandler("test_event", eventHandler1);
            eventBus.RegisterHandler("test_event", eventHandler2);


            eventBus.RaiseEvent("test_event", eventData, 500);

            Thread.Sleep(1000);

            eventBus.RaiseEvent("test_event", eventData, 1000);

            Console.ReadLine();
        }
    }
}
