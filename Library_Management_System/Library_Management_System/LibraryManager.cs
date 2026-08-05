using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    internal class LibraryManager
    {
        public List<Book> books = new List<Book>();
        public List<Member> members = new List<Member>();
        public LibraryManager() { }
        private void Add_Book()
        {
            Book books= new Book();
            Console.Write($"Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            books.ID = id;
            Console.Write($"Enter Title:");
            string title = Console.ReadLine();
            books.Title = title;
            Console.Write($"Enter Author:");
            string author = Console.ReadLine();
            books.Author = author;
            Console.Write($"Enter ISBN:");
            int isbn = Convert.ToInt32(Console.ReadLine());
            books.ISBN = isbn;
        }
        private void Add_Member()
        {
            Member member = new Member();
            Console.Write($"Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            member.ID = id;
            Console.Write($"Enter Member Name:");
            string name = Convert.ToString(Console.ReadLine());
            member.Name = name;
            Console.Write($"Enter Borrowed Book");
            string borrowedbooks = Console.ReadLine();
            member.BorrowedBooks = borrowedbooks;
        }
        private void Borrow_Books()
        {

        }
        private void Return_Books()
        {

        }

    }
}
