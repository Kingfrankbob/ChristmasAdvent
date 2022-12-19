using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day19
{
    class curState
    {
        public int ore;
        public int clay;
        public int geodes;
        public int obsidian;
        public int oreBots;
        public int clayBots;
        public int geodeBots;
        public int obsidianBots;
        public int minute;
        public curState(int ore, int clay, int geodes, int obsidian, int oreBots, int clayBots, int geodeBots, int obsidianBots, int minute)
        {
            this.ore = ore;
            this.clay = clay;
            this.geodes = geodes;
            this.obsidian = obsidian;
            this.oreBots = oreBots;
            this.clayBots = clayBots;
            this.geodeBots = geodeBots;
            this.obsidianBots = obsidianBots;
            this.minute = minute;
        }

    }
}