using System;
using System.Collections.Generic;

namespace Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<List<Word>> filesLoaded = new List<List<Word>>();
            WordExtractor wordExtractor = new WordExtractor();
            IO iO = new IO();
            Sorting sorting = new Sorting();
            Searching searching = new Searching();

            while (true)
            {
                Console.WriteLine("1:Read file. 2:Search word. 3:Save file. 0:Exit. ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("File Location exp \"C\\User\\... \"");
                        string filePath = Console.ReadLine();
                        string textString = IO.ReadFile(filePath);
                        var wordList = wordExtractor.ExtractWordsFromString(textString, filePath);
                        sorting.sortAllWords(wordExtractor.compoundedList, 0, wordExtractor.compoundedList.Count - 1);
                        break;
                    case "2":
                        if (wordExtractor.compoundedList.Count > 0)
                        {
                            Console.Write("Type the word you want to search: ");
                            var searchWord = Console.ReadLine();
                            //sort and find method
                        }
                        else
                        {
                            Console.WriteLine("No file read yet");
                        }
                        break;
                    case "3":
                        IO.SaveFile(wordExtractor.compoundedList, @"C:\Users\Patrik\Desktop" , "yes");
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong input pleas try again.");
                        break;
                }
            }

        }
    }
}
