using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReviewList:List<Review>
    {
        public ReviewList() { }
        public ReviewList(IEnumerable<Review> list) : base(list) { }

        public ReviewList(IEnumerable<BaseEntity> list) : base(list.Cast<Review>().ToList()) { }
    }
}
