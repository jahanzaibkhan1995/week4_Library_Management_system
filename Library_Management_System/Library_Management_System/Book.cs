using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    class Book
    {
        public double ID {  get; set; }
        public string Title { get; set; }
        public string  Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
    }
}
