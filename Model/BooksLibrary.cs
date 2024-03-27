using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BooksLibrary:BaseEntity
    {
        private User userId;
        private Books bookId;
        private DateTime addDate;
        private Category bookCategory;
        public User UserId { get => userId; set => userId = value; }
        public Books BookId { get => bookId; set => bookId = value; }
        public DateTime AddDate { get => addDate; set => addDate = value; }
        public Category BookCategory { get => bookCategory; set => bookCategory = value; }
    }
}
