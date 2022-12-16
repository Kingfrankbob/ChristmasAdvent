namespace Day12
{
    class hillClimbAlg
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = ((from line in File.ReadAllLines(file) select line.ToCharArray()).ToArray());

            var start = (x: -1, y: -1);
            var end = (x: -1, y: -1);

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    if (lines[i][j] == 'S')
                    {
                        start = (i, j);
                        lines[i][j] = 'a';
                    }
                    else if (lines[i][j] == 'E')
                    {
                        end = (i, j);
                        lines[i][i] = 'z';
                    }
                }
            }

            Dictionary<(int x, int y), int> distanceCache = new() { { end, 0 } }; // Distance cache

            void calcAround(int x, int y)
            {
                if (!distanceCache.TryGetValue((x, y), out int curVal))
                    throw new InvalidOperationException($"Cannot find Cost");

                void neighborCost(int nextX, int nextY)
                {
                    if (nextX < 0 || nextX >= lines.Length || nextY < 0 || nextY >= lines[0].Length)
                        return;

                    if (lines[nextX][nextY] + 1 >= lines[x][y])
                    {
                        if (!distanceCache.TryGetValue((nextX, nextY), out var currentNeighborCost) || currentNeighborCost > curVal + 1)
                        {
                            distanceCache[(nextX, nextY)] = curVal + 1;
                            calcAround(nextX, nextY);
                            System.Console.WriteLine("Distance: " + distanceCache[(start.x, start.y)] + " " + nextX + " " + nextY + "cCost: " +  currentNeighborCost);
                        }
                    }

                    neighborCost(nextX, nextY - 1);
                    neighborCost(nextX, nextY + 1);
                    neighborCost(nextX - 1, nextY);
                    neighborCost(nextX + 1, nextY);

                }
            }

            calcAround(end.x, end.y);

            System.Console.WriteLine("Total Distance: " + distanceCache[(start.x, start.y)]);

        }


    }
}


