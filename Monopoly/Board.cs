using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Board
    {
        // Attributes
        private static Board instance = null;
        private static readonly object padlock = new object();
        public ISquare[] board = new ISquare[40];

        // Constructor
        public Board()
        {
            SquareFactory sfact = new SquareFactory();
            for (int i = 0; i < 40; i++)
            {
                SquareType newsquare = SquareType.NormalSquare;
                switch (i)
                {
                    case 0:
                        newsquare = SquareType.StartSquare;
                        break;
                    case 5:
                        newsquare = SquareType.CommunitySquare;
                        break;
                    case 8:
                        newsquare = SquareType.LuckSquare;
                        break;
                    case 10:
                        newsquare = SquareType.JailSquare;
                        break;
                    case 15:
                        newsquare = SquareType.CommunitySquare;
                        break;
                    case 18:
                        newsquare = SquareType.LuckSquare;
                        break;
                    case 30:
                        newsquare = SquareType.GoToJailSquare;
                        break;
                    default:
                        break;
                }
                board[i] = sfact.Create(newsquare);
            }
        }

        public static Board Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Board();
                    }
                    return instance;
                }
            }
        }
    }
}
