using Microsoft.VisualStudio.TestTools.UnitTesting;
using DD_Challenge;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace DD_Challenge.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void SortProvidedListTest_SortsValidListSuccessfully()
        {
            // Arrange
            NameSortProgram programInstance = new NameSortProgram();
            Names nameOne = new Names
            {
                FirstName = "Kyle",
                LastName = "Burch"
            };
            Names nameTwo = new Names
            {
                FirstName = "Miranda",
                MiddleFirst = "Dawn",
                LastName = "Zell"
            };
            Names nameThree = new Names
            {
                FirstName = "Miranda",
                MiddleFirst = "Brawn",
                LastName = "Zell"
            };
            Names nameFour = new Names
            {
                FirstName = "Samantha",
                MiddleFirst = "Lee",
                MiddleSecond = "Hilary",
                LastName = "Mckenna"
            };
            List<Names> testList = new List<Names>();
            testList.Add(nameOne);
            testList.Add(nameTwo);
            testList.Add(nameThree);
            testList.Add(nameFour);

            List<Names> correctOrderedList = new List<Names>();
            correctOrderedList.Add(nameOne);
            correctOrderedList.Add(nameFour);
            correctOrderedList.Add(nameThree);
            correctOrderedList.Add(nameTwo);

            // Act
            IOrderedEnumerable<Names> sortedList = programInstance.SortProvidedList(testList);

            // Assert
            Assert.IsTrue(sortedList.ElementAt(0) == correctOrderedList.ElementAt(0) &&
                sortedList.ElementAt(1) == correctOrderedList.ElementAt(1) &&
                sortedList.ElementAt(2) == correctOrderedList.ElementAt(2) &&
                sortedList.ElementAt(3) == correctOrderedList.ElementAt(3));
        }

        [TestMethod()]
        public void WriteListToConsoleAndFile_FileIsCreated()
        {
            // Arrange
            NameSortProgram programInstance = new NameSortProgram();
            Names nameOne = new Names
            {
                FirstName = "Kyle",
                LastName = "Burch"
            };
            Names nameTwo = new Names
            {
                FirstName = "Miranda",
                MiddleFirst = "Dawn",
                LastName = "Zell"
            };
            Names nameThree = new Names
            {
                FirstName = "Miranda",
                MiddleFirst = "Brawn",
                LastName = "Zell"
            };
            Names nameFour = new Names
            {
                FirstName = "Samantha",
                MiddleFirst = "Lee",
                MiddleSecond = "Hilary",
                LastName = "Mckenna"
            };

            List<Names> testList = new List<Names>();
            testList.Add(nameOne);
            testList.Add(nameTwo);
            testList.Add(nameThree);
            testList.Add(nameFour);
            IOrderedEnumerable<Names> sortedList = programInstance.SortProvidedList(testList);

            // Act
            programInstance.WriteListToConsoleAndFile(sortedList);

            // Assert
            Assert.IsTrue(File.Exists("sorted-names-list.txt") && (new FileInfo("sorted-names-list.txt").Length > 0));
        }
    }
}