using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;

namespace ConsoleApp1.Commands
{
    public class TicTacToeGameCommand : Command
    {
        private ApplicationState state;

        public TicTacToeGameCommand(ApplicationState state, Guid parentId) : base(0, parentId)
        {
            this.state = state;
        }

        public override string Name => "ttt";


        protected override void RunCommand(Queue<string> commandQueue)
        {
            char currentPlayer = 'X'; // currect player symbol

            int moves = 0;
            char[] board = [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ']; // board of the game

            while (true)
            {
                Console.Clear();
                PrintBoard(board);

                Console.WriteLine($"\nPlayer {currentPlayer}, choose a number (1-9):");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int pos) && pos >= 1 && pos <= 9) // convert input to int
                {
                    if (board[pos - 1] == 'X' || board[pos - 1] == '0') // check if spot taken already
                    {
                        Console.WriteLine("Spot already taken. Press enter to try again.");
                        Console.ReadLine();
                        continue; // lets them try again.
                    }

                    board[pos - 1] = currentPlayer; // place the players mark on chosen positnon

                    if (CheckWin(board, currentPlayer))
                    {
                        Console.Clear();
                        PrintBoard(board);
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break; // exit the loop and end the game
                    }

                    // count the moves
                    moves++; 

                    if (moves == 9 )
                    {
                        Console.Clear();
                        PrintBoard(board);
                        Console.WriteLine("Its a draw");
                        break; // exit the loop and end the game
                    }
                    currentPlayer = (currentPlayer == 'X') ? '0' : 'X'; // switch to other player
                }

                else
                {
                    Console.WriteLine("Invalid input! enter to try again.");
                    Console.ReadLine();
                }

            }
        }

        bool CheckWin(char[] board, char currentPlayer) // check for win - created with quick refactorings
        {
            int[,] wins = { //possible winning combinations
            {0, 1, 2}, //top row
            {3, 4, 5}, //middle
            {6, 7, 8}, // bottom
            {0, 3, 6}, //left column
            {1, 4, 7}, //middle clumn
            {2, 5, 8}, //right
            {0, 4, 8}, //diagonal topleft to bottom right
            {2, 4, 6} // diagonal topright to bot-left
        };

            for (int i = 0; i < wins.GetLength(0); i++) // check each win combo
            {
                if (board[wins[i, 0]] == currentPlayer &&
                    board[wins[i, 1]] == currentPlayer &&
                    board[wins[i, 2]] == currentPlayer)
                {
                    return true; // player wins
                }
            }
            return false; // no win found
        }
        void PrintBoard(char[] board) // prints the board - created with quick refactoryings
        {
            Console.WriteLine("Tic Tac Toe");
            Console.WriteLine();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }
    }
}

