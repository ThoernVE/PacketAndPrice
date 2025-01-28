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

        public override int CalculateVolume()
        {
            return Convert.ToInt32(Math.PI) * ((Diameter / 2) * (Diameter / 2)) * Length; //Think about using different measurements than int. Math.PI is normally double, maybe go with doubles?
        }

        public override int CalculatePrice()
        {
            if(Weight < 2)
            {
                return Circumference * Length * 2;
            }
            else
            {
                return Circumference * Length * Weight;
            }
        }
    }
}
