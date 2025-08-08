using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;

namespace ConsoleApp1.Commands
{
    public class HangDudGameCommand : Command
    {
        private ApplicationState state;

        public HangDudGameCommand(ApplicationState state, Guid parentId) : base(0, parentId)
        {
            this.state = state;
        }

        public override string Name => "hangdudd";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            List<string> words = new List<string> {
                "computer",
                "elephant",
                "guitar",
                "airplane",
                "library",
                "pyramid",
                "rocket",
                "penguin",
                "mountain",
                "bicycle" };
            List<string> descriptions = new List<string> {
                "A machine used for work and games.",
                "A big animal with a trunk.",
                "A musical instrument with strings.",
                "Flies in the sky.",
                "A place full of books.",
                "A triangle-shaped building in Egypt.",
                "Flies to space.",
                "A bird that swims but can’t fly.",
                "Very tall and made of rock.",
                "A two-wheeled vehicle."
            };

            // Pick a random word from the list
            Random rand = new Random();
            int index = rand.Next(words.Count); // Pick a random index
            string wordToGuess = words[index]; // The secret word
            string description = descriptions[index]; // The hint

            // Create a list to track the letters the player has guessed
            List<char> guessedLetters = new List<char>();

            int maxWrongGuesses = 6; // Maximum number of wrong tries
            int wrongGuesses = 0; // Counter for wrong guesses

            // Start the game loop
            while (true)
            {
                Console.Clear();

                DrawHangman(wrongGuesses); // show the hangman on wrong guesses

                // Show game title and hint
                Console.WriteLine("=== Welcome to HangDudd Game ===");
                Console.WriteLine($"Hint: {description}");
                Console.WriteLine();

                // Show the word with underscores for unguessed letters
                string displayWord = "";
                foreach (char letter in wordToGuess)
                {
                    if (guessedLetters.Contains(letter))
                    {
                       // displayWord = displayWord + letter + " "; // these do the same thing
                        displayWord += letter + " "; // show guessed letter
                    }
                    else
                    {
                        displayWord += "_ "; // show underscore for unknown letter
                    }
                }
                Console.WriteLine($"Word: {displayWord}");
                Console.WriteLine();

                // Show guessed letters
                Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
                Console.WriteLine($"Wrong guesses: {wrongGuesses}/{maxWrongGuesses}");
                Console.WriteLine();

                // Check if the player has won
                if (!displayWord.Contains("_"))
                {
                    Console.WriteLine(" You win! You guessed the word!");
                    break;
                }

                // Check if the player has lost
                if (wrongGuesses >= maxWrongGuesses)
                {
                    Console.WriteLine($" Game Over The word was: {wordToGuess}");
                    break;
                }

                // Ask the player to guess a letter
                Console.Write("Enter a letter: ");
                string? input = Console.ReadLine(); // Read input and convert to lowercase

                // Validate input: must be 1 letter and not already guessed
                if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("enter a single letter.");
                    Console.ReadKey(); // Wait for a key press
                    continue; // Go back to start of loop
                }

                char guess = input.ToLower().First();

               // char guess = input[0];

                // the letter was already guessed, skip it
                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine("already guessed that letter.");
                    Console.ReadKey(); // Wait for key press
                    continue;
                }

                // add the guess to the list
                guessedLetters.Add(guess);

                // the letter is not in the word, increase the wrong guess count
                if (!wordToGuess.Contains(guess))
                {
                    wrongGuesses++;
                }
            }
            // End of game
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
        // This method draws the hangman based on the number of wrong guesses

        private void DrawHangman(int wrongGuesses)
        {
            // Each string represents a stage of the hangman being drawn
            string[] hangmanStages = new string[]
            {
                @"
               +---+
               |   |
                   |
                   |
                   |
                   |
             =========",
                             @"
               +---+
               |   |
               O   |
                   |
                   |
                   |
             =========",
                             @"
               +---+
               |   |
               O   |
               |   |
                   |
                   |
             =========",
                             @"
               +---+
               |   |
               O   |
              /|   |
                   |
                   |
             =========",
                             @"
               +---+
               |   |
               O   |
              /|\  |
                   |
                   |
             =========",
                             @"
               +---+
               |   |
               O   |
              /|\  |
              /    |
                   |
             =========",
                             @"
               +---+
               |   |
               O   |
              /|\  |
              / \  |
                   |
             ========="
            };

            // Clamp the index so we don't go out of bounds
            int index = Math.Min(wrongGuesses, hangmanStages.Length - 1);

            // Print the ASCII drawing for the current stage
            Console.WriteLine(hangmanStages[index]);
        }
    }
}