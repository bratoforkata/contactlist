using ConsoleApp1.Commands.Core;
using ConsoleApp1.Services;

internal class ClearCommand : Command
{

    CommandHandler commandHandler;

    public ClearCommand(CommandHandler commandHandler) : base(0)
    {
        this.commandHandler = commandHandler;
    }
    public override string Name => "clear";

    protected override void RunCommand(Queue<string> commandQueue)
    {
        Console.Clear();
        Console.WriteLine(string.Join(", ", commandHandler.GetCommandKeys(null)));
    }
}