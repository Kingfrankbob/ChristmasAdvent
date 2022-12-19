using System;
using System.IO;
using System.Text;
class adventCald10p2
{
    public static int cycle = 0;
    static void Main(string[] args)
    {

        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        string Noop = "noop";
        //int cycle = 0;
        int total = 1;
        int addVal = 0;
        char[] Screen = new char[240];
        string file = @"Input.txt";
        StringBuilder outputBuilder = new();
        Console.WriteLine(File.Exists(file));
        //StringBuilder outputBuilder = new();

        var lines = File.ReadAllLines(file);

        foreach (var item in lines)
        {

            outputBuilder = Process(total, outputBuilder);

            if (!item.Contains(Noop))
            {
                outputBuilder = Process(total, outputBuilder);
                var value = item.Split(' ');
                addVal = int.Parse(value[1]);
                total += addVal;
            }






        }

        Console.WriteLine(outputBuilder.ToString());
    }

    static StringBuilder Process(int total, StringBuilder outputBuilder)
    {
        if (total - 1 <= cycle && cycle <= total + 1)
        {
            outputBuilder.Append("#");
        }
        else
        {
            outputBuilder.Append(".");
        }

        cycle += 1;

        if (cycle % 40 == 0)
        {
            outputBuilder.AppendLine(); cycle = 0;
        }

        return outputBuilder;
    }



}
