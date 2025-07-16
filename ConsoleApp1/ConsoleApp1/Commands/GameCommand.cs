using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;

public class GameCommand : Command
{
    private ApplicationState state;

    public GameCommand(ApplicationState state):base(0)
    {
        this.state = state;
    }

  //  protected override string Key => "game-numbers";

    public override string Name => "game-numbers";

    protected override void RunCommand(Queue<string> commandQueue)
    {
        int number = Random.Shared.Next(0,100);
        int guess = -1;
        Console.WriteLine("Game of guessing a number between 0 to 99");
        int guesses = 0;

        while (number != guess)
        {
            Console.WriteLine("enter a number:");
            
            guesses++;
            string guess1 = state.GetNextLine();
            if (int.TryParse(guess1, out guess) == false)
            {
                Console.WriteLine("wrong number");
                continue;
            }
            if (number == guess)
            {
                Console.WriteLine("Correct!..Correct!");
                Console.WriteLine("Number of guesses:" + guesses);
                if(guesses > 6)
                {
                    Console.WriteLine("Loser :)) You suck");
                }
            }
            else if (number > guess)
            {
                Console.WriteLine("the number is greater");
                continue;
            }
            else if (number < guess)
            {
                Console.WriteLine("the number is lower");
                continue;
            }
        }
    }
}