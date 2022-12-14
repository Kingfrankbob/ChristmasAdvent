// using System.Text;
namespace Day14
{
    class uniqueFinder
    {

        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = File.ReadAllLines(file);
            char[,] canvas = new char[100, 200];
            int counter = 0;
            int lineCounter = 0;

            var prevx = 0;
            var prevy = 0;

            int minx = 999, miny = 999, maxx = 0, maxy = 0;

            foreach (var line in lines)
            {
                var points = line.Split(" -> ");


                foreach (var point in points)
                {
                    if (counter != 0)
                    {
                        var xy = point.Split(',');
                        var x = int.Parse(xy[0]) - 460;
                        var y = int.Parse(xy[1]) - 10;

                        var xdiff = x - prevx;
                        var ydiff = y - prevy;

                        System.Console.WriteLine("line: " + lineCounter + " x: " + x + " y: " + y + " prevx: " + prevx + " prevy: " + prevy + " xdiff: " + xdiff + " ydiff: " + ydiff);

                        //Graph from prevx,prevy to x,y
                        if (xdiff == 0)
                        {
                            if (ydiff > 0)
                            {
                                for (int i = prevy; i <= y; i++)
                                {
                                    canvas[prevx, i] = '#';
                                }
                            }
                            else
                            {
                                for (int i = y; i <= prevy; i++)
                                {
                                    canvas[prevx, i] = '#';
                                }
                            }
                        }
                        else if (ydiff == 0)
                        {
                            if (xdiff > 0)
                            {
                                for (int i = prevx; i <= x; i++)
                                {
                                    canvas[i, prevy] = '#';
                                }
                            }
                            else
                            {
                                for (int i = x; i <= prevx; i++)
                                {
                                    canvas[i, prevy] = '#';
                                }
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Error");
                        }

                    }
                    var xxy = point.Split(',');
                    var xx = int.Parse(xxy[0]) - 460;
                    var yx = int.Parse(xxy[1]) - 10;
                    prevx = xx;
                    prevy = yx;
                    if (counter != 0)
                    {
                        if (prevx < minx) minx = prevx;
                        if (prevx > maxx) maxx = prevx;
                        if (prevy < miny) miny = prevy;
                        if (prevy > maxy) maxy = prevy;
                    }

                    counter++;
                }
                counter = 0;
                lineCounter++;


            }
            counter = 0;

            // System.Console.WriteLine("minx: " + minx + " miny: " + miny + " maxx: " + maxx + " maxy: " + maxy);


            foreach (var item in canvas)
            {
                if (item != '#') System.Console.Write('.');
                else System.Console.Write(item);

                if (counter % 100 == 0) System.Console.WriteLine("/n");
                counter++;
            }

        }
    }
}