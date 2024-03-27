using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MovieBooks:Books
    {
        private string trailer;

        public string Trailer { get => trailer; set => trailer = value; }
    }
}
