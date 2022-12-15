namespace Day8
{
    class treeSee
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = File.ReadAllLines(file);
            var treeGrid = new int[99, 99];
            int treeCount = 0;
            int rowCounter = 0;
            int bestScoreTree = 0;

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    treeGrid[rowCounter, i] = Int32.Parse(line[i].ToString());
                }

                rowCounter++;
            }

            for (int i = 0; i < treeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < treeGrid.GetLength(1); j++)
                {
                    treeCount += checkTrees(treeGrid, i, j);
                }
            }
            System.Console.WriteLine("Tree Count: " + treeCount);


            for (int i = 0; i < treeGrid.GetLength(0); i++)
            {
                for (int j = 0; j < treeGrid.GetLength(1); j++)
                {
                    bestScoreTree = checkTreesScenic(treeGrid, i, j, bestScoreTree);
                }
            }
            System.Console.WriteLine("Top Tree Score: " + bestScoreTree);



        }

        static int checkTrees(int[,] treeGrid, int x, int y)
        {
            int treeCount = 0;
            // int xRight = treeGrid[x + 1, y];
            // int yUp = treeGrid[x, y + 1];
            // int xLeft = treeGrid[x - 1, y];
            // int yDown = treeGrid[x, y - 1];
            var edgeChecks = 4;
            int treeCurrent = treeGrid[x, y];

            if (x == 0 || x == 98 || y == 0 || y == 98)
            {
                treeCount++;
                return treeCount;
            }

            for (int i = x + 1; i < 99; i++)
            {
                if (treeGrid[i, y] >= treeCurrent)
                {
                    edgeChecks--;
                    break;
                }
            }
            for (int i = 0; i < x; i++)
            {
                if (treeGrid[i, y] >= treeCurrent)
                {
                    edgeChecks--;
                    break;
                }
            }
            for (int i = 0; i < y; i++)
            {
                if (treeGrid[x, i] >= treeCurrent)
                {
                    edgeChecks--;
                    break;
                }
            }
            for (int i = y + 1; i < 99; i++)
            {
                if (treeGrid[x, i] >= treeCurrent)
                {
                    edgeChecks--;
                    break;
                }
            }
            if (edgeChecks != 0)
            {
                treeCount++;
            }
            return treeCount;
        }
        static int checkTreesScenic(int[,] treeGrid, int x, int y, int bestScore)
        {
            int treeCurrent = treeGrid[x, y];
            var scenicScore = 1;
            int ix = 0;
            int iy = 0;

            if (x == 0 || x == 98 || y == 0 || y == 98)
            {
                return 0;
            }

            for (ix = x + 1; ix < 98; ix++)
                if (treeGrid[ix, y] >= treeCurrent)
                    break;

            scenicScore *= ix - x;

            for (ix = x - 1; ix < 0; ix--)
                if (treeGrid[ix, y] >= treeCurrent)
                    break;

            scenicScore *= x - ix;


            for (iy = y - 1; iy < 0; iy--)
                if (treeGrid[x, iy] >= treeCurrent)
                    break;

            scenicScore *= y - iy;

            for (iy = y + 1; iy < 98; iy++)
                if (treeGrid[x, iy] >= treeCurrent)
                    break;

            scenicScore *= iy - y;

            if (scenicScore > bestScore)
            {
                bestScore = scenicScore;
            }
            return bestScore;
        }

    }

}