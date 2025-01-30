using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketAndPrice.models
{
    public class Package : Item
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Package(double length, double weight, double width, double height) : base(length, weight)
        {
            Width = width;
            Height = height;
        }

        public static bool CreatePackage(double length, double weight, double width, double height)
        {
            try
            {
                Package package = new Package(length, weight, width, height);
                if (package == null || length <= 0 || weight <= 0 || width <= 0 || height <= 0)
                {
                    Console.WriteLine("One or more values were not correct. Please try again");
                    return false;
                }

                package.Volume = package.CalculateVolume();
                package.Price = package.CalculatePrice();

                if (package.Volume <= 0 || package.Price <= 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override decimal CalculatePrice()
        {
            double longestSide = LongestSide(Length, Height, Width);
            double shortestSide = ShortestSide(Length, Height, Width);
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

        public override double CalculateVolume()
        {
            double volume = Length * Width * Height;
            if(volume <= 0)
            {
                Console.WriteLine("There was an error setting the volume.");
                return 0;
            }
            return volume;
        }

        public double ShortestSide(double x, double y, double z)
        {
            return Math.Min(x, Math.Min(y, z));
        }

        public double LongestSide(double x, double y, double z)
        {
            return Math.Max(z, Math.Max(x, y));
        }

    }
}
