using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    class LibraryManager
    {
        public List<Book> books = new List<Book>();
        public List<Member> members = new List<Member>();
        public LibraryManager() 
        {
            add_initial_data_for_book();
            add_initial_data_for_member();
        }

        public void add_initial_data_for_book()
        {
            Book book1 = new Book();
            book1.ID = 1;
            book1.Title = "Clean Code";
            book1.Author = "Robert Martin";
            book1.IsAvailable = true;
            books.Add(book1);

            Book book2 = new Book();
            book2.ID = 2;
            book2.Title = "C# in Depth";
            book2.Author = "Jon Skeet";
            book2.IsAvailable = true;
            books.Add(book2);
        }
        public void add_initial_data_for_member()
        { 
            Member members1 = new Member();
            members1.Name = "Ali";
            members1.ID = 1;
            members.Add(members1);
            Borrow_Books(members1.ID, 1);
           

            Member members2 = new Member();
            members2.Name = "Hira";
            members2.ID = 2;
            members.Add(members2);
            Borrow_Books(members2.ID, 2);
           
        }
        public void Add_Book()
        {
            Book book= new Book();
            Console.Write($"Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            book.ID = id;
            Console.Write($"Enter Title:");
            string title = Console.ReadLine();
            book.Title = title;
            Console.Write($"Enter Author:");
            string author = Console.ReadLine();
            book.Author = author;
            Console.Write($"Enter ISBN:");
            string isbn = Convert.ToString(Console.ReadLine());
            book.ISBN = isbn;
            book.IsAvailable = true;
            books.Add(book);
        }
        public void Add_Member()
        {
            Member member = new Member();
            Console.Write($"Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            member.ID = id;
            Console.Write($"Enter Member Name:");
            string name = Convert.ToString(Console.ReadLine());
            member.Name = name;
            Console.Write($"Enter Borrowed Book");
            int book_id = Convert.ToInt16(Console.ReadLine());
            Borrow_Books(id, book_id);
            members.Add(member);
        }
        public void Show_Books()
        {
            foreach (Book book in books)
            {
                Console.WriteLine("======================");
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.ID);
                Console.WriteLine("======================");
            }
          
        }
        public void Show_Member()
        {
            foreach (Member member in members)
            {
                Console.WriteLine("======================");
                Console.WriteLine(member.Name);
                Console.WriteLine(member.ID);
//                Console.WriteLine(member.BorrowedBooks);
                foreach(Book book in member.BorrowedBooks)
                {
                    Console.WriteLine(book.Title);
                }
                Console.WriteLine("======================");

            }

        }
        public void Borrow_Books(int memberid, int bookid)
        {
            Member member = members.Find(m => m.ID == memberid);
            Book book = books.Find(b => b.ID == bookid);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine("Book is already borrowed.");
                return;
            }

            member.BorrowedBooks.Add(book);
            book.IsAvailable = false;

            Console.WriteLine("Book borrowed successfully.");
        }
        private void Return_Books()
        {

        }

    }
}
