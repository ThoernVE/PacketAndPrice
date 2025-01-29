using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    public class Package : Item
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public Package(float length, float weight, float width, float height) : base(length, weight)
        {
            Width = width;
            Height = height;
        }

        public override decimal CalculatePrice()
        {
            float longestSide = LongestSide(Length, Height, Width);
            float shortestSide = ShortestSide(Length, Height, Width);
            if (longestSide < 0.3F && Weight <= 2)
            {
                return 29;
            }
            else if (longestSide < 0.3F && Weight <= 10)
            {
                return 49;
            }
            else if (longestSide < 0.3F && Weight <= 20)
            {
                return 79;
            }

            decimal price = Convert.ToDecimal(longestSide * shortestSide * Weight);
            if (price <= 0)
            {
                Console.WriteLine("Price could not be generated");
                return 0;
            }

            return price + 100; //10000 is for öre?, made it 100 for kronor instead
        }

        public override float CalculateVolume()
        {
            float volume = Length * Width * Height;
            if(volume <= 0)
            {
                Console.WriteLine("There was an error setting the volume.");
                return 0;
            }
            return volume;
        }

        public float ShortestSide(float x, float y, float z)
        {
            if (x <= y && x <= z)
            {
                return x;
            }
            else if (y <= x && y <= z)
            {
                return y;
            }
            else if (z <= x && z <= y)
            {
                return z;
            }
            else
            {
                return 0;
            }
        }

        public float LongestSide(float x, float y, float z)
        {
            if (z <= x && y <= x)
            {
                return x;
            }
            else if (z <= y && x <= y)
            {
                return y;
            }
            else if (x <= z && y <= z)
            {
                return z;
            }
            else
            {
                return 0;
            }
        }

    }
}
