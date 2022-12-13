using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
namespace Day13
{
    class adventCald10p1
    {
        static void Main(string[] args)
        {
            int rightSums = 0;
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = (from line in File.ReadAllLines("Input.txt") where !string.IsNullOrWhiteSpace(line) select line).ToArray();

            var comparer = new SpecialSorter();

            for (var i = 0; i < lines.Length; i += 2)
            {
                var compare = comparer.Compare(lines[i], lines[i + 1]);
                if (compare == -1)
                    rightSums += i / 2 + 1;
            }
            System.Console.WriteLine("Right Sums: " + rightSums);

            var newData = new List<string>(lines) { "[[2]]", "[[6]]" };

            newData.Sort(comparer);

            System.Console.WriteLine("2 and 6 Together: " + ((newData.IndexOf("[[2]]") + 1) * (newData.IndexOf("[[6]]") + 1)));

            //Based off of Brad Wilson's Solution Sorter

        }

    }
}