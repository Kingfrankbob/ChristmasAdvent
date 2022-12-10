using System;
using System.IO;



class adventCald10p1
{
    static void Main(string[] args)
    {
        var breakpoints = new int[]
        {
          20,
          60,
           100,
           140,
           180,
          220
        };
        var nextBreakpointId = 0;
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        string Add = "addx";
        string Noop = "noop";
        int cycle = 0;
        int total = 1;
        int addVal = 0;
        int grandTotal = 0;
        string file = @"C:\Users\ajwpc\Github\ChristmasAdvent\Input.txt";
        Console.WriteLine(File.Exists(file));

        var lines = File.ReadAllLines(file);

        foreach (var item in lines)
        {

            if (breakpoints[nextBreakpointId] == cycle ||
        (item != "noop" && breakpoints[nextBreakpointId] <= cycle + 2))
            {
                System.Console.WriteLine($"Signal strength at breakpoint {breakpoints[nextBreakpointId]}: {total * breakpoints[nextBreakpointId]}");
                System.Console.WriteLine();
                grandTotal += total * breakpoints[nextBreakpointId];
                nextBreakpointId++;
                if (nextBreakpointId >= breakpoints.Length)
                {
                    break;
                }

            }

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
        }

        System.Console.Write("Grand Total of all cycles: ");
        System.Console.WriteLine(grandTotal);


    }

}

