using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class JailSquare : ISquare
    {
        public SquareType SquareType => SquareType.JailSquare;
        public int Position => this.Position;

        public void PrintSquare(bool is_in_jail)
        {
            if (is_in_jail)
            {
                Console.WriteLine("\n* * * * * * * * * * * * * * * * * *\nJail Square - Serve your sentence or Escape!\n* * * * * * * * * * * * * * * * * *\n");
            }
            else
            {
                Console.WriteLine("\n* * * * * * * * * * * * * * * * * *\nYou are in jail... But don't worry you are just visiting !\n* * * * * * * * * * * * * * * * * *\n");
            }
        }

        public void Action(Player current) { }
    }
}
