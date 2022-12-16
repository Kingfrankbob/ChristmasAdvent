using System.Text.RegularExpressions;

namespace Day16
{
    class pressRelease
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string file = @"Input.txt";
            Console.WriteLine("File Exists? " + File.Exists(file));
            var regex = new Regex("Valve ([A-Z][A-Z]) has flow rate=(\\d+); tunnels? leads? to valves? (.*)");
            var valveList = (from line in File.ReadAllLines("input.txt")
                             where !string.IsNullOrWhiteSpace(line)
                             let match = regex.Match(line)
                             select new Valve(match.Groups[1].Value, long.Parse(match.Groups[2].Value), match.Groups[3].Value.Split(",").Select(x => x.Trim()).ToArray())).ToDictionary(v => v.Name, v => v);

            var flowValves = new List<Valve>();
            var pathCostCache = new Dictionary<(string from, string to), int>();

            // foreach (var line in lines)
            // {
            //     var spaceSplit = line.Split(' ');
            //     var checkValve = new Valve(spaceSplit[1], int.Parse(spaceSplit[4].Split('=')[1].Trim(';')));
            //     var valveCheck = line.Split("valves");
            //     var valveAmount = valveCheck[1].Split(" ");
            //     var valveTotal = valveAmount.Length;
            //     for (int i = 0; i < valveTotal; i++)
            //     {
            //         var valveName = valveAmount[i].Trim(',');
            //         var valve = new Valve(valveName, 0);
            //         checkValve.AddConnection(valve);
            //     }

            //     flowValves.Add(checkValve);
            // }


            int? PathCost(string from, string to, HashSet<string>? visited = null)
            {
                if (pathCostCache.TryGetValue((from, to), out var cached))
                    return cached;

                int? best = null;
                visited ??= new HashSet<string>();

                if (from == to)
                    return null;

                visited.Add(from);

                var fromValve = valveList[from];

                if (fromValve.Connections.Contains(to))
                    best = 1;
                else
                    foreach (var neighbor in fromValve.Connections)
                    {
                        if (!visited.Contains(neighbor))
                        {
                            var possibility = PathCost(neighbor, to, visited);
                            if (possibility != null)
                                if (best == null || possibility.Value + 1 < best.Value)
                                    best = possibility.Value + 1;
                        }
                    }

                visited.Remove(from);

                if (best == null)
                    return null;

                pathCostCache[(from, to)] = best.Value;
                return best.Value;
            }

            long OptimumPressure(
                HashSet<string> openableValves, Valve valve, long pressure = 0L, int minute = 0)
            {
                if (minute == 30 || openableValves.Count == 0)
                    return pressure;

                var best = pressure;
                var minutesLeft = 30 - minute;

                foreach (var targetValveId in openableValves.ToArray())
                {
                    var targetValve = valveList[targetValveId];
                    var targetPathCost = PathCost(valve.Name, targetValveId);

                    if (targetPathCost != null && minutesLeft > targetPathCost.Value)
                    {
                        openableValves.Remove(targetValveId);

                        var newMinute = minute + targetPathCost.Value + 1;
                        var possibility = OptimumPressure(
                            openableValves,
                            targetValve,
                            pressure + (30 - newMinute) * targetValve.Flow,
                            newMinute
                        );

                        openableValves.Add(targetValveId);

                        if (possibility > best)
                            best = possibility;
                    }
                }
                return best;
            }


            var openableValves = valveList.Where(v => v.Value.Flow > 0).Select(v => v.Key).ToHashSet();
            var result = OptimumPressure(openableValves, valveList["AA"]);

            System.Console.WriteLine("Result for part 1: " + result);
            System.Console.WriteLine("Not doing part to, it is more work than preferred. Plus part one is very similar to Brad Wilsons, like exactly the same. Frickin github copilot xdddd!!");


        }



    }

}