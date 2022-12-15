namespace Day5
{
    class StackMover
    {

        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var lines = File.ReadAllLines(file);
            char[] stackCheck = new char[100];

            var stack1 = new Stack();
            var stack2 = new Stack();
            var stack3 = new Stack();
            var stack4 = new Stack();
            var stack5 = new Stack();
            var stack6 = new Stack();
            var stack7 = new Stack();
            var stack8 = new Stack();
            var stack9 = new Stack();

            stack1.Push('D');
            stack1.Push('H');
            stack1.Push('N');
            stack1.Push('Q');
            stack1.Push('T');
            stack1.Push('W');
            stack1.Push('V');
            stack1.Push('B');

            stack2.Push('D');
            stack2.Push('W');
            stack2.Push('B');

            stack3.Push('T');
            stack3.Push('S');
            stack3.Push('Q');
            stack3.Push('W');
            stack3.Push('J');
            stack3.Push('C');

            stack4.Push('F');
            stack4.Push('J');
            stack4.Push('R');
            stack4.Push('N');
            stack4.Push('Z');
            stack4.Push('T');
            stack4.Push('P');

            stack5.Push('G');
            stack5.Push('P');
            stack5.Push('V');
            stack5.Push('J');
            stack5.Push('M');
            stack5.Push('S');
            stack5.Push('T');

            stack6.Push('B');
            stack6.Push('W');
            stack6.Push('F');
            stack6.Push('T');
            stack6.Push('N');

            stack7.Push('B');
            stack7.Push('L');
            stack7.Push('D');
            stack7.Push('Q');
            stack7.Push('F');
            stack7.Push('H');
            stack7.Push('V');
            stack7.Push('N');

            stack8.Push('H');
            stack8.Push('P');
            stack8.Push('F');
            stack8.Push('R');

            stack9.Push('Z');
            stack9.Push('S');
            stack9.Push('M');
            stack9.Push('B');
            stack9.Push('L');
            stack9.Push('N');
            stack9.Push('P');
            stack9.Push('H');

            List<Stack> stackList = new List<Stack>() { stack1, stack2, stack3, stack4, stack5, stack6, stack7, stack8, stack9 };


            foreach (var line in lines)
            {
                if (line.Contains("move"))
                {
                    var moveFrom = line.Split("from");
                    var moveFromStack = moveFrom[1].Split("to"); // Move FROM[0] TO[1]
                    var moveTotal = moveFrom[0].Split(" ");

                    var targetAmount = moveTotal[1];
                    var targetStack = moveFromStack[0];
                    var targetToStack = moveFromStack[1];

                    // System.Console.WriteLine("Move " + targetAmount + " from " + targetStack + " to " + targetToStack);

                    var target = stackList[Int32.Parse(targetToStack) - 1];
                    var source = stackList[Int32.Parse(targetStack) - 1];

                    for (int i = 0; i < Int32.Parse(targetAmount); i++)
                    {
                        target.Push(source.Pop());
                    }

                }

            }

            System.Console.WriteLine("Final Stacks P1: ");

            foreach (var stack in stackList)
            {
                System.Console.Write(stack.last);
            }

            System.Console.WriteLine();


            stack1.Clear();
            stack2.Clear();
            stack3.Clear();
            stack4.Clear();
            stack5.Clear();
            stack6.Clear();
            stack7.Clear();
            stack8.Clear();
            stack9.Clear();

            stack1.Push('D');
            stack1.Push('H');
            stack1.Push('N');
            stack1.Push('Q');
            stack1.Push('T');
            stack1.Push('W');
            stack1.Push('V');
            stack1.Push('B');

            stack2.Push('D');
            stack2.Push('W');
            stack2.Push('B');

            stack3.Push('T');
            stack3.Push('S');
            stack3.Push('Q');
            stack3.Push('W');
            stack3.Push('J');
            stack3.Push('C');

            stack4.Push('F');
            stack4.Push('J');
            stack4.Push('R');
            stack4.Push('N');
            stack4.Push('Z');
            stack4.Push('T');
            stack4.Push('P');

            stack5.Push('G');
            stack5.Push('P');
            stack5.Push('V');
            stack5.Push('J');
            stack5.Push('M');
            stack5.Push('S');
            stack5.Push('T');

            stack6.Push('B');
            stack6.Push('W');
            stack6.Push('F');
            stack6.Push('T');
            stack6.Push('N');

            stack7.Push('B');
            stack7.Push('L');
            stack7.Push('D');
            stack7.Push('Q');
            stack7.Push('F');
            stack7.Push('H');
            stack7.Push('V');
            stack7.Push('N');

            stack8.Push('H');
            stack8.Push('P');
            stack8.Push('F');
            stack8.Push('R');

            stack9.Push('Z');
            stack9.Push('S');
            stack9.Push('M');
            stack9.Push('B');
            stack9.Push('L');
            stack9.Push('N');
            stack9.Push('P');
            stack9.Push('H');


            foreach (var line in lines)
            {
                if (line.Contains("move"))
                {
                    var moveFrom = line.Split("from");
                    var moveFromStack = moveFrom[1].Split("to"); // Move FROM[0] TO[1]
                    var moveTotal = moveFrom[0].Split(" ");

                    var targetAmount = moveTotal[1];
                    var targetStack = moveFromStack[0];
                    var targetToStack = moveFromStack[1];

                    var target = stackList[Int32.Parse(targetToStack) - 1];
                    var source = stackList[Int32.Parse(targetStack) - 1];

                    if (!(Int32.Parse(targetAmount) > 1))
                    {
                        target.Push(source.Pop());
                    }

                    if ((Int32.Parse(targetAmount) > 1))
                    {
                        var tempStack = new Stack();
                        for (int i = 0; i < Int32.Parse(targetAmount); i++)
                        {
                            tempStack.Push(source.Pop());
                        }
                        for (int i = 0; i < Int32.Parse(targetAmount); i++)
                        {
                            target.Push(tempStack.Pop());
                        }
                    }



                }

            }
            System.Console.WriteLine("Final Stacks PT2: ");

            foreach (var stack in stackList)
            {
                System.Console.Write(stack.last);
            }

            System.Console.WriteLine();








        }
    }
}