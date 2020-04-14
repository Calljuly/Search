using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SearchLibrary
{
    public class IO
    {
        public static string ReadFile(string fileLocation)
        {
            // Code reference from https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file
            try
            {   // Open the text file using a stream reader.
                StreamReader fileReader = new StreamReader(fileLocation);
                // Read the stream to a string.
                string fileContent = fileReader.ReadToEnd();
                // Return the file Content as a string
                return fileContent.ToLower();
            }
            catch (IOException)
            {
                return "Could not read file";
            }
            catch (ArgumentNullException)
            {
                return "Could not read file";
            }
            catch (ArgumentException)
            {
                return "Could not read file";
            }
            catch (UnauthorizedAccessException)
            {
                return "You don't have access, your authority level is to low";
            }
        }


        public static string SaveFile(string fileContent, string directory, string newFileName = null)
        {
            // Code reference from https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file
            try
            {

                if (newFileName == null)
                {
                    // Save on a existing file
                    File.WriteAllText(directory, fileContent);
                    return directory;
                }
                else
                {
                    // Create a path for the new file
                    string path = "\\";
                    path = directory + path + newFileName + ".txt";
                    // Create the text file using a stream reader.
                    StreamWriter fileWriter = File.CreateText(path);
                    // Close the text file
                    fileWriter.Close();
                    // Write text string to the file
                    File.WriteAllText(path, fileContent);
                    return path;
                }
            }
            catch (IOException)
            {
                return "Could not save file.";
            }

        }
    }
}
