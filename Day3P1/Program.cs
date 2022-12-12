using System;
using System.IO;



class adventCald10p1
{
    static void Main(string[] args)
    {
        char[] same = new char[300];
        char[] alphabet = new char[52] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
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

        counter = 0;
        foreach (var item in same)
        {
            foreach (var lttr in alphabet)
            {
                if (item == lttr)
                {
                    sameCount[counter] = Array.IndexOf(alphabet, lttr) + 1;
                }
            }
            counter++;
        }

        foreach (var item in sameCount)
        {
            totalPoints += item;
        }

        System.Console.WriteLine("Total Points: " + totalPoints);

        int groupCount = 0;
        totalPoints = 0;

        while ((groupCount <= 300))
        {
            groupCount += 3;
            System.Console.WriteLine("gROUP ADd");
            if (groupCount > 300)
            {
                break;
            }

            var group = new string[3];

            for (int i = groupCount - 3; i < groupCount; i++)
            {
                // System.Console.WriteLine("Current Selected Number: " + groupCount + " Current Index: " + (i - (groupCount - 3)) + " Current Group Count: " + lines[i]);
                group[i - (groupCount - 3)] = lines[i];
            }

            foreach (var item in group[0])
            {
                System.Console.WriteLine("XhR CHECK");
                if (group[1].Contains(item) && group[2].Contains(item))
                {
                    totalPoints += Array.IndexOf(alphabet, item) + 1;
                }
            }
        }
        System.Console.WriteLine("Total Points: " + totalPoints);

        // 2838 is goal




    }
}