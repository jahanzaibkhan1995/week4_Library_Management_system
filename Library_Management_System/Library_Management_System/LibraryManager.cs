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
            Implementation_Borrow_Books(members1.ID, 1);
           

            Member members2 = new Member();
            members2.Name = "Hira";
            members2.ID = 2;
            members.Add(members2);
            Implementation_Borrow_Books(members2.ID, 2);
           
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
            members.Add(member);
            Implementation_Borrow_Books(id, book_id);
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
        public void Implementation_Borrow_Books(int memberid, int bookid)
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
        public void Borrow_Books()
        {
            int bookid = 0;
            int memberid = 0;
            Console.Write("Please Enter Book Name you need to Borrow:");
            string _book = Console.ReadLine();
            Console.Write("Please Enter Name Memeber Whose Borrowes the book:");
            string _member = Console.ReadLine();
            foreach (Book book in books) { if (book.Title.ToLower().Contains(_book.ToLower())) { bookid = book.ID; } }
            foreach (Member member in members) { if (member.Name.ToLower().Contains(_member.ToLower())) { memberid = member.ID; } }
            Implementation_Borrow_Books(memberid, bookid);
        }
        public void Implementation_Return_Book(int memberid, int bookid)
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
        public void Return_Book()
        {
            int bookid = 0;
            int memberid = 0;
            Console.Write("Please Enter Name you need to return:");
            string _book = Console.ReadLine();
            Console.Write("Please Enter Name Memeber Whose Borrowed this book");
            string _member = Console.ReadLine();
            foreach (Book book in books) { if (book.Title.ToLower().Contains(_book.ToLower())) { bookid = book.ID; } }
            foreach (Member member in members) { if (member.Name.ToLower().Contains(_member.ToLower()) ) { memberid = member.ID; } }
            Implementation_Return_Book(memberid,bookid);
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
