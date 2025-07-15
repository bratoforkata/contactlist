using ConsoleApp1.Commands;
using ConsoleApp1.Commands.Core;

namespace ConsoleApp1.Services
{
    public class CommandHandler 
    {
        Dictionary<string, Command> commands = new Dictionary<string, Command>();

        public CommandHandler(ContactRepository contactRepository, ApplicationState state) 
        {
            commands.Add("help", new HelpCommand(this));
            commands.Add("add", new AddCommand(contactRepository));
            commands.Add("print", new PrintCommand(contactRepository));
            commands.Add("search", new SearchCommand(contactRepository));
            commands.Add("edit", new EditCommand(contactRepository, state));
            commands.Add("delete", new DeleteCommand(contactRepository));
            commands.Add("exit", new ExitCommand(state));
            commands.Add("clear", new ClearCommand(this));
            commands.Add("game-numbers", new GameCommand(state));
            commands.Add("game-RPS", new Game2Command(state));
            commands.Add("game-sentences", new Game3Command(state));
        }

        internal bool ContainsKey(string command)
        {
            return commands.ContainsKey(command);
        }

        internal Command GetCommand(string command)
        {
            return commands[command];
        }

        internal IEnumerable<string> GetCommandKeys()
        {
            return commands.Keys;
        }
    }
}
