using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WriterList:List<Writer>
    {
        public WriterList() { }
        public WriterList(IEnumerable<Writer> list) : base(list) { }

        public WriterList(IEnumerable<BaseEntity> list) : base(list.Cast<Writer>().ToList()) { }
    }
}
