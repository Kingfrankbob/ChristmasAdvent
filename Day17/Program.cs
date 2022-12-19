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
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var line = File.ReadAllText(file);
            var rockFallen = 0L;
            var counter = 0;
            var jetSteamCounter = 0;
            var curX = 0;
            var curY = 0;
            var botX = 0;
            var botY = 0;
            var curRock = 0;
            var maxX = 6;
            var minX = 0;
            var preRockS = new Rock(0);

            char[,] rockTwo = new char[3, 3] {  { '.', '#', '.'},
                                                  { '#', '#', '#'},
                                                  { '.', '#', '.'} };

            var breaktru = false;

            while (rockFallen < 2022)
            {
                var curRockS = new Rock(curRock);
                curRock++;

                if (curRock < 5) curRock = 1;

                for (int i = botY; i < botY + 3; i++)
                {
                    if (line[jetSteamCounter] == '<')
                        curRockS.shiftLeft();

                    if (line[jetSteamCounter] == '>')
                        curRockS.shiftRight();

                    if (curRockS.shape != rockTwo && preRockS.shape != rockTwo)
                    {
                        foreach (var item in curRockS.botXHits)
                        {
                            foreach (var top in preRockS.topXHits)
                            {
                                if (item == top)
                                {
                                    breaktru = true;
                                    break;
                                }
                            }
                            if (breaktru) break;
                        }

                    }
                    jetSteamCounter++;
                    if (jetSteamCounter > line.Length) jetSteamCounter = 0;
                    counter++;
                }
                preRockS = curRockS;

                botY += curRockS.Height;


                rockFallen++;

            }

        }

        class Rock
        {
            public int xMin;
            public int xMax;
            public int[] topXHits = new int[] { };
            public int[] midXHits = new int[] { };
            public int[] botXHits = new int[] { };
            public int y;
            public int prevY;
            public int width;
            public int height;

            public char[,]? shape;

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
                        botXHits = new int[] { 0 };
                        xMax = 2;
                        xMin = 2;
                        break;
                    case 5:
                        shape = rockFive;
                        topXHits = new int[] { 0, 1 };
                        botXHits = new int[] { 0, 1 };
                        xMax = 3;
                        xMin = 2;
                        break;
                    default: Console.WriteLine("Error: Rock shape not found! (Current)"); break;
                }

            }
            public void shiftLeft()
            {
                if (xMin >= 0)
                {
                    xMin--;
                    var counter = 0;
                    foreach (var val in topXHits)
                    {
                        topXHits[counter] = val - 1;
                    }

                    foreach (var val in topXHits)
                    {
                        topXHits[counter] = val - 1;
                    }

                }
            }
            public void shiftRight()
            {
                if (xMin <= 6)
                {
                    xMax++;
                    var counter = 0;
                    foreach (var val in topXHits)
                    {
                        topXHits[counter] = val + 1;
                    }
                    foreach (var val in topXHits)
                    {
                        topXHits[counter] = val + 1;
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

        }

    }
}
