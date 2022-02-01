using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Game
    {
        public ConcretePlayerAggregate players = new ConcretePlayerAggregate();
        public Board board_game = new Board();
        private int rounds = 1;
        private int lim_rounds;
        private int nb_players;
        public Dices dices = new Dices();

        public int Rounds { get => rounds; set => rounds = value; }
        public int Lim_rounds { get => lim_rounds; set => lim_rounds = value; }
        public int Nb_players { get => nb_players; set => nb_players = value; }

        public Game() { }

        /// <summary>
        /// Allows the user to create up to 6 players, adding them to the PlayerIterator with a name and a pseudo.
        /// Once done, list all the players existing with their attributes.
        /// </summary>
        public void Create()
        {
            Console.WriteLine("Welcome !");
            this.nb_players = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            while (this.nb_players < 2 || this.nb_players > 6)
            {
                Console.WriteLine("How many players (2-6) ?");
                this.nb_players = int.Parse(Console.ReadLine());
            }
            Console.ForegroundColor = ConsoleColor.White;
            string[] pseudos = new string[] { "Daily Wolf", "Unusual Tiger", "Terrifying Zebra", "Tender Gorilla", "Slow Rabbit", "Flying Fish" };
            for (int i = 0; i < this.nb_players; i++)
            {
                Console.WriteLine("\nPlayer " + (i + 1) + ":");
                Console.Write("Username: ");
                string name = Console.ReadLine();
                this.players[i] = new Player(name, pseudos[i]);
                Console.WriteLine("\nThe player was successfully added !");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nHow many rounds do you want to play ?");
            Console.ForegroundColor = ConsoleColor.White;
            this.lim_rounds = int.Parse(Console.ReadLine());
            Iterator ite = this.players.CreateIterator();
            Console.WriteLine("\n" + this.nb_players + " Players:\n");
            Player item = ite.First();
            while (item != null)
            {
                Console.WriteLine(item.toString());
                item = ite.Next();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress any key to start the game !\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
        }

        /// <summary>
        /// Main core of the game.
        /// Double while loop to iterate over the players and the rounds.
        /// Treating dices doubles and jail procedure (see below) + Use the ISquare to display the Square specificities.
        /// Ending the game when rounds > limit.
        /// </summary>
        public void Start()
        {
            Console.Clear();
            Console.WriteLine("The game is starting !");
            Iterator ite = this.players.CreateIterator();
            Player item = ite.First();

            while (this.rounds <= this.lim_rounds)
            {
                while (item != null)
                {
                    Console.Clear();
                    if (this.rounds == this.lim_rounds) { Console.WriteLine("Round n°" + this.rounds + ": LAST ROUND !\n"); }
                    else { Console.WriteLine("Round n°" + this.rounds + ": \n"); }

                    Player current = item;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPlayer " + current.Name + ":");
                    Console.ForegroundColor = ConsoleColor.White;
                    int nbdouble = 0;
                    board_game.board[current.Position].PrintSquare(current.Is_in_jail);

                    if (current.Is_in_jail == true && current.Rounds_in_jail < 3)
                    {
                        Jail_Procedure(current, nbdouble);
                    }

                    else
                    {
                        Console.WriteLine("Press any key to roll the dices !\n");
                        Console.ReadKey(true);
                        this.dices.ThrowDices();
                        Console.WriteLine(this.dices.toString());
                        current.Move(this.dices.Sum);

                        while (this.dices.AreEquals())
                        {
                            nbdouble++;
                            if (current.Is_in_jail == true)
                            {
                                Jail_Procedure(current, nbdouble);
                                break;
                            }
                            else
                            {
                                if (nbdouble == 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nEnough luck for today !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("You've rolled a double for the third time in a row... See you in jail.");
                                    current.Is_in_jail = true;
                                    current.Position = 10;
                                    break;
                                }
                                board_game.board[current.Position].PrintSquare(current.Is_in_jail);
                                board_game.board[current.Position].Action(current);
                                Console.WriteLine("Wow ! You got a double, you can roll the dices again !");
                                Console.WriteLine("\nPress any key to roll the dices !\n");
                                Console.ReadKey(true);
                                this.dices.ThrowDices();
                                Console.WriteLine(this.dices.toString());
                                current.Move(this.dices.Sum);
                            }

                        }
                    }
                    board_game.board[current.Position].PrintSquare(current.Is_in_jail);
                    board_game.board[current.Position].Action(current);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Press key to end turn.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey(true);
                    item = ite.Next();
                }
                rounds++;
                item = ite.First();
            }
            EndGame_Procedure(ite);
        }

        /// <summary>
        /// Makes the player automatically throw the dices when in jail except if nbdouble is 3.
        /// If double, the player escapes.
        /// </summary>
        /// <param name="current">
        /// Current instance from the Player class playing.
        /// </param>
        /// <param name="nbdouble">
        /// How many doubles has the current player done ?
        /// </param>
        public void Jail_Procedure(Player current, int nbdouble)
        {
            Console.WriteLine("You are in jail, roll the dices and get a double to get out !\n");
            this.dices.ThrowDices();
            Console.WriteLine(this.dices.toString());
            if (this.dices.AreEquals())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Congrats ! You just got out of jail.\n");
                Console.ForegroundColor = ConsoleColor.White;
                current.Is_in_jail = false;
                current.Move(this.dices.Sum);
            }
            else
            {
                current.Rounds_in_jail++;
                Console.WriteLine("Not a double ! Rounds spent in jail: " + current.Rounds_in_jail);
            }

            if (current.Rounds_in_jail == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou've done your time... Time to get out.");
                current.Is_in_jail = false;
                current.Move(this.dices.Sum);
            }
        }

        /// <summary>
        /// Displays winner and end-game messages.
        /// </summary>
        /// <param name="ite">
        /// Players iterator initiated for this Game instance.
        /// </param>
        public void EndGame_Procedure(Iterator ite)
        {
            Console.Clear();
            Player player = ite.First();
            int best_distance = player.Distance;
            string best_player = player.toString();
            for (int i = 1; i< this.nb_players; i++)
            {
                player = ite.Next();
                if (player.Distance > best_distance)
                {
                    best_distance = player.Distance;
                    best_player = player.toString();
                }
            }
            Console.WriteLine("\nThe game is over ! Thank you for playing :)\n" +
                "However we still have to announce the player that covered the longest distance.");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("\nRunning over " + best_distance + " squares... Please congrat our winner:\n" +
                "\nDrums rolling...\n");
            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(best_player);
        }
    }
}
