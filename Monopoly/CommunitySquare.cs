using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CommunitySquare : ISquare
    {
        public SquareType SquareType => SquareType.CommunitySquare;
        public int Position => this.Position;

        public void PrintSquare(bool is_in_jail)
        {
            Console.WriteLine("\n* * * * * * * * * * * *\nCommunity Square ! Move 3 squares backwards.\n* * * * * * * * * * * *\n");
        }

        public void Action(Player current)
        {
            current.Move(-3);
            Console.WriteLine("\n* * * * * * * * * * * *\nNothing to worry about, just a Normal Square !\n* * * * * * * * * * * *\n");
        }
    }
}
