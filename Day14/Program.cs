// using System.Text;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace Day14
{

    /*
    SO MUCH THANKS TO BARD WILSON FOR THE HELP WITH THIS ONE!
    Or at least the reference! I was able to figure out the rest on my own!
    I had the mapping close with Github Copilot, the link to brads repo is here:
    https://github.com/bradwilson/advent-2022/blob/main/Day14/Program.cs
    */
    class sandDumper
    {

        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = (from line in File.ReadAllLines("Input.txt") where !string.IsNullOrWhiteSpace(line) select line.Split(" -> ").Select(x => x.Split(",").Select(int.Parse).ToArray()).ToArray()).ToArray();
            // int counter = 0;

            var curPnt = (0, 0);

            int minx = 999, miny = 999, maxx = 0, maxy = 0;

            foreach (var coords in lines)
            {
                foreach (var coord in coords)
                {
                    if (coord[0] < minx) minx = coord[0];
                    if (coord[1] < miny) miny = coord[1];
                    if (coord[0] > maxx) maxx = coord[0];
                    if (coord[1] > maxy) maxy = coord[1];
                }

            }

            System.Console.WriteLine("minx: " + minx + " miny: " + miny + " maxx: " + maxx + " maxy: " + maxy);


            var caveMap = new Occupant[maxx - minx + 1, maxy + 1];

            var maxy2 = maxy + 2;
            var minx2 = Math.Min(minx, 500 - maxy2);
            var maxx2 = Math.Max(maxx, 500 + maxy2);
            var caveMapP2 = new Occupant[maxx2 - minx2 + 1, maxy2 + 1];


            foreach (var coords in lines)
            {
                curPnt = (coords[0][0], coords[0][1]);
                caveMap[curPnt.Item1 - minx, curPnt.Item2] = Occupant.Rock;
                caveMapP2[curPnt.Item1 - minx2, curPnt.Item2] = Occupant.Rock;

                for (int i = 0; i < coords.Length; i++)
                {
                    var nextPnt = (coords[i][0], coords[i][1]);

                    var dirX = Math.Min(1, Math.Max(-1, nextPnt.Item1 - curPnt.Item1));
                    var dirY = Math.Min(1, Math.Max(-1, nextPnt.Item2 - curPnt.Item2));

                    while (curPnt != nextPnt)
                    {
                        curPnt.Item1 += dirX;
                        curPnt.Item2 += dirY;
                        caveMap[curPnt.Item1 - minx, curPnt.Item2] = Occupant.Rock;
                        caveMapP2[curPnt.Item1 - minx2, curPnt.Item2] = Occupant.Rock;
                    }
                    curPnt = nextPnt;
                }


            }

            for (var x = minx2; x <= maxx2; ++x)
                caveMapP2[x - minx2, maxy2] = Occupant.Rock;



            long FillCave(Occupant[,] cave, int minX, int maxX, int maxY)
            {
                var result = 0L;
                bool finished = false;

                while (!finished)
                {
                    var currentSand = (500, 0);

                    while (true)
                    {
                        if (cave[currentSand.Item1 - minX, currentSand.Item2] == Occupant.Sand)
                        {
                            finished = true;
                            break;
                        }
                        if (currentSand.Item2 >= maxY)
                        {
                            finished = true;
                            break;
                        }
                        if (cave[currentSand.Item1 - minX, currentSand.Item2 + 1] == Occupant.Empty)
                            currentSand.Item2++;
                        else
                        {
                            if (currentSand.Item1 <= minX)
                            {
                                finished = true;
                                break;
                            }
                            if (cave[currentSand.Item1 - minX - 1, currentSand.Item2 + 1] == Occupant.Empty)
                            {
                                currentSand.Item2++;
                                currentSand.Item1--;
                            }
                            else
                            {
                                if (currentSand.Item1 >= maxX)
                                {
                                    finished = true;
                                    break;
                                }

                                if (cave[currentSand.Item1 - minX + 1, currentSand.Item2 + 1] == Occupant.Empty)
                                {
                                    currentSand.Item2++;
                                    currentSand.Item1++;
                                }
                                else
                                    break;
                            }
                        }
                    }

                    if (!finished)
                    {
                        cave[currentSand.Item1 - minX, currentSand.Item2] = Occupant.Sand;
                        result++;
                    }
                }

                return result;
            }

            // System.Console.WriteLine("minx: " + minx + " miny: " + miny + " maxx: " + maxx + " maxy: " + maxy);
            System.Console.WriteLine("Result: " + FillCave(caveMap, minx, maxx, maxy) + " Result2: " + FillCave(caveMapP2, minx2, maxx2, maxy2));


        }
    }
}

enum Occupant { Empty = 0, Rock, Sand };

