using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Review:BaseEntity
    {
        private User userId;
        private Books bookId;
        private int star;

        public User UserId { get => userId; set => userId = value; }
        public Books BookId { get => bookId; set => bookId = value; }
        public int Star { get => star; set => star = value; }

    }
}
