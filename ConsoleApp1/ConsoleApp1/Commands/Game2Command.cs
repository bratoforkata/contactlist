using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

public class Game2Command : Command
{
    private ApplicationState state;

    public Game2Command(ApplicationState state) : base(0)
    {
        this.state = state;
    }

   // protected override string Key => "game-RPS";
    public override string Name => "game-RPS";

    protected override void RunCommand(Queue<string> commandQueue)
    {
        string[] picks = ["rock", "paper", "scissors"];
        Random random = new Random();

        while (true)
        {
            Console.WriteLine("Pick rock, paper or scissors:");
            string playerpick = state.GetNextLine();

            if (picks.Contains(playerpick) == false)
            {
                if(playerpick == "exit") 
                {
                    break;
                }
                Console.WriteLine(playerpick + " is not a valid pick");
                continue;
            }

            string computerpick = picks[random.Next(picks.Length)];

            if (playerpick == computerpick)
            {
                Console.WriteLine("TIE!");
                Console.WriteLine("computer picked " + computerpick);
                continue;
            }

            if (IsWin(playerpick, computerpick))
            {
                Console.WriteLine("You win!!");
                Console.WriteLine("computer picked " + computerpick);
                continue;
            }

            if (playerpick == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Computer wins!! Loser :)");
                Console.WriteLine("computer picked " + computerpick);
                continue;
            }
        }
    }
    private bool IsWin(string playerpick, string computerpick)
    {
        if (playerpick == "rock" && computerpick == "scissors")
        {
            return true;
        }
        if (playerpick == "scissors" && computerpick == "paper")
        {
            return true;
        }
        if (playerpick == "paper" && computerpick == "rock")
        {
            return true;
        }
        return false;
    }
}