using ConsoleApp1.Commands.Core;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Services;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Commands
{
    internal class BulgarianCommand : Command
    {
        private readonly IFileService fileService;
        private readonly BulgarianRepository bulgarianRepository;
        private readonly Random random = new Random();
        private List<string> words = new List<string>();

        public BulgarianCommand(IFileService fileService, BulgarianRepository bulgarianRepository) : base(0)
        {
            this.fileService = fileService;
            this.bulgarianRepository = bulgarianRepository;
        }
        public override string Name => "bg";

        protected override void RunCommand(Queue<string> commandQueue)
        {
            words = bulgarianRepository.GetAll();
            Console.WriteLine("enter to get a random word or exit");

            while (words.Count > 0)
            {
                var input = Console.ReadLine();

                if (input == "exit")
                    break;
                if (input != null && input.StartsWith("add "))
                {
                    var wordToAdd = input.Substring(4).Trim();
                    AddWord(wordToAdd);
                    continue;
                }

                var randomIndex = random.Next(words.Count);
                var randomWord = words[randomIndex];
                words.RemoveAt(randomIndex);
                Console.WriteLine($"how do you say:  {randomWord}");
            }
        }

        private void AddWord(string word)
        {
            if (words.Any(w => string.Equals(w, word, StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.WriteLine("word exists");
                return;
            }
            bulgarianRepository.Add(word);
            Console.WriteLine("added word.");
        }
    }
}