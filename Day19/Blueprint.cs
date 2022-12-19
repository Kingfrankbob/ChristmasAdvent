using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day19
{
    class Blueprint
    {
        public int oreBotCost;
        public int clayBotCost;
        public int obsidianBotCostOre;
        public int obsidianBotCostClay;
        public int geodeBotCostOre;
        public int geodeBotCostObsidian;
        public int totalOreCost;
        // public int totalClayCost;dotnet 
        // public int totalObsidianCost;
        public int ID;
        public Blueprint(string line)
        {
            var halves = line.Split(":");
            ID = int.Parse(halves[0].Split(" ")[1]);
            var pieces = halves[1].Split(".");
            oreBotCost = int.Parse(pieces[0].Split(" ")[5]);
            clayBotCost = int.Parse(pieces[1].Split(" ")[5]);
            obsidianBotCostOre = int.Parse(pieces[2].Split(" ")[5]);
            obsidianBotCostClay = int.Parse(pieces[2].Split(" ")[8]);
            geodeBotCostOre = int.Parse(pieces[3].Split(" ")[5]);
            geodeBotCostObsidian = int.Parse(pieces[3].Split(" ")[8]);
            var all = new[] { oreBotCost, clayBotCost, obsidianBotCostOre, geodeBotCostOre }.Max();
            totalOreCost = all;
        }

    }
}