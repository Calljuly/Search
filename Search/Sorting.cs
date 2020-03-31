using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public class Sorting
    {
        
        public void sortAllWords(List<Word> listOfWords, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                var q = Partition(listOfWords, startIndex, endIndex);
                sortAllWords(listOfWords, startIndex, q - 1);
                sortAllWords(listOfWords, q + 1, endIndex);
            }
        }
        public int Partition(List<Word> listOfWords, int startIndex, int endIndex)
        {
            Word pivot = listOfWords[endIndex];
            Word temporary;
            Word temporaryTwo;
            int indexToGoThrowList = startIndex;

            for (int x = startIndex; x < endIndex; x++)
            {
                if (listOfWords[x].word.CompareTo(pivot.word) < 0)
                {
                    if (listOfWords[x].word != pivot.word) 
                    {
                        temporary = listOfWords[x];
                        listOfWords[x] = listOfWords[indexToGoThrowList];
                        listOfWords[indexToGoThrowList] = temporary;
                        indexToGoThrowList++;
                    }
                }
            }
            temporaryTwo = listOfWords[indexToGoThrowList];
            listOfWords[indexToGoThrowList] = listOfWords[endIndex];
            listOfWords[endIndex] = temporaryTwo;
            return indexToGoThrowList;
        }
        /*Quicksort method that had an pivot in the middle of the list. The list will be divied in two
         parts and get sorted.*/
        public static void QuickSort(List<Word> list, int start, int end)
        {
            int leftSideOfList = start;
            int rightSideOfList = end;
            var pivot = list[(start + end) / 2];
            Word temporary;

            while (leftSideOfList <= rightSideOfList)
            {
                //Checks if value should be in Left part of list
                while (list[leftSideOfList].word.CompareTo(pivot.word) < 0) { leftSideOfList++; }
                //Checks if value should be in right part of list
                while (list[rightSideOfList].word.CompareTo(pivot.word) > 0) { rightSideOfList--; }
                
                //Swoops values found if they doesnt belong in their current part of list
                if (leftSideOfList <= rightSideOfList)
                {
                    temporary = list[leftSideOfList];
                    list[leftSideOfList] = list[rightSideOfList];
                    list[rightSideOfList] = temporary;

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
    }
}
