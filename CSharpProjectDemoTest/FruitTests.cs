using System;
using NUnit.Framework;
using CSharpProjectDemo;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace CSharpProjectDemoTest
{
    [TestFixture]
    public class FruitTests
    {
        /// <summary>
        /// Return standart console Input, Ouptur and Erroroutput after evry test run
        /// </summary>
        [TearDown]
        public void AfterEveryTest()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(), Console.InputEncoding));
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding));
            Console.SetError(Console.Error);
        }

        [Test]
        public void InitializationTest()
        {
            //Arrange
            string expectedName = "pineapple";
            string expectedColor = "yellow";

            //Act
            Fruit friut = new Fruit(expectedName, expectedColor);

            //Assert
            Assert.AreEqual(expectedName, friut.Name);
            Assert.AreEqual(expectedColor, friut.Color);
        }

        [Test]
        public void Input_NameAndColor_AreEqualToExpected()//MethodName_StateUnderTest_ExpectedBehavior
        {
            //Arrange
            string expectedName = "pineapple";
            string expectedColor = "yellow";

            //Act
            Fruit fruit = new Fruit();
            fruit.Input(new string[] { "pineapple", "yellow" });

            //Assert
            Assert.AreEqual(fruit.Name, expectedName);
            Assert.AreEqual(fruit.Color, expectedColor);
        }

        #region ToString other way
        //[Test]
        //public void ToStringTest()
        //{
        //    //Arrange
        //    string expected = "The name of the fruit is pineapple, and its color is yellow.";

        //    //Act
        //    Fruit fruit = new Fruit("pineapple", "yellow");
        //    string actual = fruit.ToString();

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //} 
        #endregion
        [TestCase("grape", "purple")]
        [TestCase("pineapple", "yellow")]
        public void ToString_StringFruit_AreEqualToExpected(string name, string color)
        {
            //Arrange
            Fruit fruit = new Fruit(name, color);

            //Act
            string actual = fruit.ToString();
            string expected = string.Format("The name of the fruit is {0}, and its color is {1}.", name, color);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("grape", "purple")]
        public void Input_FromFile_AreEqual(string name, string color)
        {
            //Arrange
            Fruit fruit = new Fruit();

            //Act
            StreamReader readFromFile = new StreamReader(Constants.DIRECTORY_FOR_TESTS + Constants.TEST_FRUIT_FILE);
            try
            {
                fruit.Input(readFromFile.ReadLine().Split('/'));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                readFromFile.Close();
            }

            //Assert
            Assert.AreEqual(fruit.Name, name);
            Assert.AreEqual(fruit.Color, color);
        }

        [TestCase("grape", "red", "pineapple", "yellow", "first")]
        [TestCase("grape", "purple", "grape", "purple", "equal")]
        [TestCase("pineapple", "yellow", "grape", "purple", "second")]
        public void CompareTo_CompareByValue_True(string fruitName, string fruitColor, string otherName, string otherColor, int expected)
        {
            //Arrange
            Fruit currentFruit = new Fruit(fruitName, fruitColor);
            Fruit otherFruit = new Fruit(otherName, otherColor);

            //Act
            int actual = currentFruit.CompareTo(otherFruit);

            //Accert
            Assert.AreEqual(expected, actual);
        }
    }
}

