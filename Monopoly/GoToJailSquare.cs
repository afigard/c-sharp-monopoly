using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class GoToJailSquare : ISquare
    {
        public SquareType SquareType => SquareType.GoToJailSquare;
        public int Position => this.Position;

        public void PrintSquare(bool is_in_jail)
        {
            Console.WriteLine("\n* * * * * * * * * * * * * * * *\nYou are going to jail !\n* * * * * * * * * * * * * * * *\n");
        }

        public void Action(Player current) { }
    }
}
