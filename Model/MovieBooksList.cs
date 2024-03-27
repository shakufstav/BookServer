using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieBooksList:List<MovieBooks>
    {
        public MovieBooksList() { }
        public MovieBooksList(IEnumerable<MovieBooks> list) : base(list) { }

        public MovieBooksList(IEnumerable<BaseEntity> list) : base(list.Cast<MovieBooks>().ToList()) { }
    }
}
