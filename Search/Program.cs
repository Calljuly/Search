using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using SearchLibrary;

namespace Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            WordExtractor wordExtractor = new WordExtractor();
            List<Word> compoundedList = new List<Word>();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("se-SE");
            Console.WriteLine($"This program lets you search for single words from text files. To begin your search, start by entering a file. {Environment.NewLine}");
            while (compoundedList.Count <= 0)
            {
                //Reads file from file path. Extracts words from file. Sorts words in ascending alphabetical order.
                compoundedList = LoadFileToMain(wordExtractor, compoundedList);

            }
            while (compoundedList.Count > 0)
            {
                Console.WriteLine($"To read a new file:\t\t\t\t\t Press [1] + [Enter]");
                Console.WriteLine($"To search for a word:\t\t\t\t\t Press [2] + [Enter]");
                Console.WriteLine($"To save all words in the document(s) in a sorted list:\t Press [3] + [Enter]");
                Console.WriteLine($"To print all words in the document(s):\t\t\t Press [4] + [Enter]");
                Console.WriteLine($"To exit the program:\t\t\t\t\t Press [0] + [Enter]");
                Console.Write(">: ");
                switch (Console.ReadLine())
                {
                    //Reads file from file path. Extracts words from file. Sorts words in ascending alphabetical order.
                    case "1":
                        Console.WriteLine("File Location exp \"C\\User\\... \"");
                        string filePath = Console.ReadLine();
                        string fileContent = IO.ReadFile(filePath);
                        if (fileContent == "Could not read file" || fileContent == "You don't have access, your authority level is to low")
                        {
                            Console.WriteLine(fileContent);
                        }
                        else
                        {
                            wordExtractor.ExtractWordsFromTextFile(fileContent, filePath);
                            compoundedList = wordExtractor.GetCompoundedList();
                            SearchEngine.QuickSort(compoundedList, 0, compoundedList.Count - 1);
                        }
                        break;

                    //Searches for a word selected by user input. Prints existance of word in all files to console.
                    case "2":
                        if (compoundedList.Count > 0)
                        {
                            Console.Write("Type the word you want to search: ");
                            var searchWord = Console.ReadLine().ToLower();
                            var searchedWords = SearchEngine.BinarySearch(compoundedList, true, searchWord);
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
                        if (compoundedList.Count > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Press [1] and [Enter] if you would like to save in a new file.{Environment.NewLine}Press [2] and [Enter] if you would like to create a new default file:");
                            Console.Write(">: ");
                            var saveOption = Console.ReadLine();
                            string fullFilePath;
                            string sortedFileContent = wordExtractor.BuildStringFromListOfWords(compoundedList);
                            if (saveOption == "1")
                            {
                                Console.WriteLine("Enter a location where you would like to save your file:");
                                string directoryPath = Console.ReadLine();
                                Console.WriteLine("Enter a name for your file:");
                                fullFilePath = IO.SaveFile(sortedFileContent, directoryPath, Console.ReadLine());
                                if (fullFilePath == "Could not save file.")
                                {
                                    Console.WriteLine(fullFilePath);
                                }
                                else
                                {
                                    Console.WriteLine($"Finished saving file at {fullFilePath}");
                                }
                            }
                            else if (saveOption == "2")
                            {
                                fullFilePath = IO.SaveFile(sortedFileContent, compoundedList[0].File + "new.txt");
                                if (fullFilePath == "Could not save file.")
                                {
                                    Console.WriteLine(fullFilePath);
                                }
                                else
                                {
                                    Console.WriteLine($"Finished saving file at {fullFilePath}");
                                }
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
                        if (compoundedList.Count > 10000)
                        {
                            Console.WriteLine("Too many words to print in console. To see all words, try saving to a text file instead.");
                        }
                        else if (compoundedList.Count > 0)
                        {
                            Console.WriteLine(wordExtractor.BuildStringFromListOfWords(compoundedList));
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
        /// <summary>
        /// Reads file from file path. Extracts words from file. Sorts words in ascending alphabetical order.
        /// </summary>
        /// <param name="wordExtractor"></param>
        /// <param name="compoundedList"></param>
        /// <returns></returns>
        static List<Word> LoadFileToMain(WordExtractor wordExtractor, List<Word> compoundedList)
        {
            Console.WriteLine("Enter a file from a catalogue using the following syntax: \"C\\User\\admin\\text.txt\"");
            Console.Write(">: ");
            string filePath = Console.ReadLine();
            string fileContent = IO.ReadFile(filePath);
            if (fileContent == "Could not read file" || fileContent == "You don't have access, your authority level is to low")
            {
                Console.WriteLine(fileContent);
                Console.WriteLine();
            }
            else
            {
                wordExtractor.ExtractWordsFromTextFile(fileContent, filePath);
                compoundedList = wordExtractor.GetCompoundedList();
                Engine.QuickSort(compoundedList, 0, compoundedList.Count - 1);
                Console.WriteLine($"{filePath} has been loaded.");
                Console.WriteLine();
            }
            return compoundedList;
        }
    }
}
