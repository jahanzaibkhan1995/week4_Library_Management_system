using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    internal class Book
    {
        public int ID {  get; set; }
        public string Title { get; set; }
        public string  Author { get; set; }
        public double ISBN { get; set; }
        public bool IsAvailable { get; set; }
    }
}
