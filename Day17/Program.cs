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
            Console.WriteLine("File Exists? " + File.Exists(file) + "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
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

            // var breaktru = false;

            preRockS.y = 0;

            while (rockFallen < 10)
            {
                Console.WriteLine("Current Rock: " + curRock + " Rocks Fallen: " + rockFallen + " Counter: " + counter + " Height: " + height);
                var curRockS = new Rock(curRock);
                curRock++;

                if (curRock > 5) curRock = 1;
                if (rockFallen == 0) curRockS.y = botY + 4 + 1;
                if (rockFallen != 0) curRockS.y = botY + 4;

                for (int i = botY + 4; i > botY; i--)
                {
                    if (i - botY == 4) System.Console.WriteLine(" Spawn Y: " + curRockS.y);
                    if (line[jetSteamCounter] == '<')
                        curRockS.shiftLeft();

                    if (line[jetSteamCounter] == '>')
                        curRockS.shiftRight();
                    if (i - botY == 1)
                    {
                        if (curRockS.y == botY + 1 && rockFallen > 0)
                        {
                            System.Console.Write(" First Collision");
                            height += curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer);
                            botY += curRockS.hasCollided(curRockS, preRockS, yHitsPerLayer);
                            yHitsPerLayer.Add(botY, curRockS.topXHits);
                            System.Console.WriteLine(" Layer Height Added: " + (botY) + " Layer Height: " + botY + " Rock Height: " + curRockS.Height + " Hits: " + curRockS.topXHits);
                            Console.Write("  Stopped? " + height + " JetSteamCounter: " + line[jetSteamCounter] + " I: " + i);
                        }
                        else if (rockFallen == 0)
                        {

                            if (i - 1 == botY)
                            {
                                botY += curRockS.Height;
                                height += curRockS.Height;
                                preRockS.y += curRockS.Height;
                                System.Console.Write(" 0 Rock collision");
                            }
                        }
                        else System.Console.Write("       No Collision");
                    }
                    curRockS.y--;
                    Console.Write("             I: " + i + " Current Y: " + curRockS.y + " boty: " + botY + " prevY: " + preRockS.y + " Height: " + height + " Cur x Max: " + curRockS.xMax + " Cur x Min: " + curRockS.xMin + " Current Shape" + curRockS.rockShapeNum + " Line: " + line[jetSteamCounter]);
                    System.Console.WriteLine();
                    jetSteamCounter++;
                    if (jetSteamCounter > line.Length - 1) jetSteamCounter = 0;
                    counter++;
                }

                preRockS = curRockS;

                // botY += curRockS.Height;


                rockFallen++;

            }
            Console.WriteLine(" Rocks Fallen: " + rockFallen + " Height: " + height);


        }

        class Rock
        {
            public int xMin;
            public int xMax;
            public int[] topXHits = new int[] { };
            public int[] midXHits = new int[] { };
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
            public int hasCollided(Rock currentRock, Rock previousRock, Dictionary<int, int[]> yHitsPerLayer)
            {
                if (currentRock == null || previousRock == null)
                {
                    Console.WriteLine("Error: Rock is null! Current: " + currentRock + " Previous: " + previousRock);
                    return 0;
                }
                var sameLayerHit = true;

                if (currentRock.rockShapeNum != 2 && previousRock.rockShapeNum != 2)
                {
                    foreach (var item in currentRock.botXHits)
                    {
                        foreach (var top in previousRock.topXHits)
                        {
                            if (item == top)
                            {
                                Console.WriteLine("Bot hit r2 {0}", item);
                                return currentRock.Height;
                            }
                        }
                    }
                    sameLayerHit = false;

                }

                else if (currentRock.rockShapeNum == 2)
                {
                    foreach (var item in currentRock.botXHits)
                    {
                        if (previousRock.topXHits.Contains(item))
                        {
                            Console.WriteLine("Bot hit c2 {0}", item);
                            return currentRock.Height;
                        }
                    }

                    foreach (var item in currentRock.midXHits)
                    {
                        if (previousRock.topXHits.Contains(item))
                        {
                            Console.WriteLine("Mid hit c2 {0}", item);
                            return currentRock.Height - 1;
                        }
                    }
                    sameLayerHit = false;
                }

                else if (previousRock.rockShapeNum == 2)
                {
                    foreach (var item in previousRock.topXHits)
                    {
                        if (currentRock.botXHits.Contains(item))
                        {
                            Console.WriteLine("Bot hit p2 {0}", item);
                            return currentRock.Height;
                        }
                    }

                    foreach (var item in previousRock.midXHits)
                    {
                        if (currentRock.botXHits.Contains(item))
                        {
                            Console.WriteLine("Mid hit p2  {0}", item);
                            return currentRock.Height - 1;
                        }
                    }
                    sameLayerHit = false;
                }
                else
                {
                    Console.WriteLine("Error: Rock shape not found! (Collision)");
                    return 0;
                }

                while (!sameLayerHit)
                {
                    var hitsCurrent = yHitsPerLayer[currentRock.y - 1];
                    foreach (var item in currentRock.botXHits)
                    {
                        if (hitsCurrent.Contains(item))
                        {
                            Console.WriteLine("Bot hit Special {0}", item);
                            return currentRock.Height;
                        }
                    }

                    foreach (var item in hitsCurrent)
                    {
                        System.Console.WriteLine(item);

                    }
                    System.Console.WriteLine(" Hits Current" + hitsCurrent.Length);
                    foreach (var item in currentRock.botXHits)
                    {
                        System.Console.WriteLine(item);
                    }
                    System.Console.WriteLine(" Bot X Hits" + currentRock.botXHits.Length);

                    while (true) { }

                }

                Console.WriteLine("No hit");
                return 0;



            }


        }

    }
}
