using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    public class Item
    {
        public int Length { get; set; }
        public int Weight { get; set; }
        public int Volume { get; set; }
        public int Price { get; set; }

        public static int MaxWeight = 20;

        public Item(int length, int weight)
        {
            Length = length;
            Weight = weight;
        }

        public virtual int CalculatePrice()
        {
            return Length * Weight;
        }

        public virtual int CalculateVolume()
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
