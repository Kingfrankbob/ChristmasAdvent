using System;
using System.IO;



class adventCald10p1
{
    static void Main(string[] args)
    {
        long totalPoints = 0;
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        string file = @"Input.txt";
        Console.WriteLine(File.Exists(file));

        string[,] wins = new string[3, 2] { { "A", "Y" }, { "B", "X" }, { "C", "Z" } }; // Sciscors = C,Z  Paper = Y,B  Rock = X,A

        var lines = File.ReadAllLines(file);

        foreach (var line in lines)
        {
            var contest = line.Split(' ');
            var test1 = contest[0];
            var test2 = contest[1];

            if (test1 == "C" && test2 == "Z")
            {
                totalPoints += 6;
            }
            else if (test1 == "C" && test2 == "Y")
            {
                totalPoints += 2;
            }
            else if (test1 == "C" && test2 == "X")
            {
                totalPoints += 7;
            }
            else if (test1 == "A" && test2 == "Z")
            {
                totalPoints += 3;
            }
            else if (test1 == "A" && test2 == "Y")
            {
                // Sciscors = C,Z  Paper = Y,B  Rock = X,A
                totalPoints += 8;
            }
            else if (test1 == "A" && test2 == "X")
            {
                totalPoints += 4;
            }
            else if (test1 == "B" && test2 == "Z")
            {
                totalPoints += 9;
            }
            else if (test1 == "B" && test2 == "Y")
            {
                // Sciscors = C,Z  Paper = Y,B  Rock = X,A
                totalPoints += 5;
            }
            else if (test1 == "B" && test2 == "X")
            {
                totalPoints += 1;
            }


        }
        System.Console.WriteLine("Total points: " + totalPoints);



    }
}

