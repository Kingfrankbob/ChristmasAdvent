using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day14
{
    public class Cave
    {
        public char[,] Canvas { get; set; }
        public static char Rock = '#';
        public static char Air = '.';
        public static char Empty = '0';
        public static char Sand = 'o';
        public Cave(int width, int height)
        {
            Canvas = new char[width, height];
        }
        public void Draw()
        {
            for (int y = 0; y < Canvas.GetLength(1); y++)
            {
                for (int x = 0; x < Canvas.GetLength(0); x++)
                {
                    if (Canvas[x, y] != '#')
                        Console.Write('.');
                    else
                        Console.Write(Canvas[x, y]);
                }
                Console.WriteLine();
            }
        }
        public char this[int x, int y]
        {
            get
            {
                return Canvas[x, y];
            }
            set
            {
                Canvas[x, y] = value;
            }
        }

    }
}