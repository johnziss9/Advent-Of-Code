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
            int lineCount = 0;
            string line = "";
            string[] directionsSplit = null;
            int cable1Horizontal = 0;
            int cable1Vertical = 0;
            List<string> positions = new List<string>(); // Records each position of the first cable after every move
            List<string> intersections = new List<string>(); // Stores all the intersections cable 2 hits on
            List<int> totals = new List<int>(); // Stores the total of the vertical and horizontal distance from 0 for each intersection

            StreamReader file = new StreamReader(@"Input.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (lineCount == 0)
                {
                    directionsSplit = line.Split(',');

                    foreach (var direction in directionsSplit)
                    {
                        // Left no is horizontal and right is vertical

                        switch (direction[0])
                        {
                            case 'R':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                    positions.Add(cable1Horizontal + i + ":" + cable1Vertical);
                                cable1Horizontal += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'U':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                    positions.Add(cable1Horizontal + ":" + (cable1Vertical + i));
                                cable1Vertical += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'L':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                    positions.Add((cable1Horizontal - i) + ":" + cable1Vertical);
                                cable1Horizontal -= Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'D':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                    positions.Add(cable1Horizontal + ":" + (cable1Vertical - i));
                                cable1Vertical -= Convert.ToInt32(direction.Substring(1));
                                break;
                            default:
                                break;
                        }
                    }

                    // Increase line count to calculate second cable
                    lineCount++;
                }
                else
                {
                    cable1Horizontal = 0;
                    cable1Vertical = 0;

                    directionsSplit = line.Split(',');

                    foreach (var direction in directionsSplit)
                    {
                        // Left no is horizontal and right is vertical

                        switch (direction[0])
                        {
                            case 'R':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    if (positions.Contains((cable1Horizontal + i) + ":" + cable1Vertical))
                                        intersections.Add((cable1Horizontal + i) + ":" + cable1Vertical);
                                }
                                cable1Horizontal += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'U':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    if (positions.Contains(cable1Horizontal + ":" + (cable1Vertical + i)))
                                        intersections.Add(cable1Horizontal + ":" + (cable1Vertical + i));
                                }
                                cable1Vertical += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'L':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    if (positions.Contains((cable1Horizontal - i) + ":" + cable1Vertical))
                                        intersections.Add((cable1Horizontal - i) + ":" + cable1Vertical);
                                }
                                cable1Horizontal -= Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'D':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    if (positions.Contains(cable1Horizontal + ":" + (cable1Vertical - i)))
                                        intersections.Add(cable1Horizontal + ":" + (cable1Vertical - i));
                                }
                                cable1Vertical -= Convert.ToInt32(direction.Substring(1));
                                break;
                            default:
                                break;
                        }
                    }

                    // Add together the intersections to get total distance
                    foreach (var intersection in intersections)
                    {
                        string[] items = intersection.Split(":");
                        var result = Convert.ToInt32(items[0]) + Convert.ToInt32(items[1]);

                        // Distance needs to be above 0
                        if (result > 0)
                            totals.Add(result);
                    }

                    // Get lowest distance
                    int lowestDistance = totals.Min();
                    Console.WriteLine(lowestDistance);

                    Console.ReadLine();
                }
            }
        }
    }
}
