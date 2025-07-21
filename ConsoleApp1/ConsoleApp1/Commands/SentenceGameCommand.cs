using ConsoleApp1.Commands.Core;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Services;

public class SentenceGameCommand : Command
{
    private ApplicationState state;
    private readonly ISentenceRepository sentenceRepository;

    public SentenceGameCommand(
        ApplicationState state,
        Guid parentId, 
        ISentenceRepository sentenceRepository) 
        : base(0, parentId)
    {
        this.state = state;
        this.sentenceRepository = sentenceRepository;
    }

    public override string Name => "sentences";

    protected override void RunCommand(Queue<string> commandQueue)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Sentence GAME");
            Console.WriteLine("Here is your sentence, read it and press enter to begin:");
          
            var sentence = sentenceRepository.GetRandomSentence();
            Console.WriteLine("Your sentence is: " + sentence.Text);
            Console.ReadLine(); // waiting to press the ENter :)

            DateTime timeStart = DateTime.UtcNow; // timer starts

            Console.WriteLine("Start typing now: "); // user inputs

            string userInput = state.GetNextLine(); // gets the user input

            TimeSpan timeCalculated = DateTime.UtcNow - timeStart; // timer ends and calculates duration

            Console.WriteLine("Your typed sentence is: " + userInput); // prints out the input (for testing purps)
            Console.WriteLine("It took you: " + timeCalculated.TotalSeconds.ToString("N2") + " seconds to write it."); //prints out the time taken..

            if (userInput == sentence.Text) // checks if text matches
            {
                Console.WriteLine("Your sentence is correct");
                break; // this needs to be changed to save the score and name..
            }
            else
            {
                Console.WriteLine("Your sentence didnt match.. Try again..");
                Console.ReadLine();
                continue;
            }
        }

        // print the sentence, press enter to begin typing.
        // here we need to get time and after pressed enter we need to get time2
        // print time3 = to show how long it took you

        // need a player name that can come from contacts?.
    }
}
