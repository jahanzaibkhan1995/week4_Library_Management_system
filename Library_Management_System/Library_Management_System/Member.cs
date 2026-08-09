using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    class Member
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public Member()
        {
            BorrowedBooks = new List<Book>();
        }
    }
}
