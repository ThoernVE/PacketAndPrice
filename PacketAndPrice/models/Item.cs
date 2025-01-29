using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    public class Item
    {
        public float Length { get; set; }
        public float Weight { get; set; }
        public float Volume { get; set; }
        public decimal Price { get; set; }

        public static int MaxWeight = 20;

        public Item(float length, float weight)
        {
            Length = length;
            Weight = weight;
        }

        public virtual decimal CalculatePrice()
        {
            return Convert.ToDecimal(Length * Weight);
        }

        public virtual float CalculateVolume()
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
