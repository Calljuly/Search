using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public class Searching
    {
        /// <summary>
        /// Returns a List<Word> of found results. If no words were found, then an empty list is returned. 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="targetWord"></param>
        /// <returns></returns>
        public Dictionary<string, int> BinarySearch(List<Word> list, bool listIsSorted, string targetWord)
        {
            // Place for essential variables 
            int? targetFoundAt = null;
            bool wordFound = false;
            Dictionary<string, int> result = new Dictionary<string, int>();
            Sorting sort = new Sorting();

            if (list == null || targetWord == null || targetWord.Length < 1)
            {
                return result;
            }

            // This algoritm starts in the middle of the list and checks if the targetWord is before or after the current position. 
            // If targetWord is before, then the algorithm excludes the latter half of the list by assigning middle position to "last". 
            // Then it checks the new middle of the list and so on until it either finds the targetWord or no more parts of the list
            // can be excluded. It only works if the list is sorted. 

            int last = list.Count - 1;
            int first = 0;

            // ** Fix ** this means that this class cannot stand alone. It's dependent on a method from another class. 
            #region
            // Maybe this is what they mean that methods should be independent of one another. That one method should not be dependent on
            // a method from another custom class. Meaning that methods that are built into c# are ok because those will always be there anyway. 
            // What we want is for one class to be able to be lifted out of it's context and be inserted in another context. 
            // But what about single responsibility? It may still be that you need to lift out several of classes....
            // But then maybe the methods still shouldn't be dependant on one another?
            #endregion

            if (!listIsSorted)
            {
                sort.sortAllWords(list, 0, list.Count - 1);
            }

            while (first <= last)
            {
                int middle = (first + last) / 2;

                if (list[middle].word.Equals(targetWord))
                {
                    targetFoundAt = middle;
                    AddToDictionary(result, list[middle].file);
                    wordFound = true;
                    break;
                }
                else if (list[middle].word.CompareTo(targetWord) == 1)
                {
                    last = middle - 1;
                }
                else if (list[middle].word.CompareTo(targetWord) == -1)
                {
                    first = middle + 1;
                }
            }



            /*
             If we found the targetWord then we need to see if there are more words that fit the targetWord in the list. So we check the two words next to 
             the wprd that was found. Fter that we check the two words that are 2 steps to the left and 2 steps to the right of the first found word. 
             Then 3 steps to the left and right and so on. Every new match we find is added to "result". This continues until the algorithm stops finding matches.  
             */

            int stepLength = 1;

            while (wordFound)
            {
                wordFound = false;

                if ((targetFoundAt + stepLength) <= (list.Count - 1) && list[targetFoundAt.Value + stepLength].word.Equals(targetWord))
                {
                    AddToDictionary(result, list[targetFoundAt.Value + stepLength].file);
                    wordFound = true;
                }

                if ((targetFoundAt - stepLength) >= 0 && list[targetFoundAt.Value - stepLength].word.Equals(targetWord))
                {
                    AddToDictionary(result, list[targetFoundAt.Value - stepLength].file);
                    wordFound = true;
                }

                stepLength++;
            }

            //result.Add("fail", 28);
            return result;
        }

        private void AddToDictionary(Dictionary<string, int> dictionary, string key)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, 1);
            }
            else
            {
                dictionary[key]++;
            }
        }
    }
}
