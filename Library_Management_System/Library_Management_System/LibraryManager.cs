using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Library_Management_System
{
    class LibraryManager
    {
        public List<Book> books = new List<Book>();
        public List<Member> members = new List<Member>();
        public FileManager filemanager; 
        public LibraryManager() 
        {
            filemanager = new FileManager();
           // add_initial_data_for_book();
            //add_initial_data_for_member();
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
        public void Add_Book(int id, string title, string author, string isbn)
        {
            Book book= new Book();
            book.ID = id;
            book.Title = title;
            book.Author = author;
            book.ISBN = isbn;
            book.IsAvailable = true;
            books.Add(book);
        }
        public void Add_Member(int id, string name, int book_id)
        {
            Member member = new Member();
            member.ID = id;
            member.Name = name;
            members.Add(member);
            Borrow_Books(id, book_id);
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

        public void Return_Book(int memberid, int bookid)
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
            Book borrowedBook = member.BorrowedBooks.Find(b => b.ID == bookid);

            if (borrowedBook == null)
            {
                Console.WriteLine("This member has not borrowed this book.");
                return;
            }

            member.BorrowedBooks.Remove(borrowedBook);

            book.IsAvailable = true;

            Console.WriteLine("Book returned successfully.");


        }
        public void Show_Borrowed_Books()
        { 
            foreach (Member member in members)
            {
                Console.WriteLine("==========================");
                Console.WriteLine($"Member ID: {member.ID}");
                Console.WriteLine($"Member Name: {member.Name}");

                Console.WriteLine("Borrowed Books:");

                if (member.BorrowedBooks.Count == 0)
                {
                    Console.WriteLine("No books borrowed.");
                }
                else
                {
                    foreach (Book book in member.BorrowedBooks)
                    {
                        Console.WriteLine($"Book ID: {book.ID}");
                        Console.WriteLine($"Title: {book.Title}");
                        Console.WriteLine($"Author: {book.Author}");
                        Console.WriteLine("--------------------------");
                    }
                }

                Console.WriteLine("==========================");
            }
        }
        public void Save_Data()
        {
            filemanager.SaveBooks(books);
            filemanager.SaveMembers(members);
        }
        public void Load_Data()
        {
            books = filemanager.LoadBooks();
            members = filemanager.LoadMembers();
        }

    }
}
