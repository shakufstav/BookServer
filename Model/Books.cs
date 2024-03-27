using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Books: BaseEntity
    {
        private string bookName;
        private Writer writer;
        private Genre genre;

        
        public string BookName { get => bookName; set => bookName = value; }
        public Genre Genre { get => genre; set => genre = value; }
        public Writer Writer { get => writer; set => writer = value; }
    }
}