using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    public class Pipe : Item
    {
        public double Diameter {  get; set; }
        public double Circumference { get; set; }

        public Pipe(double length, double weight, double diameter) : base(length, weight)
        {
            Diameter = diameter;
            Circumference = Convert.ToDouble(Math.PI * Diameter);
        }

        public override double CalculateVolume()
        {
            return Convert.ToDouble(Math.PI) * ((Diameter / 2) * (Diameter / 2)) * Length; //Think about using different measurements than int. Math.PI is normally double, maybe go with doubles?
        }

        public override decimal CalculatePrice()
        {
            if(Weight < 2)
            {
                return Convert.ToDecimal(Circumference * Length * 2);
            }
            else
            {
                return Convert.ToDecimal(Circumference * Length * Weight);
            }
        }
    }
}
