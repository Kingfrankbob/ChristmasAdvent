using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day13
{
    class SpecialSorter : IComparer<string>
    {
        public int Compare(string? left, string? right)
        {
            if (left == null || right == null)
                throw new InvalidOperationException();

            if (left[0] == '[' && right[0] != '[')
                return Compare(left, $"[{right}]");

            if (left[0] != '[' && right[0] == '[')
                return Compare($"[{left}]", right);

            if (left[0] != '[' && right[0] != '[')
            {
                var leftInt = int.Parse(left);
                var rightInt = int.Parse(right);

                return leftInt < rightInt ? -1 : (leftInt > rightInt ? 1 : 0);
            }

            var leftItems = Unwrap(left[1..(left.Length - 1)]);
            var rightItems = Unwrap(right[1..(right.Length - 1)]);

            for (var idx = 0; ; ++idx)
            {
                if (leftItems.Length == idx)
                    return rightItems.Length == idx ? 0 : -1;
                if (rightItems.Length == idx)
                    return 1;

                var itemResult = Compare(leftItems[idx], rightItems[idx]);
                if (itemResult != 0)
                    return itemResult;
            }
        }

        string[] Unwrap(string value)
        {
            var result = new List<string>();

            for (var start = 0; start < value.Length; ++start)
            {
                var innerCount = 0;
                var end = start;

                while (true)
                {
                    if (end == value.Length || (value[end] == ',' && innerCount == 0))
                    {
                        result.Add(value[start..end]);
                        start = end;
                        break;
                    }

                    if (value[end] == '[')
                        innerCount++;

                    if (value[end] == ']')
                        innerCount--;

                    end++;
                }
            }

            return result.ToArray();
        }
    }
}
