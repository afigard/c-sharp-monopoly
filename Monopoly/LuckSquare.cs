using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class LuckSquare : ISquare
    {
        public SquareType SquareType => SquareType.LuckSquare;
        public int Position => this.Position;

        public void PrintSquare(bool is_in_jail)
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * *\nWhat a lucky day ! Move 5 squares fowards.\n* * * * * * * * * * * * * * * *\n");
        }

        public void Action(Player current)
        {
            current.Move(5);
            Console.WriteLine("\n* * * * * * * * * * * *\nNothing to worry about, just a Normal Square !\n* * * * * * * * * * * *\n");
        }
    }
}
