using System;
using System.IO;



class adventCal
{
    static void Main(string[] args)
    {

        string Add = "addx";
string Noop = "noop";   
int cycle = 0;
int total = 1;
int addVal = 0;
                string file = @"C:\Users\ajwpc\Github\ChristmasAdvent\Input.txt";
        Console.WriteLine(File.Exists(file));
        // if (File.Exists(file)) {
        //      var lines = File.ReadAllLines(file);

        // }

         var lines = File.ReadAllLines(file);

        foreach (var item in lines)
        {
            if(item.Contains(Add))
            {
                cycle+=1;
                Console.WriteLine(cycle);
                Console.WriteLine("Half");
                var value = item.Split(' ');
                cycle+=1;
                        try
        {
            addVal = Int32.Parse(value[1]);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value[1]}'");
        }
                total += addVal;
                Console.WriteLine("Cycle# vv");
                Console.WriteLine(cycle);
                Console.WriteLine("total vv");
                Console.WriteLine(total);

                Console.WriteLine(value[1]); 

            }
            if(item.Contains(Noop))
            {
                cycle += 1;
                Console.WriteLine(Noop);
                Console.WriteLine(cycle);
            }
            
        }

    }
}
