using ConsoleApp1.Commands;
using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;
using System.ComponentModel.DataAnnotations;
// using System.Windows.Input;

ApplicationState state = new ApplicationState();
ContactRepository contactRepository = new ContactRepository();
CommandHandler commandHandler = new CommandHandler(contactRepository, state);

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