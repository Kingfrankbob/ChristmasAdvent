using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;   // NNED TEST ON BETTER COMPUTER XDD

var stopwatch = Stopwatch.StartNew();

var data =
    (from line in File.ReadAllLines("input.txt")
     where !string.IsNullOrWhiteSpace(line)
     select line.ToArray()).ToArray();

var start = (x: -1, y: -1);
var end = (x: -1, y: -1);

for (int x = 0; x < data.Length; ++x)
    for (int y = 0; y < data[0].Length; ++y)
    {
        if (data[x][y] == 'S')
        {
            start = (x, y);
            data[x][y] = 'a';
        }

        if (data[x][y] == 'E')
        {
            end = (x, y);
            data[x][y] = 'z';
        }
    }

var queue = new Queue<(int x, int y, int steps)>();
queue.Enqueue((start.x, start.y, 0));

var visited = new HashSet<(int x, int y)>();
visited.Add((start.x, start.y));

while (queue.Count > 0)
{
    var (x, y, steps) = queue.Dequeue();

    if (data[x][y] == 'z')
    {
        Console.WriteLine($"Found end in {steps} steps");
        break;
    }

    if (data[x][y] != 'a' && data[x][y] != 'z')
    {
        var nextLetter = (char)(data[x][y] + 1);
        for (int i = 0; i < data.Length; ++i)
            for (int j = 0; j < data[0].Length; ++j)
                if (data[i][j] == nextLetter)
                {
                    queue.Enqueue((i, j, steps + 1));
                    visited.Add((i, j));
                }
    }

    if (x > 0 && data[x - 1][y] != '#' && !visited.Contains((x - 1, y)))
        queue.Enqueue((x - 1, y, steps + 1));

    if (x < data.Length - 1 && data[x + 1][y] != '#' && !visited.Contains((x + 1, y)))
        queue.Enqueue((x + 1, y, steps + 1));

    if (y > 0 && data[x][y - 1] != '#' && !visited.Contains((x, y - 1)))
        queue.Enqueue((x, y - 1, steps + 1));

    if (y < data[0].Length - 1 && data[x][y + 1] != '#' && !visited.Contains((x, y + 1)))
        queue.Enqueue((x, y + 1, steps + 1));
}

stopwatch.Stop();
Console.WriteLine($"Took {stopwatch.ElapsedMilliseconds}ms");
