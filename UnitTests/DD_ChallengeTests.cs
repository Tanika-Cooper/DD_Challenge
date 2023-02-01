using Microsoft.VisualStudio.TestTools.UnitTesting;
using DD_Challenge;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class NameSorterTests
    {
        [TestMethod]
        public void SortProvidedList_SortsValidList()
        {
            // Arrange
            List<Names> testNames = new List<Names>();
            Names nameOne = new Names 
            {
                FirstName = "Kyle",
                LastName = "Zell"
            };
            Names nameTwo = new Names
            {
                FirstName = "Miranda",
                MiddleFirst = "Dawn",
                LastName = "Ares"
            };
            Names nameThree = new Names
            {
                FirstName = "Miranda",
                MiddleFirst = "Brawn",
                LastName = "Ares"
            };
            Names nameFour = new Names
            {
                FirstName = "Zeri",
                MiddleFirst = "Avery",
                MiddleSecond = "John",
                LastName = "Willow"
            };
            testNames.Add(nameOne);
            testNames.Add(nameTwo);
            testNames.Add(nameThree);
            testNames.Add(nameFour);

            // Act
            SortProvidedList

            // Assert
        }
    }
}
