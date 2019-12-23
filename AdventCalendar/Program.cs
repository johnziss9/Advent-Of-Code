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
            int cable1StepCount = 0;
            int cable2StepCount = 0;
            List<string> positions = new List<string>(); // Records each position of the first cable after every move
            List<string> intersections = new List<string>(); // Stores all the intersections cable 2 hits on cable plus adds the numbers of moves both cable took to get there
            List<int> totalSteps = new List<int>(); // Stores total amount of steps taken for each intersection for both cables (taken from 'intersections' list)
            List<int> cable1Steps = new List<int>(); // Stores the step count after each move cable 1 makes

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
                                {
                                    cable1StepCount++;
                                    positions.Add(cable1Horizontal + i + ":" + cable1Vertical);
                                    cable1Steps.Add(cable1StepCount);
                                }                                    
                                cable1Horizontal += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'U':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    cable1StepCount++;
                                    positions.Add(cable1Horizontal + ":" + (cable1Vertical + i));
                                    cable1Steps.Add(cable1StepCount);
                                }                                    
                                cable1Vertical += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'L':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    cable1StepCount++;
                                    positions.Add((cable1Horizontal - i) + ":" + cable1Vertical);
                                    cable1Steps.Add(cable1StepCount);
                                }
                                cable1Horizontal -= Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'D':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    cable1StepCount++;
                                    positions.Add(cable1Horizontal + ":" + (cable1Vertical - i));
                                    cable1Steps.Add(cable1StepCount);
                                }
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
                                    cable2StepCount++;

                                    if (positions.Contains((cable1Horizontal + i) + ":" + cable1Vertical))
                                    {
                                        var cable1Index = positions.IndexOf((cable1Horizontal + i) + ":" + cable1Vertical);
                                        intersections.Add((cable1Horizontal + i) + ":" + cable1Vertical + ":" + (cable2StepCount + Convert.ToInt32(cable1Steps[cable1Index])));
                                    }
                                        
                                }
                                cable1Horizontal += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'U':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    cable2StepCount++;

                                    if (positions.Contains(cable1Horizontal + ":" + (cable1Vertical + i)))
                                    {
                                        var cable1Index = positions.IndexOf(cable1Horizontal + ":" + (cable1Vertical + i));
                                        intersections.Add(cable1Horizontal + ":" + (cable1Vertical + i) + ":" + (cable2StepCount + Convert.ToInt32(cable1Steps[cable1Index])));
                                    }                                        
                                }
                                cable1Vertical += Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'L':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    cable2StepCount++;

                                    if (positions.Contains((cable1Horizontal - i) + ":" + cable1Vertical))
                                    {
                                        var cable1Index = positions.IndexOf((cable1Horizontal - i) + ":" + cable1Vertical);
                                        intersections.Add((cable1Horizontal - i) + ":" + cable1Vertical + ":" + (cable2StepCount + Convert.ToInt32(cable1Steps[cable1Index])));
                                    }                                        
                                }
                                cable1Horizontal -= Convert.ToInt32(direction.Substring(1));
                                break;
                            case 'D':
                                for (int i = 1; i <= Convert.ToInt32(direction.Substring(1)); i++)
                                {
                                    cable2StepCount++;

                                    if (positions.Contains(cable1Horizontal + ":" + (cable1Vertical - i)))
                                    {
                                        var cable1Index = positions.IndexOf(cable1Horizontal + ":" + (cable1Vertical - i));
                                        intersections.Add(cable1Horizontal + ":" + (cable1Vertical - i) + ":" + (cable2StepCount + Convert.ToInt32(cable1Steps[cable1Index])));
                                    }                                        
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
                        // if (result > 0)
                            totalSteps.Add(Convert.ToInt32(items[2]));
                    }

                    // Get lowest step count
                    int lowstStepCount = totalSteps.Min();
                    Console.WriteLine(lowstStepCount);

                    Console.ReadLine();
                }
            }
        }
    }
}
