using System.Collections.Generic;

namespace Algorithm
{
    public interface IDistance
    {
        public Pair CalculateDist(List<Pair> pairs);
    }
}