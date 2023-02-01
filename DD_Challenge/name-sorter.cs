using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DD_Challenge
{
    class Program
    {
        static void Main(string[] args)
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

            // Sort the list of names using LINQ first by last name, then by first name, then by middle names.
            var sortedNamesList = namesList.OrderBy(x => x.LastName)
                                            .ThenBy(x => x.FirstName)
                                            .ThenBy(x => x.MiddleFirst)
                                            .ThenBy(x => x.MiddleSecond);

            using StreamWriter outputFile = new StreamWriter("sorted-names-list.txt");
            // Loop through the sorted list printing the names to the screen.
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
    }
}
