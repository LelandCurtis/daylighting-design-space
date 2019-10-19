using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaylightingDesignSpace
{
    public class Gene
    {
        public string location;
        public double orient;

        public Gene(string loc, double orient)
        {
            this.location = loc;
            this.orient = orient;
        }

        public override string ToString()
        {
            return this.location + this.orient.ToString();
        }
    }
}
