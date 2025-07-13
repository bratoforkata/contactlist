using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
// using System.Windows.Input;

List<Contact> contacts = new List<Contact>(); // make a list of contacts

contacts.Add(new Contact("Test", "4411155"));
contacts.Add(new Contact("Kamil", "123555"));
contacts.Add(new Contact("Forka", "444455"));

ApplicationState state = new ApplicationState();

Dictionary<string, Command> commands = new Dictionary<string, Command>();

commands.Add("help", new HelpCommand(commands));
commands.Add("add", new AddCommand(contacts));
commands.Add("print", new PrintCommand(contacts));
commands.Add("search", new SearchCommand(contacts));
commands.Add("edit", new EditCommand(contacts, state));
commands.Add("delete", new DeleteCommand(contacts));
commands.Add("exit", new ExitCommand(state));
commands.Add("clear", new ClearCommand(commands));

Console.WriteLine(string.Join(", ", commands.Keys));

while (state.IsRunning) //it will run forever
{
    Queue<string> commandQueue = state.GetCommandQueue();

    if (commandQueue.Count == 0) 
    {
        Console.WriteLine("please enter a command");
        continue;
    }
        string command = commandQueue.Dequeue();
    if (commands.ContainsKey(command))
    {
        Command cmd = commands[command];
        cmd.Execute(commandQueue);
    }
    else
    {
        Console.WriteLine($"'{command}' is not recognised command");
    }
}