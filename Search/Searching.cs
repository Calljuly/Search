using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public class Searching
    {
        public List<Word> BinarySearch(List<Word> list, string word)
        {
            int last = list.Count -1;
            int first = 0;
            int foundAt = 0; // **FIX**
            List<Word> result = new List<Word>();

            if (word == null || word.Length < 1)
            {
                return result;
            }
            

            while (first <= last)
            {
                int middle = (first + last) / 2;

                if (list[middle].word.Equals(word))
                {
                    foundAt = middle;
                    result.Add(list[middle]);
                    break;
                }
                else if (list[middle].word.CompareTo(word) == 1)
                {
                    last = middle - 1; 
                }
                else if (list[middle].word.CompareTo(word) == -1)
                {
                    first = middle + 1;
                }
            }

            int stepLength = 1;
            bool found = true;

            while (found)
            {
                found = false;

                if ((foundAt + stepLength) <= (list.Count - 1) && list[foundAt + stepLength].word.Equals(word))
                {
                    result.Add(list[foundAt + stepLength]);
                    found = true;
                }
                
                if ((foundAt - stepLength) >= 0 && list[foundAt - stepLength].word.Equals(word))
                {
                    result.Add(list[foundAt - stepLength]);
                    found = true;
                }

                stepLength++;
            }
        
            return result;
        }
    }
}
