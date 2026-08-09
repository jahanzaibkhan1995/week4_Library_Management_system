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
            while(!IsContinue)
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
                    IsContinue = true;
                    break;
                case (int)Meun_Item.add_book:
                    Console.WriteLine("ADD Book");
                    library_manager.Add_Book();
                    break;
                case (int)Meun_Item.show_books:
                    Console.WriteLine("Show Books");
                    library_manager.Show_Books();
                    break;
                case (int)Meun_Item.add_member:
                    Console.WriteLine("Add Member");
                    library_manager.Add_Member();
                    break;
                case (int)Meun_Item.show_members:
                    Console.WriteLine("Show Members");
                    library_manager.Show_Member();
                    break;
                case (int)Meun_Item.borrow_book:
                    Console.WriteLine("Borrow Book");
                    break;
                case (int)Meun_Item.return_book:
                    Console.WriteLine("Return Book");
                    break;
                case (int)Meun_Item.show_borrowed_books:
                    Console.WriteLine("Show Borrowed Books");
                    break;
                case (int)Meun_Item.save_Data:
                    Console.WriteLine("Save Data");
                    break;
                case (int)Meun_Item.load_data:
                    Console.WriteLine("Laod Data");
                    break;
            }
        }

    }

}