
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day21
{
    class monkeyMath
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            if (!File.Exists(file))
                return;
            var lines = File.ReadAllLines(file);
            var counter = 0;

            var monkeyOps = new Dictionary<string, string>();
            var monkeyVals = new Dictionary<string, Int64>();

            foreach (var line in lines)
            {
                // Console.WriteLine("Line: " + counter);
                var split = line.Split(':');
                var name = split[0];
                var vals = split[1].Split(' ');
                if (vals.Length <= 2)
                {
                    if (name != "humn")
                        monkeyVals.Add(name, Int64.Parse(vals[1]));
                }
                else
                {
                    monkeyOps.Add(name, split[1]);
                }
                counter++;

            }
            Console.WriteLine("MonkeyOps: " + monkeyOps.Count + " MonkeyVals: " + monkeyVals.Count);
            // foreach (var item in monkeyVals)
            // {
            //     Console.WriteLine(item.Key + " " + item.Value);
            // }
            while (monkeyOps.Count > 0)
            {
                foreach (var item in monkeyOps)
                {

                    var opStringSplit = item.Value.Split(' ');
                    var monk1 = opStringSplit[1];
                    var oper = opStringSplit[2];
                    var monk2 = opStringSplit[3];
                    // Console.WriteLine("Checking: " + item.Key + " " + monk1 + " " + oper + " " + monk2);
                    if (monkeyVals.ContainsKey(monk1) && monkeyVals.ContainsKey(monk2))
                    {
                        // Console.WriteLine("Found Monek1 and Monk2: " + monkeyVals[monk1] + " " + monkeyVals[monk2]);
                        var val1 = monkeyVals[monk1];
                        var val2 = monkeyVals[monk2];
                        var result = 0L;
                        switch (oper)
                        {
                            case "+":
                                result = val1 + val2;
                                break;
                            case "*":
                                result = val1 * val2;
                                break;
                            case "/":
                                result = val1 / val2;
                                break;
                            case "-":
                                result = val1 - val2;
                                break;
                            default:
                                Console.WriteLine("Error: " + oper);
                                return;
                        }
                        // Console.WriteLine("Result: " + result);
                        if (item.Key == "root")
                        {
                            Console.WriteLine("Root Equals: " + monkeyVals[monk1] + " [operator] " + monkeyVals[monk2]);
                            return;
                        }
                        monkeyVals.Add(item.Key, result);
                        monkeyOps.Remove(item.Key);


                    }

                }
            }
            Console.WriteLine("Root Equals: " + monkeyVals["root"]);
        }

    }
}


