using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpProjectDemo
{
    public class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            /// <summary>
            /// Recolors the console and letters for better readability on the projector screen.
            /// </summary>
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            List<Fruit> fruitsList = new List<Fruit>();

            Console.WriteLine("Please select a method for input information about fruits (via the console enter \"c\",or \"f\" from the file)...");
            /// <summary>
            /// Selects a way to input information about fruits
            /// and output the list of fruits on the console.
            /// </summary>
            string selection = Console.ReadLine().ToLower();
            switch (selection)
            {
                case "c":
                    fruitsList = InputFromConsole(5);
                    Console.Clear();
                    Console.WriteLine("\tInformation about all fruits:\n");
                    ConsoleOutputList(fruitsList);
                    break;
                case "f":
                    fruitsList = InputFromFile();
                    Console.Clear();
                    Console.WriteLine("\tInformation about all fruits from file:\n");
                    ConsoleOutputList(fruitsList);
                    break;
                default:
                    Console.WriteLine("You entered an incorrect value.");
                    break;
            }

            /// <summary>
            /// Output data for those fruits whose color is "yellow".
            /// </summary>
            Console.WriteLine("\n\tInformation about all yellow fruits:\n");

            foreach (var fruit in fruitsList)
            {
                if (fruit.Color == "yellow")
                {
                    fruit.Output();
                }
            }

            /// <summary>
            /// Sort the list of fruits by name and output the result to the file.
            /// </summary>
            fruitsList.Sort();//sort list by fruit name (IComparable<Fruit>).

            try
            {
                using (StreamWriter writeToFruitsFile = new StreamWriter(Constants.SORTED_FRUITS_FILE))
                {
                    foreach (var fruit in fruitsList)
                    {
                        writeToFruitsFile.WriteLine(fruit);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n\tThe list of all fruits was sorted and displayed in the file \"Sorted_Fruits.txt\".");

            /// <summary>
            /// Serialize fruits list to the xml-file.
            /// </summary>
            Serialize(fruitsList, Constants.SERIALIZED_FILE);

            /// <summary>
            /// Deserialize the xml-file to fruits list and output on the console.
            /// </summary>
            fruitsList = Deserialize(Constants.SERIALIZED_FILE);
            Console.WriteLine("\n\tThe List of fruits after deserialization:\n");
            ConsoleOutputList(fruitsList);

            /// <summary>
            /// Sign Out - message.
            /// </summary>
            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        /// <summary>
        /// input from console method
        /// </summary>
        /// <param name="fruitsCount">
        /// Number of fruits types.
        /// </param>
        /// <returns>
        /// List with information about fruits, entered via console.
        /// </returns>
        public static List<Fruit> InputFromConsole(int fruitsCount)
        {
            List<Fruit> fruitsList = new List<Fruit>();
            for (int i = 0; i < fruitsCount; i++)
            {
                Console.Write("Please select the type of fruit (e.g. Сitrus/Other): ");
                string choice = Console.ReadLine().ToLower();

                while (choice != "other" && choice != "citrus" && choice != "c" && choice != "o")
                {
                    Console.WriteLine("You entered an incorrect type, check it and try again.");
                    choice = Console.ReadLine().ToLower();
                }

                if (choice == "other" || choice == "o")
                {
                    Fruit fruit = new Fruit();
                    try
                    {
                        fruit.Input();
                        fruitsList.Add(fruit);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == "citrus" || choice == "c")
                {
                    Citrus citrus = new Citrus();
                    try
                    {
                        citrus.Input();
                        fruitsList.Add(citrus);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return fruitsList;
        }

        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <returns>
        /// List with information about fruits, get from the file.
        /// </returns>
        public static List<Fruit> InputFromFile()
        {
            List<Fruit> fruitsList = new List<Fruit>();
            StreamReader readFromFruitsFile = new StreamReader(Constants.INPUT_FRUIT_FILE);
            string line;

            try
            {
                while ((line = readFromFruitsFile.ReadLine()) != null)
                {
                    string[] currentLine = line.Split('/');

                    switch (currentLine.Length)
                    {
                        case 2:
                            Fruit newFruit = new Fruit();
                            newFruit.Input(currentLine);
                            fruitsList.Add(newFruit);
                            break;
                        case 3:
                            Citrus newCitrus = new Citrus();
                            newCitrus.Input(currentLine);
                            fruitsList.Add(newCitrus);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                readFromFruitsFile.Close();
            }
            return fruitsList;
        }

        /// <summary>
        /// Output list to console.
        /// </summary>
        /// <param name="fruitsList">
        /// List with information about the fruits.
        /// </param>
        /// <returns>
        /// List with information about fruits on the console.
        /// </returns>
        public static void ConsoleOutputList(List<Fruit> fruitsList)
        {
            foreach (var fruit in fruitsList)
            {
                fruit.Output();
            }
        }

        /// <summary>
        /// Serialize List<Fruit> to .xml file.
        /// </summary>
        /// <param name="fruitsList">
        /// List with information about the fruits.
        /// </param>
        /// <param name="SERIALIZED_FILE">
        /// Constant.Path to file.
        /// </param>
        /// <returns>
        /// .xml file
        /// </returns>
        public static void Serialize(List<Fruit> fruitsList, string SERIALIZED_FILE)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Fruit>));
            using (StreamWriter writeSerializedData = new StreamWriter(SERIALIZED_FILE, false))
            {
                xmlSerializer.Serialize(writeSerializedData, fruitsList);
                Console.WriteLine("\n\tThe list of fruits was serialized.");
            }
        }

        /// <summary>
        /// Deserialize from .xml file to Fils<Fruit>
        /// </summary>
        /// <param name="SERIALIZED_FILE">
        /// Constant.Path to file.
        /// </param>
        /// <returns>
        /// .xml file
        /// </returns>
        public static List<Fruit> Deserialize(string SERIALIZED_FILE)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Fruit>));
            using (StreamReader readSerializedData = new StreamReader(SERIALIZED_FILE))
            {
                return (List<Fruit>)xmlSerializer.Deserialize(readSerializedData);
            }
        }
    }
}