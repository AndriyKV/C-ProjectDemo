using System;
using NUnit.Framework;
using CSharpProjectDemo;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace CSharpProjectDemoTest
{
    [TestFixture]
    public class ProgramMetodsTests
    {
        //[Test]
        //public void SerializationTest()
        //{
        //    XmlDocument serializedFile = new XmlDocument();
        //    serializedFile.Load(Constants.DIRECTORY_FOR_TESTS + Constants.SERIALIZED_FILE);
        //    XmlNodeList list = serializedFile.GetElementsByTagName("Fruit");
        //    string str = "Fruit: ";
        //    foreach (XmlNode current in list)
        //    {
        //        foreach (XmlElement currentFruit in current.ChildNodes)
        //        {
        //            str += (currentFruit.InnerText);
        //        }

        //    }
        //}
    }
}
