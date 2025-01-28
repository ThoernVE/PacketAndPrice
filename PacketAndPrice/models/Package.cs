using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    internal class Package : Item
    {
        public int Width {  get; set; }
        public int Height { get; set; }

        public Package(int length, int weight, int width, int height)  : base(length, weight )
        {
            Width = width;
            Height = height;
        }

        public override int CalculatePrice()
        {
            int longestSide = LongestSide(Length, Height, Width);
            int shortestSide = ShortestSide(Length, Height, Width);

            return longestSide * shortestSide * Weight + 10000; //10000 is for öre?
        }

        public override int CalculateVolume()
        {
            return Length * Width * Height;
        }

        public int ShortestSide(int x, int y, int z)
        {
            if (x < y && x < z)
            {
                return x;
            }
            else if(y < x && y < z)
            {
                return y;
            }
            else if(z < x && z < y)
            {
                return z;
            }
            else
            {
                return 0;
            }
        }

        public int LongestSide(int x, int y, int z)
        {
            if(z < x && y < x)
            {
                return x;
            }
            else if (z < y && x < y)
            {
                return y;
            }
            else if(x < z && y < z)
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
