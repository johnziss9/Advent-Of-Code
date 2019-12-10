﻿using System;
using System.Collections.Generic;
using System.IO;

namespace AdventCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            StreamReader file = new StreamReader(@"C:/Users/zissimouj/Desktop/ad.txt");
            List<int> opcodes = new List<int>();
            int currentPosition = 0;
            int firstNumPosition = 0;
            int secondNumPosition = 0;
            int thirdNumPosition = 0;

            while ((line = file.ReadLine()) != null)
            {
                string[] codes = line.Split(',');

                foreach (var code in codes)
                    opcodes.Add(Convert.ToInt32(code));
            }

            opcodes[1] = 12;
            opcodes[2] = 2;

            while (currentPosition < opcodes.Count)
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
                        Console.WriteLine(opcodes[0]);
                        Console.ReadLine();
                        break;
                    default:
                        currentPosition++;
                        break;
                }
            }
        }
    }
}
