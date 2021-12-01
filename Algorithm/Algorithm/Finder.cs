using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    /*
     * Crucial changes:
     * Instead of relying on enum, added extra interface to constructor
     * The Find method no longer needs the Distance enum
     */
    public class Finder 
    {
        private readonly List<Person> _people;
        private readonly IDistance _distanceType;

        public Finder(List<Person> people, IDistance distanceType)
        {
            _people = people;
            _distanceType = distanceType;
        }
        
        public Pair FindPair()
        {
            var pairs = OrderByBirthdate();
            return !pairs.Any() ? new Pair() : _distanceType.CalculateDist(pairs);
        }

        //extracted helper methods below
        
        private List<Pair> OrderByBirthdate()
        {
            var pairs = new List<Pair>();
            for (var i = 0; i < _people.Count; i++)
            {
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var currentPair = SortLowToHigh(i, j);
                    currentPair.Difference = currentPair.P2.BirthDate - currentPair.P1.BirthDate;
                    
                    pairs.Add(currentPair);
                }
            }
            return pairs;
        }

        private Pair SortLowToHigh(int index1, int index2)
        {
            var currentPair = new Pair();
            if (_people[index1].BirthDate < _people[index2].BirthDate)
            {
                currentPair.P1 = _people[index1];
                currentPair.P2 = _people[index2]; 
            }
            else
            {
                currentPair.P1 = _people[index2];
                currentPair.P2 = _people[index1];
            }
            return currentPair;
        }

    }
}