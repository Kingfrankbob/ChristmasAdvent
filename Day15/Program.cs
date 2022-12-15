namespace Day15
{
    class distressFinder
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = File.ReadAllLines(file);
            // var map = new char[10000000, 10000000];
            // int count = 0;
            var targetY = 2000000;
            bool isDoing = false;

            var hits = new Dictionary<long, char>();

            foreach (var line in lines)
            {

                var points = line.Split(':');
                var sensCords = points[0].Split(' ');
                var sensX = Int32.Parse(sensCords[2].Replace(',', ' ').Split('=')[1].Trim());
                var sensY = Int32.Parse(sensCords[3].Split('=')[1].Trim());

                var beaconCords = points[1].Split(' ');
                var beaconX = Int32.Parse(beaconCords[5].Split('=')[1].Replace(',', ' ').Trim());
                var beaconY = Int32.Parse(beaconCords[6].Split('=')[1]);

                var distance = Math.Abs(sensX - beaconX) + Math.Abs(sensY - beaconY);

                if (sensY - distance <= 2000000 && sensY + distance >= 2000000)
                {
                    var distanceToY = Math.Abs(sensY - 2000000);
                    var residualLeft = distance - distanceToY;

                    for (long x = sensX - residualLeft; x <= sensX + residualLeft; ++x)
                        if (sensY == targetY && x == sensX)
                            hits[x] = 'S';
                        else if (beaconY == targetY && x == beaconX)
                            hits[x] = 'B';
                        else if (!hits.ContainsKey(x))
                            hits[x] = '#';
                }

            }

            Console.WriteLine("Part 1: " + hits.Values.Where(c => c == '#').Count());
            System.Console.WriteLine("Part 2: " + isDoing);



        }
    }
}