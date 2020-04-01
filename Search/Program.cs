﻿using System;
using System.Collections.Generic;
using ClassLibrary;

namespace Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            WordExtractor wordExtractor = new WordExtractor();

            while (true)
            {
                Console.WriteLine("1:Read file. 2:Search word. 3:Save file. 4:Print word list to console. 0:Exit. ");
                switch (Console.ReadLine())
                {
                    //Reads file from file path. Extracts words from file. Sorts words in ascending alphabetical order.
                    case "1":
                        Console.WriteLine("File Location exp \"C\\User\\... \"");
                        string filePath = Console.ReadLine();
                        string fileContent = IO.ReadFile(filePath);
                        wordExtractor.ExtractWordsFromTextFile(fileContent, filePath);
                        Engine.QuickSort(wordExtractor.GetCompoundedList(), 0, wordExtractor.GetCompoundedList().Count - 1);
                        break;

                    //Searches for a word selected by user input. Prints existance of word in all files to console.
                    case "2":
                        if (wordExtractor.GetCompoundedList().Count > 0)
                        {
                            Console.Write("Type the word you want to search: ");
                            var searchWord = Console.ReadLine().ToLower();
                            var searchedWords = Engine.BinarySearch(wordExtractor.GetCompoundedList(), true, searchWord);
                            foreach (var item in searchedWords)
                            {
                                Console.WriteLine($"{searchWord} exists {item.Value} times in {item.Key}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No file read yet");
                        }
                        break;

                    //Creates a new .txt-file. Saves sorted list of all words in all files read to this file.
                    case "3":
                        if (wordExtractor.GetCompoundedList().Count > 0)
                        {
                            Console.WriteLine(@"Press '1' if you would like to save in a new file. Press '2' if you would like to create a new default file:");
                            var saveOption = Console.ReadLine();
                            string FullFilePath;
                            string sortedFileContent = wordExtractor.BuildStringFromListOfWords(wordExtractor.GetCompoundedList());
                            if (saveOption == "1")
                            {
                                Console.WriteLine("Enter a location where you would like to save your file:");
                                string directoryPath = Console.ReadLine();
                                Console.WriteLine("Enter a name for your file:");
                                FullFilePath = IO.SaveFile(sortedFileContent, directoryPath, Console.ReadLine());
                                Console.WriteLine($"Finished saving file at {FullFilePath}");
                            }
                            else if (saveOption == "2")
                            {
                                FullFilePath = IO.SaveFile(sortedFileContent, wordExtractor.GetCompoundedList()[0].file + "new.txt");
                                Console.WriteLine($"Finished saving file at {FullFilePath}");
                            }
                            else
                            {
                                Console.WriteLine("Illegal command!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No file read yet");
                        }
                        break;

                    //Prints the sorted list to console.
                    case "4":
                        if (wordExtractor.GetCompoundedList().Count > 0)
                        {
                            Console.WriteLine(wordExtractor.BuildStringFromListOfWords(wordExtractor.GetCompoundedList()));
                        }
                        else
                        {
                            Console.WriteLine("No file read yet");
                        }

                        break;

                    //Exits the program.
                    case "0":
                        Environment.Exit(0);
                        break;

                    //Prints a message to the console when input is erroneous.
                    default:
                        Console.WriteLine("Wrong input please try again.");
                        break;
                }
            }

        }
    }
}
