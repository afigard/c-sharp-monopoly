using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Dices
    {
        // Attributs
        private static Dices instance = null;
        private static readonly object padlock = new object();
        private int[] rolls = new int[2];
        private int sum = 0;

        public int[] Rolls { get => rolls; set => rolls = value; }

        public int Sum { get => sum; set => sum = value; }

        // Constructor
        public Dices() { }

        /// <summary>
        /// Throws dices one by one randomly with each having values between 1 and 7.
        /// Once done, sums the 2 results.
        /// </summary>
        public void ThrowDices()
        {
            Random rnd = new Random();
            int dice_1 = rnd.Next(1, 7);
            int dice_2 = rnd.Next(1, 7);
            this.rolls = new int[] { dice_1, dice_2 };
            this.sum = dice_1 + dice_2;
        }

        /// <summary>
        /// Gathers the dices' results and the sum to display it.
        /// Uses System.Sleep to mimic the real dices throwing.
        /// </summary>
        /// <returns>
        /// String describing the dices thrown.
        /// </returns>
        public string toString()
        {
            Console.WriteLine("Rowling dices...");
            System.Threading.Thread.Sleep(1000);
            return "Dice n°1 -> " + this.rolls[0] + " || Dice n°2 -> " + this.rolls[1] + "\nTotal -> "+ this.sum+ "\n";
        }

        /// <summary>
        /// Checks whether the dices are equals or not - To enable replay if double.
        /// </summary>
        /// <returns>
        /// Boolean about double-dices result.
        /// </returns>
        public bool AreEquals()
        {
            bool equals = false;
            if (this.rolls[0] == this.rolls[1]) { equals = true; }
            return equals;
        }

        public static Dices Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Dices();
                    }
                    return instance;
                }
            }
        }
    }
}
