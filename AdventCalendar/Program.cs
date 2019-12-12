using System;
using System.Collections.Generic;
using System.IO;

namespace AdventCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            StreamReader file = new StreamReader(@"Input.txt");
            List<int> opcodes = new List<int>();
            List<int> opcodesInitial = new List<int>();
            bool halt = false;
            int currentPosition = 0;
            int firstNumPosition = 0;
            int secondNumPosition = 0;
            int thirdNumPosition = 0;

            string[] codes = null;

            while ((line = file.ReadLine()) != null)
            {
                codes = line.Split(',');

                foreach (var code in codes)
                {
                    opcodes.Add(Convert.ToInt32(code));
                    opcodesInitial.Add(Convert.ToInt32(code));
                }
            }

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    // Clearing list and refilling it with original values
                    opcodes.Clear();

                    foreach (var code in codes)
                    {
                        opcodes.Add(Convert.ToInt32(code));
                    }

                    halt = false;

                    opcodes[1] = i;
                    opcodes[2] = j;

                    while (halt == false && currentPosition < opcodes.Count)
                    {
                        switch (opcodes[currentPosition])
                        {
                            case 1:
                                firstNumPosition = opcodes[currentPosition + 1];
                                secondNumPosition = opcodes[currentPosition + 2];
                                thirdNumPosition = opcodes[currentPosition + 3];
                                opcodes[thirdNumPosition] = opcodes[firstNumPosition] + opcodes[secondNumPosition];
                                currentPosition += 4;
                                break;
                            case 2:
                                firstNumPosition = opcodes[currentPosition + 1];
                                secondNumPosition = opcodes[currentPosition + 2];
                                thirdNumPosition = opcodes[currentPosition + 3];
                                opcodes[thirdNumPosition] = opcodes[firstNumPosition] * opcodes[secondNumPosition];
                                currentPosition += 4;
                                break;
                            case 99:
                                if (opcodes[0] == 19690720)
                                    Console.WriteLine(100 * i + j);
                                halt = true;
                                currentPosition = 0;
                                break;
                            default:
                                currentPosition++;
                                break;
                        }
                    }
                }
            }
        }
    }
}
