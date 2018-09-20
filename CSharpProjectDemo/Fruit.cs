using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpProjectDemo
{
    /// <summary>
    /// Fruit class containing methods for input and output data.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Citrus))]//For serialization (reference to subsidiary class).
    public class Fruit : IComparable<Fruit>//Allows to use sorting.
    {
        /// <summary>
        /// Store for the Name & Color property.
        /// </summary>
        string name;
        string color;

        ///<summary>
        ///Gets or sets the name.
        ///</summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.ToLower();
            }
        }

        ///<summary>
        ///Gets ToLower value or sets the color.
        ///</summary>
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value.ToLower();
            }
        }

        /// <summary>
        /// Default constructor without any parameters.
        /// </summary>
        public Fruit()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">
        /// Name of fruit
        /// </param>
        /// <param name="color">
        /// Color of fruit
        /// </param>
        public Fruit(string name, string color)
        {
            Name = name;
            Color = color;
        }

        /// <summary>
        /// Gets information about fruit from console.
        /// </summary>
        public virtual void Input()
        {
            Console.Write("Please enter the fruit... \nname: ");
            Name = Console.ReadLine();
            Console.Write("color: ");
            Color = Console.ReadLine();
        }

        /// <summary>
        /// Displays information about the fruit on the console.
        /// </summary>
        /// <returns>
        /// Information about the fruit.
        /// </returns>
        public virtual void Output()
        {
            Console.WriteLine(this);
        }

        /// <summary>
        /// Puts information about fruit to array.
        /// </summary>
        /// <param name="newFruit">
        /// An array of fruit data.
        /// </param>
        public virtual void Input(string[] newFruit)
        {
            Name = newFruit[0];
            Color = newFruit[1];
        }

        /// <summary>
        /// Writes the information about fruit to a file.
        /// </summary>
        /// <param name="newFile">
        /// Path to file
        /// </param>
        /// <returns>
        /// File with information.
        /// </returns>
        public virtual void Output(string newFile)
        {
            using (StreamWriter writeToFile = new StreamWriter(newFile))
            {
                writeToFile.WriteLine(ToString());
            }
        }

        /// <summary>
        /// Returns string with information about the fruit fruit.
        /// </summary>
        /// <returns>
        /// String.
        /// </returns>
        public override string ToString()
        {
            return string.Format("The name of the fruit is {0}, and its color is {1}.", Name, Color);
        }

        /// <summary>
        /// Compare the names of fruits.
        /// </summary>
        /// <param name="other">
        /// The name of the fruit with which one is compared.
        /// </param>
        public int CompareTo(Fruit other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
