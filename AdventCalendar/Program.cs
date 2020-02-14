using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "";

            StreamReader file = new StreamReader(@"Input.txt");

            while ((line = file.ReadLine()) != null)
            {
                string[] range = line.Split('-');
                int passwordCount = 0;
                bool sequental = false;
                bool noDecrease = false;
                int previous = -1;

                for (int i = Convert.ToInt32(range[0]); i <= Convert.ToInt32(range[1]); i++)
                {
                    previous = -1;
                    sequental = false;
                    noDecrease = false;

                    foreach (var n in i.ToString())
                    {
                        // Check for same digits
                        if (previous == -1)
                            previous = Convert.ToInt32(n - '0');
                        else
                        {
                            if (Convert.ToInt32(n - '0') == previous)
                            {
                                sequental = true;
                                break;
                            }

                            previous = Convert.ToInt32(n - '0');
                        }
                    }
                    // *************************************** HAVE NOT STARTED THIS (PART 2) YET ****************************************
                    if (sequental)
                    {
                        previous = -1;

                        foreach (var n in i.ToString())
                        {
                            // Check the increase
                            if (previous == -1)
                                previous = Convert.ToInt32(n - '0');
                            else
                            {
                                if (Convert.ToInt32(n - '0') == previous || Convert.ToInt32(n - '0') > previous)
                                    noDecrease = true;
                                else
                                {
                                    noDecrease = false;
                                    break;
                                }

                                previous = Convert.ToInt32(n - '0');
                            }
                        }
                    }

                    if (sequental && noDecrease)
                        passwordCount++;
                }

                Console.WriteLine(passwordCount);
                Console.ReadLine();
            }
        }
    }
}
