// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Day17
// {
//     class Rock
//     {
//         public int xMin;
//         public int xMax;
//         public int[] topXHits = new int[] { };
//         public int[] midXHits = new int[] { };
//         public int[] botXHits = new int[] { };
//         public int y;
//         public int prevY;
//         public int width;
//         public int height;
//         public char[,]? shape;
//         public Rock(int curRock)
//         {

//             char[,] rockOne = new char[1, 4] { { '#', '#', '#', '#' } };
//             char[,] rockTwo = new char[3, 3] {  { '.', '#', '.'},
//                                                 { '#', '#', '#'},
//                                                 { '.', '#', '.'} };

//             char[,] rockThree = new char[3, 3] {  { '.', '.', '#'},
//                                                   { '.', '.', '#'},
//                                                   { '#', '#', '#'} };



//             char[,] rockFour = new char[4, 1] { {'#'},
//                                                {'#'},
//                                                {'#'},
//                                                {'#'} };

//             char[,] rockFive = new char[2, 2]  { {'#', '#'},
//                                              { '#', '#'} };

//             switch (curRock)
//             {
//                 case 1:
//                     shape = rockOne;
//                     topXHits = new int[] { 0, 1, 2, 3 };
//                     botXHits = new int[] { 0, 1, 2, 3 };
//                     xMax = 5;
//                     xMin = 2;
//                     break;
//                 case 2:
//                     shape = rockTwo;
//                     topXHits = new int[] { 1 };
//                     midXHits = new int[] { 0, 1, 2 };
//                     botXHits = new int[] { 1 };
//                     xMax = 4;
//                     xMin = 2;
//                     break;
//                 case 3:
//                     shape = rockThree;
//                     topXHits = new int[] { 2 };
//                     midXHits = new int[] { 2 };
//                     botXHits = new int[] { 0, 1, 2 };
//                     xMax = 4;
//                     xMin = 2;
//                     break;
//                 case 4:
//                     shape = rockFour;
//                     topXHits = new int[] { 0 };
//                     botXHits = new int[] { 0 };
//                     xMax = 2;
//                     xMin = 2;
//                     break;
//                 case 5:
//                     shape = rockFive;
//                     topXHits = new int[] { 0, 1 };
//                     botXHits = new int[] { 0, 1 };
//                     xMax = 3;
//                     xMin = 2;
//                     break;
//                 default: Console.WriteLine("Error: Rock shape not found! (Current)"); break;
//             }

//         }
//         public void shiftLeft()
//         {
//             if (xMin >= 0)
//             {
//                 xMin--;
//                 var counter = 0;
//                 foreach (var val in topXHits)
//                 {
//                     topXHits[counter] = val - 1;
//                 }

//                 foreach (var val in topXHits)
//                 {
//                     topXHits[counter] = val - 1;
//                 }

//             }
//         }
//         public void shiftRight()
//         {
//             if (xMin <= 6)
//             {
//                 xMax++;
//                 var counter = 0;
//                 foreach (var val in topXHits)
//                 {
//                     topXHits[counter] = val + 1;
//                 }
//                 foreach (var val in topXHits)
//                 {
//                     topXHits[counter] = val + 1;
//                 }
//             }
//         }

//         public int Width
//         {

//             get
//             {
//                 if (shape != null)
//                     return shape.GetLength(1);
//                 else
//                     return 0;
//             }
//         }
//         public int Height
//         {
//             get
//             {
//                 if (shape != null)
//                     return shape.GetLength(0);
//                 else
//                     return 0;
//             }
//         }

//     }

// }
