using System;
using System.IO;

namespace AdventCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile = "Input.txt";

            string[] modules = File.ReadAllLines(textFile);
            decimal totalFuel = 0;
            decimal totalFuelOfFuel = 0;

            foreach (var module in modules)
            {
                decimal moduleFuel = 0;
                decimal y = 0;

                decimal division = Convert.ToInt32(module) / 3;
                moduleFuel = Math.Floor(division) - 2;

                totalFuel += moduleFuel;

                y = totalFuel;

                while (totalFuel > 0)
                {
                    decimal x = (Math.Floor(totalFuel / 3)) - 2;

                    if (x < 0)
                        x = 0;

                    totalFuelOfFuel += x;
                    totalFuel = x;
                }

                totalFuelOfFuel += y;
            }

            Console.WriteLine(totalFuelOfFuel);
            Console.ReadLine();
        }
    }
}
