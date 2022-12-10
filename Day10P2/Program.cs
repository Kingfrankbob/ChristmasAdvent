using System;
using System.IO;
class adventCald10p2
{
    static void Main(string[] args)
    {

        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        string Add = "addx";
        string Noop = "noop";
        int cycle = 0;
        int total = 1;
        int addVal = 0;
        int placeHold = 0;
        char[] Screen = new char[240];
        string file = @"C:\Users\ajwpc\Github\ChristmasAdvent\Day10P1\Input.txt";
        Console.WriteLine(File.Exists(file));

        var lines = File.ReadAllLines(file);

        foreach (var item in lines)
        {
            if (item.Contains(Noop))
            {
                cycle += 1;
            }
            if (item.Contains(Add))
            {
                var value = item.Split(' ');
                addVal = int.Parse(value[1]);
                total += addVal;
                cycle += 2;
            }
            try
            {
                if (total <= cycle + 1 && cycle - 1 <= total)
                {
                    Screen[cycle] = '#';
                }
                else
                    Screen[cycle] = '.';

                System.Console.WriteLine($"Cycle: {cycle} Total: {total} AddVal: {addVal} PlaceHold: {placeHold} Can Place?:{total + 1 == placeHold || total - 1 == placeHold || total == placeHold}");
            }
            catch




            placeHold++;
            }
            placeHold = 0;
            foreach (var item in Screen)
            {
                Console.Write(item);
                if (placeHold % 40 == 0)
                    System.Console.WriteLine();
                placeHold++;
            }




        }
    }