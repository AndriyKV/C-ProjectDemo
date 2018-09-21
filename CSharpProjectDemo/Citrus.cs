using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjectDemo
{
    /// <summary>
    /// Subsidiary Citrus class adding new field and overriding methods for input and output data.
    /// </summary>
    [Serializable]//For serialization
    public class Citrus : Fruit
    {
        /// <summary>
        /// Store for the vitaminC-property.
        /// </summary>
        private double vitaminC;

        ///<summary>
        ///Gets or sets the content of vitamin C.
        ///</summary>
        public double VitaminC
        {
            get
            {
                return vitaminC;
            }
            set
            {
                vitaminC = value;
            }
        }

        /// <summary>
        /// Default constructor without any parameters.
        /// </summary>
        public Citrus()
        {
        }

        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="name">
        /// Name of citrus
        /// </param>
        /// <param name="color">
        /// Color of citrus
        /// </param>
        /// <param name="vitamineC">
        /// The content of vitamin C in milligrams
        /// </param>
        public Citrus(string Name, string Color, double VitaminC) : base(Name, Color)
        {
            this.VitaminC = VitaminC;
        }

        /// <summary>
        /// Gets information about citrus from console and overrides the virtual method.
        /// </summary>
        public override void Input()
        {
            base.Input();
            Console.Write("vitamin C in milligrams: ");
            try
            {
                VitaminC = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                VitaminC = 0;
            }
        }

        /// <summary>
        /// Overrides the virtual method.
        /// </summary>
        /// <returns>
        /// Information about the fruit.
        /// </returns>
        public override void Output()
        {
            Console.WriteLine(this);
        }

        /// <summary>
        /// Overrides the virtual method.
        /// </summary>
        public override void Input(string[] newFruit)
        {
            base.Input(newFruit);
            VitaminC = Convert.ToDouble(newFruit[2].Replace(".", ","));
        }

        /// <summary>
        /// Adds the information about Citrus to a file.
        /// </summary>
        /// <param name="newFile">
        /// Path to file
        /// </param>
        /// <returns>
        /// File with information.
        /// </returns>
        public override void Output(string newFile)
        {
            using (StreamWriter file = new StreamWriter(newFile))
            {
                file.WriteLine(this);
            }
        }

        /// <summary>
        /// Overrides the main method.
        /// </summary>
        /// <returns>
        /// String.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} The content of vitamin C - {1}mg.", base.ToString(), VitaminC);
        }
    }
}
