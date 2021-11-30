using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        // renamed field from _p to _people
        private readonly List<Profile> _people;

        public Finder(List<Profile> people)
        {
            _people = people;
        }

        // what are we actually trying to find?
        // Find does mainly two things:
        // sorts people in list by birthdates, lowest to highest
        // returns a pair of people depending on enum

        public Pair Find(Distance dist)
        {
            var pairs = OrderByBirthdate();

            // if there is only once set of difference added (i.e. only two people)
            // returns pair as is
            if(pairs.Count < 1) return new Pair();
            
            var answer = pairs[0];
            foreach(var result in pairs)
            {
                //switch statement violates open/close principle
                // each enum can be a class
                // both classes implements an interface
                switch(dist)
                {
                    // getting smallest difference pair value 
                    case Distance.Closest:
                        if(result.Difference < answer.Difference)
                        {
                            answer = result;
                        }
                        break;
                    
                    // getting greatest difference pair value
                    case Distance.Furthest:
                        if(result.Difference > answer.Difference)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }

        //extracted helper methods
        
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