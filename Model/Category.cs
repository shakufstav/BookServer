using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category:BaseEntity
    {
        private string bookCategory;

        public string BookCategory { get => bookCategory; set => bookCategory = value; }
    }
}
