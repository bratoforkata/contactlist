using ConsoleApp1.Commands.Core;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

public class SentenceGameCommand : Command
{
    private ApplicationState state;
    private readonly ISentenceRepository sentenceRepository;
    private readonly ISentenceScoreRepository scoreRepository;

    public SentenceGameCommand(
        ApplicationState state,
        Guid parentId,
        ISentenceRepository sentenceRepository,
        ISentenceScoreRepository scoreRepository)
        : base(0, parentId)
    {
        this.state = state;
        this.sentenceRepository = sentenceRepository;
        this.scoreRepository = scoreRepository;
    }

    public override string Name => "sentences";

    private float CalculateScore(Sentence sentence, string userInput, TimeSpan duration)
    {
        var percentage = CalculatePercentage(sentence, userInput);
        var timePenalty = (float)Math.Exp(-duration.TotalSeconds / 10.0); // Decay over time
        return percentage * timePenalty * 1000;
    }

    private float CalculatePercentage(Sentence sentence, string userInput)
    {
        if (userInput == sentence.Text)
        {
            return 1;
        }
        if (userInput == string.Empty) //static value
        {
            return 0;
        }

        float matchingCharacters = 0;  //matching characters in the sentence

        // user input can be shorter than sentence text  
        // therefore we are risking going out of bounds
        // meaning we might accidentally compare character of sentence with 
        // a character in userInput that doesnt exist.
        // therefore we need to limit the number of checks to the length of the shortest of these 2.
        int length = Math.Min(userInput.Length, sentence.Text.Length);

        for (int i = 0; i < length; i++) //check every character
        {
            if (sentence.Text[i] == userInput[i]) // and if character matches
            {
                matchingCharacters++; // increment matching characters
            }
        }

        return matchingCharacters / sentence.Text.Length;
    }

    protected override void RunCommand(Queue<string> commandQueue)
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

        var score = CalculateScore(sentence, userInput, timeCalculated);

        Console.WriteLine("Your Score is: " + score.ToString());
        Console.WriteLine("Type in your name to save the score: ");
        var username = Console.ReadLine();

        var sentenceScore = new SentenceScore
        {
            Score = score,
            SentenceId = sentence.Id,
            Username = username!
        };

        scoreRepository.Add(sentenceScore);
    }
}