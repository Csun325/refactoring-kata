using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Furthest : IDistance
    {
        public Pair CalculateDist(List<Pair> pairs)
        {
            var pairComparator = pairs[0];
            foreach (var pair in pairs.Where(pair => pair.Difference > pairComparator.Difference))
            {
                pairComparator = pair;
            }

            return pairComparator;
        }
    }
}