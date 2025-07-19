using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;

public class SentenceGameCommand : Command
{
    List<Sentence> sentences = [
        new Sentence("The quick brown fox jumps over the lazy dog."),
        new Sentence("Typing fast is fun until your fingers forget where the keys are."),
        new Sentence("If robots take over the world, I hope they at least fix traffic."),
        new Sentence("Bananas are not phones, no matter how loudly you yell into them."),
        new Sentence("I accidentally deleted the universe, but thankfully I had a backup."),
        new Sentence("Coding late at night leads to mysterious bugs and lots of coffee."),
        new Sentence("Why do programmers confuse Halloween and Christmas? Because Oct 31 == Dec 25.")
        ];

    private ApplicationState state;

    public SentenceGameCommand(ApplicationState state, Guid parentId) : base(0, parentId)
    {
        this.state = state;
    }

    public override string Name => "sentences";

    protected override void RunCommand(Queue<string> commandQueue)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Sentence GAME");
            Console.WriteLine("Here is your sentence, read it and press enter to begin:");
            var sentence = sentences[Random.Shared.Next(sentences.Count)];
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
