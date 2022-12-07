using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace lab3_2
{
    internal class Book
    {
        private string book = "";
        public void SetBook(string book)
        {
            this.book = book;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Book:{book}");
        }
    }
    internal class Title
    {
        private string title = "";
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Book:{title}");
        }
    }
     internal class Author
    {
        private string author = "";
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Author:{author}");
        }
    }
     internal class Content
    {
        private string content = "";
        public void SetContent(string content)
        {
            this.content = content;
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Book:{content}");
        }
    }
     internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            Title title = new Title();
            Author author = new Author();
            Content content = new Content();

            Console.Write("Book:");
            book.SetBook(Console.ReadLine());
            Console.Write("Title:");
            title.SetTitle(Console.ReadLine());
            Console.Write("Author:");
            author.SetAuthor(Console.ReadLine());
            Console.Write("Content:");
            content.SetContent(Console.ReadLine());
            Console.WriteLine("");

            book.Show();
            title.Show();
            author.Show();
            content.Show();
        }
    }
}