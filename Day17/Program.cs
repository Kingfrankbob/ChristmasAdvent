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

    }
}
