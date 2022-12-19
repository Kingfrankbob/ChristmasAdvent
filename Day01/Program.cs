namespace Day1
{
    class CalorieCounter
    {

        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = File.ReadAllLines(file);

            var totalList = new List<int>();
            var total = 0;
            foreach (var line in lines)
            {
                if (line == "")
                {
                    totalList.Add(total);
                    total = 0;
                }
                else
                {
                    total += int.Parse(line);
                }
            }
            totalList.Add(total);
            Console.WriteLine("First Elf Sum: " + totalList.Max());

            var topThree = totalList.OrderByDescending(x => x).Take(3).ToList();
            var topThreeTotal = topThree.Sum();
            Console.WriteLine("Top Three Total: " + topThreeTotal);



        }

    }

}