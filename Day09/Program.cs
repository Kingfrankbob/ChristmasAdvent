using System.Drawing;

namespace Day9
{
    class ropeCalc
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = File.ReadAllLines(file);

            var PointH = new Point(0, 0);
            var PointT = new Point(0, 0);
            var tailVisited = new HashSet<(int, int)>();


            foreach (var line in lines)
            {
                var checks = line.Split(' ');
                var direction = checks[0];
                var distance = Int32.Parse(checks[1]);
                while (distance > 0)
                {
                    PointH = Move(PointH, direction);
                    PointT = MoveTail(PointH, PointT);

                    tailVisited.Add((PointT.X, PointT.Y));
                    distance--;
                }

            }

            System.Console.WriteLine("Total Visited With 1: " + tailVisited.Count);
            var point0 = new Point(0, 0);
            var point1 = new Point(0, 0);
            var point2 = new Point(0, 0);
            var point3 = new Point(0, 0);
            var point4 = new Point(0, 0);
            var point5 = new Point(0, 0);
            var point6 = new Point(0, 0);
            var point7 = new Point(0, 0);
            var point8 = new Point(0, 0);
            PointH.X = 0;
            PointH.Y = 0;

            tailVisited.Clear();

            foreach (var line in lines)
            {
                var checks = line.Split(' ');
                var direction = checks[0];
                var distance = Int32.Parse(checks[1]);
                while (distance > 0)
                {
                    PointH = Move(PointH, direction);
                    point0 = MoveTail(PointH, point0);
                    point1 = MoveTail(point0, point1);
                    point2 = MoveTail(point1, point2);
                    point3 = MoveTail(point2, point3);
                    point4 = MoveTail(point3, point4);
                    point5 = MoveTail(point4, point5);
                    point6 = MoveTail(point5, point6);
                    point7 = MoveTail(point6, point7);
                    point8 = MoveTail(point7, point8);

                    tailVisited.Add((point8.X, point8.Y));
                    distance--;
                }

            }
            System.Console.WriteLine("Total Visited With 9: " + tailVisited.Count);

        }

        public static Point Move(Point p1, string direction)
        {
            switch (direction)
            {
                case "U":
                    p1.Y--;
                    break;
                case "D":
                    p1.Y++;
                    break;
                case "L":
                    p1.X--;
                    break;
                case "R":
                    p1.X++;
                    break;
            }
            return p1;
        }

        public static Point MoveTail(Point Head, Point Tail)
        {
            var dx = Head.X - Tail.X;
            var dy = Head.Y - Tail.Y;
            var result = Tail;
            //Found cleaner/d version
            if (dy == 2)
            {
                result.Y++;
                result.X += dx > 0 ? 1 : (dx < 0 ? -1 : 0);
            }
            else if (dy == -2)
            {
                result.Y--;
                result.X += dx > 0 ? 1 : (dx < 0 ? -1 : 0);
            }
            else if (dx == 2)
            {
                result.X++;
                result.Y += dy > 0 ? 1 : (dy < 0 ? -1 : 0);
            }
            else if (dx == -2)
            {
                result.X--;
                result.Y += dy > 0 ? 1 : (dy < 0 ? -1 : 0);
            }
            return result;
        }




    }

}