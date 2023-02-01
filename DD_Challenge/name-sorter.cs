using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DD_Challenge
{
    public class NameSortProgram
    {
        static void Main(string[] args)
        {
            NameSortProgram programInstance = new NameSortProgram();
            // Check that a file has been provided, and that no other errors have occured before attempting
            // to execute the program.
            try
            {
                string[] txtLines = programInstance.ReadProvidedTextFile(args);
                // Check that the provided file has data, otherwise exiting execution with an error message.
                if (txtLines.Length < 1)
                {
                    Console.WriteLine("Failed to execute. Text file must not be empty.");
                }
                else 
                {
                    List<Names> namesList = programInstance.ReadTextIntoList(txtLines);
                    IOrderedEnumerable<Names> sortedNamesList = programInstance.SortProvidedList(namesList);
                    programInstance.WriteListToConsoleAndFile(sortedNamesList);
                }
            }
            catch (FileNotFoundException) 
            {
                Console.WriteLine("Failed to execute. Text file of names must be provided.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to execute with error: {0}", e);
            }

        }

        /// <summary>
        /// Takes an enumerable list of Names, prints them to the console and writes them to a text file.
        /// Checks the length of the names to ensure no null values are printed.
        /// </summary>
        /// <param name="sortedNamesList">The list of names to be iterated upon</param>
        public void WriteListToConsoleAndFile(IOrderedEnumerable<Names> sortedNamesList)
        {
            // Create a new file to write to, overwriting any previous data.
            using StreamWriter outputFile = new StreamWriter("sorted-names-list.txt");
            // Loop through the sorted list printing the names to the screen and to the created text file.
            foreach (var person in sortedNamesList)
            {
                // Check the number of names each person has, printing only non-null names.
                if (person.MiddleFirst == null && person.MiddleSecond == null)
                {
                    Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
                    outputFile.WriteLine("{0} {1}", person.FirstName, person.LastName);
                }
                else if (person.MiddleSecond == null && !(person.MiddleFirst == null))
                {
                    Console.WriteLine("{0} {1} {2}", person.FirstName, person.MiddleFirst, person.LastName);
                    outputFile.WriteLine("{0} {1} {2}", person.FirstName, person.MiddleFirst, person.LastName);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2} {3}", person.FirstName, person.MiddleFirst, person.MiddleSecond, person.LastName);
                    outputFile.WriteLine("{0} {1} {2} {3}", person.FirstName, person.MiddleFirst, person.MiddleSecond, person.LastName);
                }
            }
        }

        /// <summary>
        /// Takes a list of type Names before ordering it alphabetically.
        /// Orders first by Last Name, then by First Name, and finally by any given middle names.
        /// </summary>
        /// <param name="namesList">List of names to be sorted</param>
        /// <returns>An alphabetically sorted list of names</returns>
        public IOrderedEnumerable<Names> SortProvidedList(List<Names> namesList)
        {
            // Sort the list of names using LINQ first by last name, then by first name, then by middle names.
            return namesList.OrderBy(x => x.LastName)
                                            .ThenBy(x => x.FirstName)
                                            .ThenBy(x => x.MiddleFirst)
                                            .ThenBy(x => x.MiddleSecond);
        }

        /// <summary>
        /// Takes an array of lines read from a text file. Splits the names by whitespace before
        /// storing the data in an instance of the Names class.
        /// Finally, the new Names instances are added to namesList.
        /// </summary>
        /// <param name="txtLines">An array of lines from a text file</param>
        /// <returns>A list of Names</returns>
        public List<Names> ReadTextIntoList(string[] txtLines)
        {
            // Create list of Names class to store read names.
            List<Names> namesList = new List<Names>();

            // Loop through each line, adding each name to class instance and then to namesList.
            foreach (var line in txtLines)
            {
                Names currentName = new Names();
                // Split each name by whitspace.
                string[] splitName = line.Split(" ");
                // Set first name of current person.
                currentName.FirstName = splitName[0];

                // Check the number of names each person has, setting names as required.
                if (splitName.Length == 2)
                {
                    currentName.LastName = splitName[1];
                }
                else if (splitName.Length == 3)
                {
                    currentName.MiddleFirst = splitName[1];
                    currentName.LastName = splitName[2];
                }
                else
                {
                    currentName.MiddleFirst = splitName[1];
                    currentName.MiddleSecond = splitName[2];
                    currentName.LastName = splitName[3];
                }

                // Add current person to list.
                namesList.Add(currentName);
            }

            return namesList;
        }

        /// <summary>
        /// Reads data line by line from a provided text file into a string array.
        /// </summary>
        /// <param name="args">The text file to be read, provided at runtime</param>
        /// <returns>An array of text lines</returns>
        public string[] ReadProvidedTextFile(string[] args)
        {
            // Get the name of the provided text file.
            string textFile = args[0];
            // Retrieve the full path of the provided text file.
            string fullPath = Path.GetFullPath(textFile);
            // Retrieve path of the working directory.
            string workingDirectory = Path.GetFullPath(Path.Combine(fullPath, @"..\..\"));
            // Set the directory to the working directory.
            Directory.SetCurrentDirectory(Path.GetDirectoryName(workingDirectory));
            // Read each line of provided text file into string array.
            string[] txtLines = File.ReadAllLines(textFile);
            return txtLines;
        }
    }
}
