using ConsoleApp1.Commands.Core;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Services;

internal class ClearCommand : Command
{
    ICommandHandler commandHandler;

    public ClearCommand(ICommandHandler commandHandler) : base(0)
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