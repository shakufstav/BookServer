using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BooksLibraryList:List<BooksLibrary>
    {
        public BooksLibraryList() { }
        public BooksLibraryList(IEnumerable<BooksLibrary> list) : base(list) { }
        public BooksLibraryList(IEnumerable<BaseEntity> list) : base(list.Cast<BooksLibrary>().ToList()) { }
    }
}
