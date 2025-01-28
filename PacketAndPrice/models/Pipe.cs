using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    internal class Pipe : Item
    {
        public int Diameter {  get; set; }
        public int Circumference { get; set; }

        public Pipe(int length, int weight, int diameter, int circumference) : base(length, weight)
        {
            Diameter = diameter;
            Circumference = circumference;
        }
    }
}
