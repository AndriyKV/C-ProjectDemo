using System;
using NUnit.Framework;
using CSharpProjectDemo;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace CSharpProjectDemoTest
{
    [TestFixture]
    public class CitrusTests
    {
        [Test]
        public void Output_StringCitrusToConsole_AreEqualToExpected()
        {
            //Arrange
            Citrus citrus = new Citrus("pineapple", "yellow", 53);
            string expected = "The name of the fruit is pineapple, and its color is yellow. The content of vitamin C - 53mg.\r\n";
            string actual;

            //Act            
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);
                Console.SetError(writer);
                citrus.Output();
                actual = writer.ToString();
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
