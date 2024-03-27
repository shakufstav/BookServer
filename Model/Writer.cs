using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Writer: BaseEntity
    {
        private string writerName;
        public override string ToString()
        {
            return writerName;
        }
        public string WriterName { get => writerName; set => writerName = value; }
    }
}
