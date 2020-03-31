using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public class Sorting
    {
        //Quick sort metod för att sortera varje ord som kommer in. Det är en rekursiv metod som anropar 
        // och tar svaret från den metoden och anropar sig själv med som parameter.
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
    }
}
