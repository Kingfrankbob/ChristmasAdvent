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
            var curX = 0;
            var curY = 0;
            var botX = 0;
            var botY = 0;
            var curRock = 0;

            char[,] rockOne = new char[1, 4] { '#', '#', '#', '#' };
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

            char[,] rockFive = new char[2]  { {'#', '#'},
                                             { '#', '#'} };



            while (rockFallen < 2022)
            {
                var curRockShape;
                var prevRockShape;
                curRock++;
                if (curRock < 5) curRock = 1;
                switch (curRock)
                {
                    case 1: curRockShape = rockOne; break;
                    case 2: curRockShape = rockTwo; break;
                    case 3: curRockShape = rockThree; break;
                    case 4: curRockShape = rockFour; break;
                    case 5: curRockShape = rockFive; break;
                    default: Console.WriteLine("Error: Rock shape not found! (Current)");
                }

                switch (curRock - 1)
                {
                    case 0: prevRockShape = rockOne; break;
                    case 1: prevRockShape = rockTwo; break;
                    case 2: prevRockShape = rockThree; break;
                    case 3: prevRockShape = rockFour; break;
                    case 4: prevRockShape = rockFive; break;
                    default: Console.WriteLine("Error: Rock shape not found! (Previous)");
                }

                for (int i = botY; i < botY + 3; i++)
                {
                    curX;

                    counter++;
                }
                botY += curRockShape.GetLength(0);


                rockFallen++;
            }








        }

    }

    class Rock
    {
        public int x;
        public int y;
        public char[,] shape;

        public Rock()
        {

        }

    }

}
