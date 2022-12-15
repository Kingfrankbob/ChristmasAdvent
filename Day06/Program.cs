using System.Text;
namespace Day6
{
    class uniqueFinder
    {

        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = File.ReadAllText(file);

            for (int i = 0; i < lines.Length - 4; i++)
            {
                bool isUnique = lines.Skip(i).Take(4).Distinct().Count() == 4;
                if (isUnique)
                {
                    Console.WriteLine("(4)Set of Unique Characters: " + lines.Substring(i, 4) + " at position " + (i + 4));
                    break;
                }
            }
            for (int i = 0; i < lines.Length - 14; i++)
            {
                bool isUnique = lines.Skip(i).Take(14).Distinct().Count() == 14;
                if (isUnique)
                {
                    Console.WriteLine("(14)Set of Unique Characters: " + lines.Substring(i, 14) + " at position " + (i + 14));
                    break;
                }
            }

        }
    }
}