using ConsoleApp1;

internal class ClearCommand : Command
{
    Dictionary<string, Command> commands = new Dictionary<string, Command>();

    public ClearCommand(Dictionary<string, Command> commands) : base(0) 
    {
        this.commands = commands;
    }
    protected override void RunCommand(Queue<string> commandQueue)
    {
        foreach (KeyValuePair<string, Command> command in commands)
        {
            Console.Clear();
            Console.WriteLine(string.Join(", ", commands.Keys));
        }
    }
}