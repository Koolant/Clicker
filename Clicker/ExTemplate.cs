using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    public class ExTemplate
    {
        public string name { get; set; }
        public string interval1 { get; set; }
        public string interval2 { get; set; }
        public string positionx { get; set; }
        public string positiony { get; set; }

        public ExTemplate()
        {

        }
        public ExTemplate (string name, string ival1, string ival2, string x, string y)
        {
            this.name = name;
            this.interval1 = ival1;
            this.interval2 = ival2;
            this.positionx = x;
            this.positiony = y;
        }
    }
}
