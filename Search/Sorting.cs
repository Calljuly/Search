using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public class Sorting
    {
        List<Word> listOfWord = new List<Word>();

        public void sortAllWords(List<Word> a, int start, int end)
        {
            if (start < end)
            {
                var q = Parti(a, start, end);
                sortAllWords(a, start, q - 1);
                sortAllWords(a, q + 1, end);
            }
        }
        public int Parti(List<Word> a, int start, int end)
        {
            Word pivot = a[end];
            Word temporary;
            Word temporaryTwo;
            int i = start;

            for (int x = start; x < end; x++)
            {
                if (a[x].word.CompareTo(pivot.word) < 0)
                {
                    temporary = a[x];
                    a[x] = a[i];
                    a[i] = temporary;
                    i++;
                }
            }
            temporaryTwo = a[i];
            a[i] = a[end];
            a[end] = temporaryTwo;
            return i;
        }

    }
}
