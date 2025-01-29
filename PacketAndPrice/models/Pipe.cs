using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    internal class Pipe : Item
    {
        public float Diameter {  get; set; }
        public float Circumference { get; set; }

        public Pipe(float length, float weight, float diameter, float circumference) : base(length, weight)
        {
            Diameter = diameter;
            Circumference = circumference;
        }

        public override float CalculateVolume()
        {
            return Convert.ToInt32(Math.PI) * ((Diameter / 2) * (Diameter / 2)) * Length; //Think about using different measurements than int. Math.PI is normally double, maybe go with doubles?
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
