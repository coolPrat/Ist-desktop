using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST
{
    public class News
    {
        public List<Year> year { get; set; }
        public List<Quarter> quarter { get; set; }
        public List<Month> month { get; set; }
        public List<Older> older { get; set; }
    }
}
