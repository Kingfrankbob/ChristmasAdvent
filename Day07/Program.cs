using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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


            var folders = new Dictionary<string, Folder>();
            string? cPath = null;
            Folder? cFolder = null;
            var fStack = new Stack<string>();
            var sysTot = 0L;

            foreach (var line in lines)
            {
                if (line.StartsWith("$ cd "))
                {
                    var subPath = line[5..];
                    if (subPath == "..")
                    {
                        cPath = fStack.Pop();
                        cFolder = folders[cPath];
                    }
                    else
                    {
                        if (cPath != null)
                            fStack.Push(cPath);

                        cPath = (cPath + "/" + subPath).Replace("//", "/");
                        cFolder?.SubFolders.Add(cPath);
                        cFolder = new Folder(cPath);
                        folders.Add(cPath, cFolder);
                    }
                }
                else if (line == "$ ls")
                {

                }
                else if (line.StartsWith("dir "))
                {

                }
                else
                {
                    var pieces = line.Split(' ');
                    var size = long.Parse(pieces[0]);
                    cFolder!.fileSize += size;
                }

            }

            var resSize = 0L;
            foreach (var folder in folders.Values)
            {
                // Console.WriteLine(folder.Name + " Size ->" + folder.fileSizeCheck(folders));
                if (folder.fileSizeCheck(folders) <= 100000)
                {
                    resSize += folder.fileSizeCheck(folders);
                }
                if (folder.Name == "/")
                {
                    sysTot = folder.fileSizeCheck(folders);
                }
            }

            System.Console.WriteLine("Total Size: " + resSize + " bytes");

            System.Console.WriteLine("System Size: " + sysTot + " bytes");

            var toClear = 30000000 - (70000000 - sysTot);

            System.Console.WriteLine("To Clear: " + toClear + " bytes");

            var smolList = new List<long>();

            foreach (var folder in folders.Values)
            {
                if (folder.fileSizeCheck(folders) == toClear)
                {
                    Console.WriteLine(folder.Name + " Size ->" + folder.fileSizeCheck(folders));
                }
                else if (1000000 > folder.fileSizeCheck(folders) && folder.fileSizeCheck(folders) > toClear)
                {
                    // Console.WriteLine(folder.Name + " Size ->" + folder.fileSizeCheck(folders) + " Close Number:" + (folder.fileSizeCheck(folders) - toClear));
                    smolList.Add(folder.fileSizeCheck(folders) - toClear);
                }
                else
                {

                }
            }

            var target = smolList.Min();
            var targetFolder = folders.Values.Where(x => x.fileSizeCheck(folders) == (toClear + target)).First();

            Console.WriteLine(targetFolder.Name + " Size ->" + targetFolder.fileSizeCheck(folders) + " Close Number:" + (targetFolder.fileSizeCheck(folders) - toClear));


        }

    }

    class Folder
    {
        public string Name { get; set; }
        public List<string> SubFolders { get; set; }
        public long fileSize { get; set; }

        public Folder(string name)
        {
            Name = name;
            SubFolders = new List<string>();
            fileSize = 0;
        }

        public long fileSizeCheck(Dictionary<string, Folder> allFolders)
        {
            var result = fileSize;

            foreach (var folder in SubFolders)
            {
                result += allFolders[folder].fileSizeCheck(allFolders);
            }
            return result;
        }
    }

}