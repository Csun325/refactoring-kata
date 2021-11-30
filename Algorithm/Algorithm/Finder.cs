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
            // changed var name from tr to pairs
            var pairs = new List<Pair>();

            // looping through all the people and finding the difference
            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    // changed var name from r to currentPair
                    var currentPair = new Pair();
                    
                    // sorting by birthdates, lowest to highest
                    if(_people[i].BirthDate < _people[j].BirthDate)
                    {
                        currentPair.P1 = _people[i];
                        currentPair.P2 = _people[j];
                    }
                    else
                    {
                        currentPair.P1 = _people[j];
                        currentPair.P2 = _people[i];
                    }
                    // the difference between the two birthdates
                    currentPair.Difference = currentPair.P2.BirthDate - currentPair.P1.BirthDate;
                    pairs.Add(currentPair);
                }
            }

            // if there is only once set of difference added (i.e. only two people)
            // returns pair as is
            if(pairs.Count < 1)
            {
                return new Pair();
            }

            Pair answer = pairs[0];
            foreach(var result in pairs)
            {
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
    }
}