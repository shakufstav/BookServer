using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comments:BaseEntity
    {
        private User userId;
        private Books bookId;
        private string comment;

        public User UserId { get => userId; set => userId = value; }
        public Books BookId { get => bookId; set => bookId = value; }
        public string Comment { get => comment; set => comment = value; }

    }
}
