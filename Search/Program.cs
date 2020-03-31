using System;
using System.Collections.Generic;

namespace Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> filesLoaded = new List<string>();
            WordExtractor wordExtractor = new WordExtractor();
            IO iO = new IO();
            Sorting sorting = new Sorting();

            while (true)
            {
                Console.WriteLine("1:Read file. 2:Search word. 3:Save file. 0:Exit. ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("File Location exp \"C\\User\\... \"");
                        var filePath = Console.ReadLine();
                        string textString = IO.ReadFile(filePath);
                        var wordList = wordExtractor.ExtractWordsFromString(textString, filePath);
                        sorting.sortAllWords(wordExtractor.compoundedList, 0, wordExtractor.compoundedList.Count - 1);
                        foreach (var item in wordExtractor.compoundedList)
                        {
                            Console.WriteLine(item.word);
                        }
                        break;
                    case "2":
                        if (filesLoaded.Count > 0)
                        {
                            Console.Write("Type the word you want to search: ");
                            Console.ReadLine();
                            //sort and find method
                        }
                        else
                        {
                            Console.WriteLine("No file read yet");
                        }
                        break;
                    case "3":
                        //save file method
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
