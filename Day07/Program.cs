namespace Day7
{
    class directoryChecker
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = File.ReadAllLines(file);

            foreach (var line in lines)
            {
                
                
            }



        }

    }

}