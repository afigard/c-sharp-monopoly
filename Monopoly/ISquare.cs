using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public enum SquareType
    {
        JailSquare,
        LuckSquare,
        CommunitySquare,
        StartSquare,
        NormalSquare,
        GoToJailSquare
    }

    public interface ISquare
    {
        SquareType SquareType { get; }
        int Position { get;  }

        /// <summary>
        /// Clean user display for the Square properties.
        /// </summary>
        /// <param name="is_in_jail">
        /// Is the current player in jail ? For the Jail Square.
        /// </param>
        void PrintSquare(bool is_in_jail);

        /// <summary>
        /// Executes the action related to the Square landed on.
        /// </summary>
        /// <param name="current">
        /// Current player - Enabling its movement for Luck and Community Square.
        /// </param>
        void Action(Player current);
    }
}
