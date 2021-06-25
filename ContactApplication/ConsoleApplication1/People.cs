using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class People
    {
        [Key]
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
    }
}
