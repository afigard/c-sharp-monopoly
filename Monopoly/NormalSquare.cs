using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class NormalSquare : ISquare
    {
        public SquareType SquareType => SquareType.NormalSquare;
        public int Position => this.Position;

        public void PrintSquare(bool is_in_jail)
        {
            Console.WriteLine("\n* * * * * * * * * * * *\nNothing to worry about, just a Normal Square !\n* * * * * * * * * * * *\n");
        }

        public void Action(Player current) { }
    }
}
