using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day16
{
    class Valve
    {
        public string Name { get; set; }
        public long Flow { get; set; }
        public string[] Connections { get; set; }
        public Valve(string name, long flow, string[] connections)
        {
            Name = name;
            Flow = flow;
            Connections = connections;
        }

    }
}