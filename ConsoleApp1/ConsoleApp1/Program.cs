using ConsoleApp1.Commands;
using ConsoleApp1.Commands.Core;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Services;
using System.ComponentModel.DataAnnotations;
// using System.Windows.Input;

ApplicationState state = new ApplicationState();
ContactRepository contactRepository = new ContactRepository();
FileService fileService = new FileService();
ISentenceRepository sentenceRepository = new SentenceRepository(fileService);
CommandHandler commandHandler = new CommandHandler(contactRepository, state, sentenceRepository);

var lines = fileService.LoadFile("test.txt");
foreach (var line in lines)
{
    Console.WriteLine(line);
}


Console.WriteLine(string.Join(", ", commandHandler.GetCommandKeys(null)));

while (state.IsRunning) //it will run forever
{
    Queue<string> commandQueue = state.GetCommandQueue();

    if (commandQueue.Count == 0)
    {
        Console.WriteLine("please enter a command");
        continue;
    }
    string command = commandQueue.Dequeue(); // need to modify this

    if (commandHandler.ContainsKey(command, null))
    {
        Command cmd = commandHandler.GetCommand(command, null);
        cmd.Execute(commandQueue);
    }
    else
    {
        Console.WriteLine($"'{command}' is not recognised command");
    }
}