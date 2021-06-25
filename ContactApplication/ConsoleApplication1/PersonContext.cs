using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PersonContext : DbContext
    {
        public DbSet<People> People { get; set; }
    }
}
