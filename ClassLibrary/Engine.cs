using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Engine
    {
        /*Quicksort method that had an pivot in the middle of the list. The list will be divied in two
         parts and get sorted.*/
        public static void QuickSort(List<Word> list, int start, int end)
        {
            int leftSideOfList = start;
            int rightSideOfList = end;
            var pivot = list[(start + end) / 2];
            Word temporaryWord;

            while (leftSideOfList <= rightSideOfList)
            {
                //Checks if value should be in Left part of list
                while (list[leftSideOfList].Value.CompareTo(pivot.Value) < 0) { leftSideOfList++; }
                //Checks if value should be in right part of list
                while (list[rightSideOfList].Value.CompareTo(pivot.Value) > 0) { rightSideOfList--; }

                //Swoops values found if they doesnt belong in their current part of list
                if (leftSideOfList <= rightSideOfList)
                {
                    temporaryWord = list[leftSideOfList];
                    list[leftSideOfList] = list[rightSideOfList];
                    list[rightSideOfList] = temporaryWord;

                    leftSideOfList++;
                    rightSideOfList--;
                }
            }
            //Chooses if we should go to the right part of the list or the left and start sorting that part
            if (start < rightSideOfList)
            {
                QuickSort(list, start, rightSideOfList);
            }
            if (leftSideOfList < end)
            {
                QuickSort(list, leftSideOfList, end);
            }
        }

        /// <summary>
        /// Returns a List<Word> of found results. If no words were found, then an empty list is returned. 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="targetWord"></param>
        /// <returns></returns>
        public static Dictionary<string, int> BinarySearch(List<Word> list, bool listIsSorted, string targetWord)
        {
            // Place for essential variables 
            Dictionary<string, int> result = new Dictionary<string, int>();

            if (list == null || targetWord == null || targetWord.Length < 1 || list.Count < 1)
            {
                return result;
            }

            int? targetIndex = null;
            bool wordFound = false;
            int last = list.Count - 1;
            int first = 0;
            string targetWordAsLower = targetWord.ToLower();

            // This algoritm starts in the middle of the list and checks if the targetWord is before or after the current position. 
            // If targetWord is before, then the algorithm excludes the latter half of the list by assigning middle position to "last". 
            // Then it checks the new middle of the list and so on until it either finds the targetWord or no more parts of the list
            // can be excluded. It only works if the list is sorted. 
                       
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
                Engine.QuickSort(list, 0, list.Count - 1);
            }

            while (first <= last)
            {
                int middle = (first + last) / 2;

                if (list[middle].Value.ToLower().Equals(targetWordAsLower))
                {
                    targetIndex = middle;
                    AddToDictionary(result, list[middle].File);
                    wordFound = true;
                    break;
                }
                else if (list[middle].Value.ToLower().CompareTo(targetWordAsLower) == 1)
                {
                    last = middle - 1;
                }
                else if (list[middle].Value.ToLower().CompareTo(targetWordAsLower) == -1)
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

                if ((targetIndex + stepLength) <= (list.Count - 1) && list[targetIndex.Value + stepLength].Value.ToLower().Equals(targetWordAsLower))
                {
                    AddToDictionary(result, list[targetIndex.Value + stepLength].File);
                    wordFound = true;
                }

                if ((targetIndex - stepLength) >= 0 && list[targetIndex.Value - stepLength].Value.ToLower().Equals(targetWordAsLower))
                {
                    AddToDictionary(result, list[targetIndex.Value - stepLength].File);
                    wordFound = true;
                }

                stepLength++;
            }

            //result.Add("fail", 28);
            return result;
        }

        private static void AddToDictionary(Dictionary<string, int> dictionary, string key)
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
