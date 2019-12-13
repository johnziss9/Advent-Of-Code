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
            string line;
            StreamReader file = new StreamReader(@"Input.txt");
            List<string> positions = new List<string>();
            List<string> intersections = new List<string>();
            List<string> totals = new List<string>();
            int currentHorPosition = 0;
            int currentVerPosition = 0;

            int lineCounter = 0;

            string[] directionsSplit = null;

            // Read first line
            while ((line = file.ReadLine()) != null)
            {
                directionsSplit = line.Split(',');

                if (lineCounter == 0)
                {
                    foreach (var direction in directionsSplit)
                    {
                        // Left no is horizontal and right is vertical

                        switch (direction[0])
                        {
                            case 'R':
                                for(int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                    positions.Add((currentHorPosition + i) + ":" + currentVerPosition);
                                currentHorPosition += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'U':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                    positions.Add(currentHorPosition + ":" + (currentVerPosition + i));
                                currentVerPosition += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'L':
                                for (int i = Convert.ToInt32(direction.Substring(1)); i > 0; i--)
                                    positions.Add((currentHorPosition - 1) + ":" + currentVerPosition);
                                currentHorPosition -= Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'D':
                                for (int i = Convert.ToInt32(direction.Substring(1)); i > 0; i--)
                                    positions.Add(currentHorPosition + ":" + (currentVerPosition - i));
                                currentVerPosition += Convert.ToInt32(direction.Substring(1));
                                break;
                            default:
                                break;
                        }
                    }

                    lineCounter++;
                }
                else
                {
                    currentHorPosition = 0;
                    currentVerPosition = 0;

                    foreach (var direction in directionsSplit)
                    {
                        switch (direction[0])
                        {
                            case 'R':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    currentHorPosition += i;
                                    if (positions.Contains(i + ":" + currentVerPosition))
                                        intersections.Add(i + ":" + currentVerPosition);
                                }
                                break;
                            case 'U':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    currentHorPosition += i;
                                    if (positions.Contains(currentHorPosition + ":" + i))
                                        intersections.Add(currentHorPosition + ":" + i);
                                }
                                break;
                            case 'L':
                                for (int i = Convert.ToInt32(direction.Substring(1)); i > 0; i--)
                                {
                                    currentHorPosition -= i;
                                    if (positions.Contains(i + ":" + currentVerPosition))
                                        intersections.Add(i + ":" + currentVerPosition);
                                }
                                break;
                            case 'D':
                                for (int i = Convert.ToInt32(direction.Substring(1)); i > 0; i--)
                                {
                                    currentHorPosition -= i;
                                    if (positions.Contains(currentHorPosition + ":" + i))
                                        intersections.Add(currentHorPosition + ":" + i);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }

                foreach (var intersection in intersections)
                {
                    string[] items = intersection.Split(":");
                    totals.Add(items[0] + items[1]);
                }
            }
        }
    }
}
