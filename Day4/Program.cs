class adventCald10p1
{
    static void Main(string[] args)
    {
        int overLap = 0;
        Console.Clear();
        string file = @"Input.txt";
        Console.WriteLine("File Exists? " + File.Exists(file));
        var lines = File.ReadAllLines(file);

        foreach (var line in lines)
        {
            var assignements = line.Split(",");

            var firBounds = assignements[0].Split("-");
            var secBounds = assignements[1].Split("-");

            //IF ELF DO EACHOTHER WORK XDD
            if (Int32.Parse(secBounds[0]) <= Int32.Parse(firBounds[0]) && Int32.Parse(secBounds[1]) >= Int32.Parse(firBounds[1]) || Int32.Parse(secBounds[0]) >= Int32.Parse(firBounds[0]) && Int32.Parse(secBounds[1]) <= Int32.Parse(firBounds[1]))
            {
                overLap++;
            }

        }

        Console.WriteLine("Overlaps P1: " + overLap);

        overLap = 0;

        foreach (var line in lines)
        {
            var assignments = line.Split(",");

            var firBounds = assignments[0].Split("-");
            var secBounds = assignments[1].Split("-");

            if (Int32.Parse(firBounds[0]) <= Int32.Parse(secBounds[1]) &&
            Int32.Parse(secBounds[0]) <= Int32.Parse(firBounds[1]))
            {
                overLap++;
            }

        }

        System.Console.WriteLine("Overlaps P2: " + overLap);


    }

}