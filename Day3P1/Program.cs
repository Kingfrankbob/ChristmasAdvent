using System;
using System.IO;



class adventCald10p1
{
    static void Main(string[] args)
    {
        char[] same = new char[300];
        char[] alphabet = new char[52]('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
        long totalPoints = 0;
        int[] sameCount = new int[300];
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
        string file = @"Input.txt";
        Console.WriteLine(File.Exists(file));
        int counter = 0;

        var lines = File.ReadAllLines(file);

        foreach (var line in lines)
        {

            var first = line.Substring(0, (int)(line.Length / 2));
            var last = line.Substring((int)(line.Length / 2), (int)(line.Length / 2));

            foreach (var item in first)
            {
                if (last.Contains(item))
                {
                    same[counter] = item;
                }

            }
            counter++;

        }

        foreach (var item in same)
        {
            for (int i = 0; i < 52; i++)
            {
                if (item == alphabet[i])
                {
                    sameCount[i] = alphabet[i];
                }
            }
        }

        foreach (var item in sameCount)
        {
            totalPoints += item;
        }





    }
}