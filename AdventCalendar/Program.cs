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

            foreach (var module in modules)
            {
                decimal moduleFuel = 0;

                decimal division = Convert.ToInt32(module) / 3;
                moduleFuel = Math.Floor(division) - 2;

                totalFuel += moduleFuel;
            }

            Console.WriteLine(totalFuel);
            Console.ReadLine();
        }
    }
}
