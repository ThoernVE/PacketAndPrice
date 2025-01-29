using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    public class Item
    {
        public double Length { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public decimal Price { get; set; }

        public static int MaxWeight = 20;

        public Item(double length, double weight)
        {
            Length = length;
            Weight = weight;
        }

        public virtual decimal CalculatePrice()
        {
            return Convert.ToDecimal(Length * Weight);
        }

        public virtual double CalculateVolume()
        {
            return Length;
        }

        public bool CheckWeight()
        {
            if (Weight > MaxWeight)
            {
                return false;
            }
            return true;
        }
    }
}
