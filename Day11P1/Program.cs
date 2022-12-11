// using System;
// using System.IO;
// using System.Text;
// class adventCald10p2
// {
//     public static int cycle = 0;
//     static void Main(string[] args)
//     {

//         Console.Clear();

//         // Console.BackgroundColor = ConsoleColor.DarkBlue;
//         Console.ForegroundColor = ConsoleColor.White;

//         string Add = "addx";
//         string Noop = "noop";

//         int[,] monkey = new int[8, 20];
//         // string[] mkNm;
//         int num = 0;
//         int counter = 0;
//         int monkeyNum = 0;
//         int mnk0 = 0;
//         int mnk1 = 0;
//         int mnk2 = 0;
//         int mnk3 = 0;
//         int mnk4 = 0;
//         int mnk5 = 0;
//         int mnk6 = 0;
//         int mnk7 = 0;
//         List<int> mk0 = new List<int>() { };
//         List<int> mk1 = new List<int>() { };
//         List<int> mk2 = new List<int>() { };
//         List<int> mk3 = new List<int>() { };
//         List<int> mk4 = new List<int>() { };
//         List<int> mk5 = new List<int>() { };
//         List<int> mk6 = new List<int>() { };
//         List<int> mk7 = new List<int>() { };


//         string file = @"C:\Users\cragu\Downloads\ChristmasAdvent-master\ChristmasAdvent-master\Day11P1\Input.txt";

//         Console.WriteLine(File.Exists(file));

//         var lines = File.ReadAllLines(file);

//         foreach (var line in lines) // Initialization
//         {
//             if (line.Contains("Monkey "))
//             {
//                 var mkNM = line.Split(' ');
//                 num = int.Parse(mkNM[1].Replace(":", ""));
//                 // Console.WriteLine(num);
//                 continue;
//             }

//             if (line.Contains("Starting items: "))
//             {
//                 counter = 0;
//                 var startSplit = line.Split(":");
//                 var items = startSplit[1].Split(",");
//                 foreach (var item in items)
//                 {
//                     var rep = int.Parse(item);
//                     switch (num)
//                     {
//                         case 0: mk0.Add(rep); break;
//                         case 1: mk1.Add(rep); break;
//                         case 2: mk2.Add(rep); break;
//                         case 3: mk3.Add(rep); break;
//                         case 4: mk4.Add(rep); break;
//                         case 5: mk5.Add(rep); break;
//                         case 6: mk6.Add(rep); break;
//                         case 7: mk7.Add(rep); break;
//                     }

//                     counter++;
//                 }

//             }


//         }


//         for (int i = 0; i < 21; i++) //20 Rounds
//         {
//             Console.Write("Round: ");
//             Console.WriteLine(i);
//             for (int a = 0; a < 8; a++) //8 Monkeys
//             {
//                 // Console.Write("Monkey ");
//                 // Console.WriteLine(a);
//                 try
//                 {
//                     for (int l = 0; l < 60; l++) //Each possible item
//                     {
//                         switch (a)
//                         {
//                             case 0:

//                                 var workItem = mk0[0];
//                                 if (workItem == 0)
//                                     break;

//                                 else
//                                 {
//                                     var nex = ((workItem * 3) / 3);
//                                     if (nex % 5 == 0)
//                                     {
//                                         mk2.Add(workItem);
//                                     }
//                                     else
//                                     {
//                                         mk3.Add(workItem);
//                                     }
//                                 }
//                                 mk0.RemoveAt(0);
//                                 mnk0 += 1;
//                                 // Console.WriteLine(" Mk {0} interaction", a);
//                                 break;

//                             case 1:

//                                 workItem = mk1[0];
//                                 if (workItem == 0)
//                                     break;
//                                 else
//                                 {
//                                     var nex = (workItem + 8) / 3;
//                                     if (nex % 11 == 0)
//                                         mk4.Add(workItem);
//                                     else
//                                         mk7.Add(workItem);
//                                 }
//                                 mk1.RemoveAt(0);
//                                 mnk1++;
//                                 // Console.WriteLine(" Mk {0} interaction", a);

//                                 break;


//                             case 2:

//                                 workItem = mk2[0];
//                                 if (workItem == 0)
//                                     break;
//                                 else
//                                 {
//                                     var nex = (workItem + 2) / 3;
//                                     if (nex % 2 == 0)
//                                         mk5.Add(workItem);
//                                     else
//                                         mk3.Add(workItem);
//                                 }
//                                 mk2.RemoveAt(0);
//                                 mnk2++;
//                                 // Console.WriteLine(" Mk {0} interaction", a);

//                                 break;

//                             case 3:

//                                 workItem = mk3[0];
//                                 if (workItem == 0)
//                                     break;
//                                 else
//                                 {
//                                     var nex = (workItem + 4) / 3;
//                                     if (nex % 13 == 0)
//                                         mk1.Add(workItem);
//                                     else
//                                         mk5.Add(workItem);
//                                 }
//                                 mk3.RemoveAt(0);
//                                 mnk3++;
//                                 // Console.WriteLine(" Mk {0} interaction", a);

//                                 break;

//                             case 4:

//                                 workItem = mk4[0];
//                                 if (workItem == 0)
//                                     break;
//                                 else
//                                 {
//                                     var nex = (workItem * 19) / 3;
//                                     if (nex % 7 == 0)
//                                         mk7.Add(workItem);
//                                     else
//                                         mk6.Add(workItem);
//                                 }
//                                 mk4.RemoveAt(0);
//                                 mnk4++;
//                                 // Console.WriteLine(" Mk {0} interaction", a);

//                                 break;

//                             case 5:

//                                 workItem = mk5[0];
//                                 if (workItem == 0)
//                                     break;
//                                 else
//                                 {
//                                     var nex = (workItem + 5) / 3;
//                                     if (nex % 3 == 0)
//                                         mk4.Add(workItem);
//                                     else
//                                         mk1.Add(workItem);
//                                 }
//                                 mk5.RemoveAt(0);
//                                 mnk5++;
//                                 // Console.WriteLine(" Mk {0} interaction", a);

//                                 break;

//                             case 6:

//                                 workItem = mk6[0];
//                                 if (workItem == 0)
//                                     break;
//                                 else
//                                 {
//                                     var nex = (workItem * workItem) / 3;
//                                     if (nex % 17 == 0)
//                                         mk0.Add(workItem);
//                                     else
//                                         mk2.Add(workItem);
//                                 }
//                                 mk6.RemoveAt(0);
//                                 mnk6++;
//                                 // Console.WriteLine(" Mk {0} interaction", a);

//                                 break;


//                             case 7:

//                                 workItem = mk7[0];
//                                 if (workItem == 0)
//                                     break;
//                                 else
//                                 {
//                                     var nex = (workItem + 1) / 3;
//                                     if (nex % 19 == 0)
//                                         mk6.Add(workItem);
//                                     else
//                                         mk0.Add(workItem);
//                                 }
//                                 mk7.RemoveAt(0);
//                                 mnk7++;
//                                 // Console.WriteLine(" Mk {0} interaction", a);

//                                 break;

//                         }


//                     }
//                     monkeyNum++;
//                 }
//                 catch (System.Exception)
//                 { }
//             }
//             monkeyNum = 0;
//         }





//         counter = 0;
//         for (int i = 0; i < 8; i++)
//         {
//             switch (i)
//             {
//                 case 0:
//                     // foreach (var element in mk0)
//                     // {
//                     //     Console.Write(element);
//                     //     Console.Write(", ");
//                     // }
//                     Console.Write(" MK0 ");
//                     Console.WriteLine(mnk0);
//                     break;
//                 case 1:
//                     // foreach (var element in mk1)
//                     // {
//                     //     Console.Write(element);
//                     //     Console.Write(", ");
//                     // }
//                     Console.Write(" MK1 ");
//                     Console.WriteLine(mnk1);
//                     break;
//                 case 2:
//                     // foreach (var element in mk2)
//                     // {
//                     //     Console.Write(element);
//                     //     Console.Write(", ");
//                     // }
//                     Console.Write(" MK2 ");
//                     Console.WriteLine(mnk2);
//                     break;
//                 case 3:
//                     // foreach (var element in mk3)
//                     // {
//                     //     Console.Write(element);
//                     //     Console.Write(", ");
//                     // }
//                     Console.Write(" MK3 ");
//                     Console.WriteLine(mnk3);
//                     break;
//                 case 4:
//                     // foreach (var element in mk4)
//                     // {
//                     //     Console.Write(element);
//                     //     Console.Write(", ");
//                     // }
//                     Console.Write(" MK4 ");
//                     Console.WriteLine(mnk4);
//                     break;
//                 case 5:
//                     // foreach (var element in mk5)
//                     // {
//                     //     Console.Write(element);
//                     //     Console.Write(", ");
//                     // }
//                     Console.Write(" MK5 ");
//                     Console.WriteLine(mnk5);
//                     break;
//                 case 6:
//                     // foreach (var element in mk6)
//                     // {
//                     //     Console.Write(element);
//                     //     Console.Write(", ");
//                     // }
//                     Console.Write(" MK6 ");
//                     Console.WriteLine(mnk6);
//                     break;
//                 case 7:
//                     // foreach (var element in mk7)
//                     // {
//                     //     Console.Write(element);
//                     //     Console.Write(", ");
//                     // }
//                     Console.Write(" MK7 ");
//                     Console.WriteLine(mnk7);
//                     break;
//             }

//         }




//     }
// }

