using Library_Management_System;
using System;

namespace Libray_Management_system
{ 
    class Program
    {
        enum Meun_Item
        {
            exit=0,
            add_book,
            show_books,
            add_member,
            show_members,
            borrow_book,
            return_book,
            show_borrowed_books,
            save_Data,
            load_data,
            
        }
        static LibraryManager library_manager;
        static bool IsContinue = false;
        static void Main()
        {
            library_manager = new LibraryManager();
            library_manager.Load_Data();
            while (!IsContinue)
            {
                Show_Menu_Item();
                Selection_of_Menuitem();
            }
        }

        static void Show_Menu_Item()
        {
            Console.WriteLine("========== LIBRARY MANAGEMENT SYSTEM ==========");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Show Books");
            Console.WriteLine("3. Add Member");
            Console.WriteLine("4. Show Members");
            Console.WriteLine("5. Borrow Books");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. Show Borrow Books");
            Console.WriteLine("8. Save Data");
            Console.WriteLine("9. Load Data");
            Console.WriteLine("0. Exit");
        }
        static void Selection_of_Menuitem()
        {
            
            
            Console.Write("Enter Choice:");
            int choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                case (int)Meun_Item.exit:
                    Console.WriteLine("Exit");
                    library_manager.Save_Data();
                    IsContinue = true;
                    break;
                case (int)Meun_Item.add_book:
                    _Add_Book();
                    break;
                case (int)Meun_Item.show_books:
                    Console.WriteLine("Show Books");
                    library_manager.Show_Books();
                    break;
                case (int)Meun_Item.add_member:
                    _Add_Member();
                    break;
                case (int)Meun_Item.show_members:
                    Console.WriteLine("Show Members");
                    library_manager.Show_Member();
                    break;
                case (int)Meun_Item.borrow_book:
                    Console.WriteLine("Borrow Book");
                    _Borrowed_Book();
                    break;
                case (int)Meun_Item.return_book:
                    Console.WriteLine("Return Book");
                    _Return_Book();
                    break;
                case (int)Meun_Item.show_borrowed_books:
                    Console.WriteLine("Show Borrowed Books");
                    library_manager.Show_Borrowed_Books();
                    break;
                case (int)Meun_Item.save_Data:
                    Console.WriteLine("Save Data");
                    library_manager.Save_Data();
                    break;
                case (int)Meun_Item.load_data:
                    Console.WriteLine("Laod Data");
                    library_manager.Load_Data();
                    break;
            }
        }
        public static void _Add_Book()
        {
            Console.WriteLine("ADD Book");
            Console.Write($"Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter Title:");
            string title = Console.ReadLine();
            Console.Write($"Enter Author:");
            string author = Console.ReadLine();
            Console.Write($"Enter ISBN:");
            string isbn = Convert.ToString(Console.ReadLine());
            library_manager.Add_Book(id, title, author, isbn);
            Console.WriteLine($"'{title}' book Succesfully Add in Library ");
        }
        public static void _Add_Member()
        {
            Console.WriteLine("Add Member");
            Console.Write($"Enter ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter Member Name:");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write($"Enter Borrowed Book");
            int book_id = Convert.ToInt16(Console.ReadLine());
            library_manager.Add_Member(id, name, book_id);
            Console.WriteLine($"'{name}' Member succefully Add with borrow Book id '{book_id}'");
        }
        public static void _Return_Book()
        {
            Console.Write("Please Enter Name you need to return:");
            int bookid = Convert.ToInt16(Console.ReadLine());
            Console.Write("Please Enter Name Memeber Whose Borrowed this book");
            int memberid = Convert.ToInt16(Console.ReadLine());
            library_manager.Return_Book(memberid, bookid);
            Console.Write($"Book '{bookid}' successfully return from the given member '{memberid}'");
        }
        public static void _Borrowed_Book()
        {
            Console.Write("Please Enter Book Name you need to Borrow:");
            int bookid = Convert.ToInt16(Console.ReadLine());
            Console.Write("Please Enter Name Memeber Whose Borrowes the book:");
            int memberid = Convert.ToInt16(Console.ReadLine());
            library_manager.Borrow_Books(memberid, bookid);
            Console.Write($"Book '{bookid}' successfully return from the given member '{memberid}'");

        }
    }

}