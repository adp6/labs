using System;

namespace lab3
{
    class Program
    {
        private const string PRO_LICENSE = "111";
        private const string EXP_LICENSE = "222";

        static void Main(string[] args)
        {
            Console.WriteLine("Enter license key:");
            var license = Console.ReadLine();

            
            DocumentWorker worker;
            switch (license)
            {
                case PRO_LICENSE: worker = new ProDocumentWorker(); break;
                case EXP_LICENSE: worker = new ExpertDocumentWorker(); break;
                default: worker = new DocumentWorker(); break;
            }

            while (true)
            {
                Console.WriteLine("Enter Command (o/e/s/q): ");
                switch (Console.ReadLine())
                {
                    case "o": worker.OpenDocument(); break;
                    case "e": worker.EditDocument(); break;
                    case "s": worker.SaveDocument(); break;
                    case "q": return;
                }
            }
        }
    }

    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ відкритий");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("Правка документа доступна у версії Про");
        }

        public virtual void SaveDocument()
        {
            Console.WriteLine("Збереження документа доступне у версії Про");
        }
    }

    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ відредаговано");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Документ збережено у старому форматі, збереження в інших форматах доступне у версії Експерт");
        }
    }

    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ збережений в новому форматі");
        }
    }
}