using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plsdata
{
    public class food
    {
        public static List<food> prodlist = new List<food>();
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
    }
}
