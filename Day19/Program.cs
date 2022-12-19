using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day19
{
    class geodeCracker
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));

            if (!File.Exists(file))
                return;

            var lines = File.ReadAllLines(file);
            var blueprintList = new List<Blueprint>();
            foreach (var line in lines)
            {
                blueprintList.Add(new Blueprint(line));
            }


            foreach (var blue in blueprintList)
            {
                var alreadyChecked = new HashSet<curState>();
                var needChecked = new Stack<curState>();
                var bestTotal = 0;

                var newPush = new curState(0, 0, 0, 0, 0, 0, 0, 0, 24);
                newPush.oreBots++;

                needChecked.Push(newPush);

                while (needChecked.TryPop(out var currentState))
                {

                    if (currentState.minute == 0)
                    {
                        bestTotal = Math.Max(bestTotal, currentState.geodes);
                        continue;
                    }


                    currentState.oreBots = Math.Min(currentState.oreBots, blue.totalOreCost);
                    currentState.ore = Math.Min(currentState.ore, currentState.minute * blue.totalOreCost - currentState.oreBots * (currentState.minute - 1));
                    currentState.clayBots = Math.Min(currentState.clayBots, blue.obsidianBotCostClay);
                    currentState.clay = Math.Min(currentState.clay, currentState.minute * blue.obsidianBotCostClay - currentState.clayBots * (currentState.minute - 1));
                    currentState.obsidianBots = Math.Min(currentState.obsidianBots, blue.geodeBotCostObsidian);
                    currentState.obsidian = Math.Min(currentState.obsidian, currentState.minute * blue.geodeBotCostObsidian - currentState.obsidianBots * (currentState.minute - 1));

                    if (alreadyChecked.Contains(currentState))
                        continue;

                    alreadyChecked.Add(currentState);

                    if (currentState.ore >= blue.geodeBotCostOre && currentState.obsidian >= blue.geodeBotCostObsidian)
                    {
                        needChecked.Push(new curState(currentState.ore + currentState.oreBots - blue.geodeBotCostOre,
                         currentState.clay + currentState.clayBots,
                          currentState.geodes + currentState.geodeBots,
                           currentState.obsidian + currentState.obsidianBots - blue.geodeBotCostObsidian,
                            currentState.oreBots, currentState.clayBots,
                             currentState.geodeBots + 1,
                              currentState.obsidianBots,
                               currentState.minute - 1));
                    }
                    if (currentState.ore >= blue.obsidianBotCostOre && currentState.clay >= blue.obsidianBotCostClay)
                    {
                        needChecked.Push(new curState(currentState.ore + currentState.oreBots - blue.obsidianBotCostOre, currentState.clay + currentState.clayBots - blue.obsidianBotCostClay, currentState.geodes + currentState.geodeBots, currentState.obsidian + currentState.obsidianBots, currentState.oreBots, currentState.clayBots, currentState.geodeBots, currentState.obsidianBots + 1, currentState.minute - 1));
                    }
                    if (currentState.ore >= blue.clayBotCost)
                    {
                        needChecked.Push(new curState(currentState.ore + currentState.oreBots - blue.clayBotCost, currentState.clay + currentState.clayBots, currentState.geodes + currentState.geodeBots, currentState.obsidian + currentState.obsidianBots, currentState.oreBots, currentState.clayBots + 1, currentState.geodeBots, currentState.obsidianBots, currentState.minute - 1));
                    }
                    if (currentState.ore >= blue.oreBotCost)
                    {
                        needChecked.Push(new curState(currentState.ore + currentState.oreBots - blue.oreBotCost, currentState.clay + currentState.clayBots, currentState.geodes + currentState.geodeBots, currentState.obsidian + currentState.obsidianBots, currentState.oreBots + 1, currentState.clayBots, currentState.geodeBots, currentState.obsidianBots, currentState.minute - 1));
                    }
                    needChecked.Push(new curState(currentState.ore + currentState.oreBots,
                         currentState.clay + currentState.clayBots,
                          currentState.geodes + currentState.geodeBots,
                           currentState.obsidian + currentState.obsidianBots,
                            currentState.oreBots, currentState.clayBots,
                             currentState.geodeBots,
                              currentState.obsidianBots,
                               currentState.minute - 1));

                    // System.Console.WriteLine("Minute: " + currentState.minute + " Ore: " + currentState.ore + " Clay: " + currentState.clay + " Geodes: " + currentState.geodes + " Obsidian: " + currentState.obsidian + " OreBots: " + currentState.oreBots + " ClayBots: " + currentState.clayBots + " GeodeBots: " + currentState.geodeBots + " ObsidianBots: " + currentState.obsidianBots);


                }
                System.Console.WriteLine("Blueprint: " + blue.ID + " Geodes: " + bestTotal);
            }


        }


    }

}
