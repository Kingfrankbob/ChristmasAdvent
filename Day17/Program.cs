using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day17
{
    class rockFaller
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++) Console.WriteLine('\n');
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file) + @"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ~~~~~~~~~~~~~~~~~
            ~~~~~~~~~~~~~~~~~");
            var line = File.ReadAllText(file);
            var rockFallen = 0L;
            var counter = 0;
            var jetSteamCounter = 0;
            var botY = 0;
            var curRock = 1;

            Rock preRockS = new Rock(0);
            var height = 0L;
            var yHitsPerLayer = new Dictionary<int, int[]>();

            char[,] rockTwo = new char[3, 3] {  { '.', '#', '.'},
                                                  { '#', '#', '#'},
                                                  { '.', '#', '.'} };

            yHitsPerLayer.Add(0, new int[] { 0, 1, 2, 3, 4, 5, 6 });

            preRockS.y = 0;

            while (rockFallen < 6)
            {
                Console.WriteLine("Current Rock:" + curRock + " Rocks Fallen:->" + rockFallen + "<---Counter: " + counter + " Height: " + height + " RRRRRRRRRRRRRRRRRRRRRRRRRR");
                var curRockS = new Rock(curRock);
                curRock++;

                if (curRock > 5) curRock = 1;
                if (rockFallen == 0) curRockS.y = botY + 4;
                if (rockFallen != 0) curRockS.y = botY + 4;

                while (!(yHitsPerLayer.ContainsKey(curRockS.y - 1)))
                {
                    Console.Write(" Current Y: " + curRockS.y + " boty: " + botY + " Height: " + height + " Cur x Max: " + curRockS.xMax + " Cur x Min: " + curRockS.xMin + " Line: " + line[jetSteamCounter] + " jetCounter: " + jetSteamCounter);
                    if (line[jetSteamCounter] == '<') { curRockS.shiftLeft(); Console.WriteLine(" Left Shift "); }
                    if (line[jetSteamCounter] == '>') { curRockS.shiftRight(); Console.WriteLine(" Right Shift "); }
                    jetSteamCounter++;
                    if (jetSteamCounter > line.Length - 1) jetSteamCounter = 0;
                    curRockS.y--;
                    // Console.WriteLine(" Current Y after shift and drop " + curRockS.y + " boty: " + botY);

                }
                Console.WriteLine(" Current Y After Falling: " + curRockS.y + " boty: " + botY + " prevY: " + preRockS.y + " Height: " + height + " Cur x Max: " + curRockS.xMax + " Cur x Min: " + curRockS.xMin + " Current Shape" + curRockS.rockShapeNum + " Line: " + line[jetSteamCounter] + " jetCounter: " + jetSteamCounter);
                jetSteamCounter++;
                if (curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer, botY) == 2147483647)
                {
                    while (curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer, botY) == 2147483647)
                    {
                        Console.Write(" Current Y Past: " + curRockS.y + " boty: " + botY + " prevY: " + preRockS.y + " Height: " + height + " Cur x Max: " + curRockS.xMax + " Cur x Min: " + curRockS.xMin + " Current Shape" + curRockS.rockShapeNum + " Line: " + line[jetSteamCounter]);
                        if (line[jetSteamCounter] == '<') { curRockS.shiftLeft(); Console.WriteLine(" Left Shift "); }
                        if (line[jetSteamCounter] == '>') { curRockS.shiftRight(); Console.WriteLine(" Right Shift "); }
                        jetSteamCounter++;
                        if (jetSteamCounter > line.Length - 1) jetSteamCounter = 0;
                        curRockS.y--;
                    }
                    height += curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer, botY);
                    botY += curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer, botY);
                    yHitsPerLayer = Rock.addRockHits(curRockS, yHitsPerLayer, botY);
                }
                else
                {
                    height += curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer, botY);
                    botY += curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer, botY);
                    yHitsPerLayer = Rock.addRockHits(curRockS, yHitsPerLayer, botY);
                }



                preRockS = curRockS;
                rockFallen++;

                // for (int i = botY + 4; i > botY; i--)
                // {
                //     if (i - botY == 4) System.Console.WriteLine(" Spawn Y: " + curRockS.y);

                //     if (i - botY == 1)
                //     {
                //         if (curRockS.y == botY + 1 && rockFallen > 0)
                //         {
                //             height += curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer, botY);
                //             botY += curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer, botY);
                //             yHitsPerLayer = Rock.addRockHits(curRockS, yHitsPerLayer, botY);
                //             // Console.Write("  Stopped? " + height + " JetSteamCounter: " + line[jetSteamCounter] + " I: " + i);
                //         }
                //         else if (rockFallen == 0)
                //         {

                //             if (i - 1 == botY)
                //             {
                //                 botY += curRockS.Height;
                //                 height += curRockS.Height;
                //                 preRockS.y += curRockS.Height;
                //                 // System.Console.Write(" 0 Rock collision");
                //             }
                //         }
                //         else System.Console.Write("       No Collision");
                //     }
                //     curRockS.y--;
                //     System.Console.WriteLine();
                //     jetSteamCounter++;
                //     if (jetSteamCounter > line.Length - 1) jetSteamCounter = 0;
                //     counter++;
                // }


            }
            Console.WriteLine(" Rocks Fallen: " + rockFallen + " Height: " + height);


        }

        class Rock
        {
            public int xMin;
            public int xMax;
            public int[] topXHits = new int[] { };
            public int[]? midXHits = new int[] { };
            public int[] botXHits = new int[] { };
            public int y;
            // public int prevY;
            // public int width;
            // public int height;
            public static char[,] rockTwo = new char[3, 3] {  { '.', '#', '.'},
                                                  { '#', '#', '#'},
                                                  { '.', '#', '.'} };
            public char[,]? shape;
            public int rockShapeNum;

            public Rock(int curRock)
            {
                char[,] rockOne = new char[1, 4] { { '#', '#', '#', '#' } };
                char[,] rockTwo = new char[3, 3] {  { '.', '#', '.'},
                                                  { '#', '#', '#'},
                                                  { '.', '#', '.'} };

                char[,] rockThree = new char[3, 3] {  { '.', '.', '#'},
                                                  { '.', '.', '#'},
                                                  { '#', '#', '#'} };



                char[,] rockFour = new char[4, 1] { {'#'},
                                               {'#'},
                                               {'#'},
                                               {'#'} };

                char[,] rockFive = new char[2, 2]  { {'#', '#'},
                                             { '#', '#'} };

                switch (curRock)
                {
                    case 1:
                        shape = rockOne;
                        topXHits = new int[] { 0, 1, 2, 3 };
                        midXHits = null;
                        botXHits = new int[] { 0, 1, 2, 3 };
                        xMax = 5;
                        xMin = 2;
                        break;
                    case 2:
                        shape = rockTwo;
                        topXHits = new int[] { 1 };
                        midXHits = new int[] { 0, 1, 2 };
                        botXHits = new int[] { 1 };
                        xMax = 4;
                        xMin = 2;
                        break;
                    case 3:
                        shape = rockThree;
                        topXHits = new int[] { 2 };
                        midXHits = new int[] { 2 };
                        botXHits = new int[] { 0, 1, 2 };
                        xMax = 4;
                        xMin = 2;
                        break;
                    case 4:
                        shape = rockFour;
                        topXHits = new int[] { 0 };
                        midXHits = null;
                        botXHits = new int[] { 0 };
                        xMax = 2;
                        xMin = 2;
                        break;
                    case 5:
                        shape = rockFive;
                        topXHits = new int[] { 0, 1 };
                        botXHits = new int[] { 0, 1 };
                        midXHits = null;
                        xMax = 3;
                        xMin = 2;
                        break;
                    default: Console.WriteLine("Error: Rock shape not found! (Current)"); break;

                }
                rockShapeNum = curRock;

            }
            public void shiftLeft()
            {
                if (xMin > 0)
                {
                    xMin--;
                    xMax--;
                    var counter = 0;
                    foreach (var val in topXHits)
                    {
                        topXHits[counter] = val - 1;
                        counter++;

                    }
                    counter = 0;
                    foreach (var val in botXHits)
                    {
                        botXHits[counter] = val - 1;
                        counter++;

                    }
                    counter = 0;
                    if (!(midXHits is null))
                        foreach (var val in midXHits)
                        {
                            midXHits[counter] = val - 1;
                            counter++;

                        }

                }
            }
            public void shiftRight()
            {
                if (xMax < 6)
                {
                    xMax++;
                    xMin++;
                    var counter = 0;
                    foreach (var val in topXHits)
                    {
                        topXHits[counter] = val + 1;
                        counter++;
                    }
                    counter = 0;
                    foreach (var val in botXHits)
                    {
                        botXHits[counter] = val + 1;
                        counter++;
                    }
                    counter = 0;
                    if (!(midXHits is null))
                        foreach (var val in midXHits)
                        {
                            midXHits[counter] = val + 1;
                            counter++;
                        }
                }
            }
            public int Width
            {

                get
                {
                    if (shape != null)
                        return shape.GetLength(1);
                    else
                        return 0;
                }
            }
            public int Height
            {
                get
                {
                    if (shape != null)
                        return shape.GetLength(0);
                    else
                        return 0;
                }
            }
            public int hasCollided(Rock currentRock, Rock previousRock, Dictionary<int, int[]> yHitsPerLayer, int botY)
            {
                if (currentRock == null || previousRock == null)
                {
                    Console.WriteLine("Error: Rock is null! Current: " + currentRock + " Previous: " + previousRock);
                    return 0;
                }

                var hitsCurrent = yHitsPerLayer[currentRock.y - 1];
                // Console.WriteLine("Y: " + currentRock.y);

                foreach (var item in currentRock.botXHits)
                {
                    if (hitsCurrent.Contains(item))
                    {
                        // System.Console.WriteLine("Collision on bottom end {0} RockBottom at: {1} and boty: {2} with the height being {3}", currentRock.y, currentRock.y, botY, currentRock.Height);
                        // Console.Write("Collision on bottom end {0}", currentRock.y);
                        if (currentRock.y < botY)
                        {
                            return currentRock.y + currentRock.Height - 1 - botY;
                        }
                        return currentRock.Height;

                    }
                }

                // Console.WriteLine("No hit");
                return 2147483647;



            }

            public static Dictionary<int, int[]> addRockHits(Rock currentRock, Dictionary<int, int[]> yHitsPerLayer, int botY)
            {
                if (currentRock == null)
                {
                    Console.WriteLine("Error: Rock is null! Current: " + currentRock);
                    return yHitsPerLayer;
                }
                try
                {
                    if (currentRock.midXHits == null)
                    {
                        yHitsPerLayer.Add(botY, currentRock.topXHits);
                        yHitsPerLayer.Add(botY - 1, currentRock.botXHits);
                    }
                    else
                    {
                        yHitsPerLayer.Add(botY, currentRock.topXHits);
                        yHitsPerLayer.Add(botY - 1, currentRock.midXHits);
                        yHitsPerLayer.Add(botY - 2, currentRock.botXHits);
                    }
                }
                catch (Exception)
                {
                    var prev = yHitsPerLayer[botY];
                    yHitsPerLayer.Remove(botY);
                    List<int> newHits = new List<int>(currentRock.topXHits);
                    newHits.AddRange(prev);
                    yHitsPerLayer.Add(botY, newHits.ToArray());
                }

                return yHitsPerLayer;
            }


        }

    }
}
