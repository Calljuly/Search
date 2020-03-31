using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Search
{
    public class IO
    {
        public static string ReadFile(string fileLocation)
        {
            // Code reference from https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-
            try
            {   // Open the text file using a stream reader.
                StreamReader sr = new StreamReader(fileLocation);
                // Read the stream to a string.
                string fileContent = sr.ReadToEnd();
                // Return the file Content as a string
                return fileContent.ToLower();
            }
            catch (IOException e)
            {
                Console.WriteLine("Could not read file");
                // Write the e.Message to console 
                Console.WriteLine(e.Message);
                // Return null if file fail to read
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }

        }


        public static void SaveFile(string fileText, string fileLocation, string filename = null)
        {
            // Code reference from https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file
            try
            {
                if (filename == null)
                {
                    // Save on a existing file
                    File.WriteAllText(fileLocation, fileText);
                }
                else
                {
                    // Create a path for the new file
                    string path = "\\";
                    path = fileLocation + path + filename + ".txt";
                    // Create the text file using a stream reader.
                    StreamWriter sw = File.CreateText(path);
                    // Close the text file
                    sw.Close();
                    // Write text string to the file
                    File.WriteAllText(path, fileText);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Could not save file. ");
                // Write the e.Message to console 
                Console.WriteLine(e.Message);
            }

        }
    }
}
