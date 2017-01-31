using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IST
{
    public class People
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public List<Faculty> faculty { get; set; }
        public List<Staff> staff { get; set; }
    }
}
