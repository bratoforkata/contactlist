using ConsoleApp1.Commands;
using ConsoleApp1.Commands.Core;

namespace ConsoleApp1.Services
{
    public class CommandHandler 
    {
        List<Command> commands = new List<Command>();

        public CommandHandler(ContactRepository contactRepository, ApplicationState state)
        {
            commands.Add(new HelpCommand(this));
            commands.Add(new AddCommand(contactRepository));
            commands.Add(new PrintCommand(contactRepository));
            commands.Add(new SearchCommand(contactRepository));
            commands.Add(new EditCommand(contactRepository, state));
            commands.Add(new DeleteCommand(contactRepository));
            commands.Add(new ExitCommand(state));
            commands.Add(new ClearCommand(this));
            commands.Add(new GameCommand(state));
            commands.Add(new Game2Command(state));
            commands.Add(new Game3Command(state));
        }

        internal bool ContainsKey(string command)
        {
            return commands.Any(c => c.Name == command);
        }

        internal Command GetCommand(string command) 
        {
            return commands.FirstOrDefault(c => c.Name == command);
        }

        internal IEnumerable<string> GetCommandKeys() 
        {
            return commands.Select(c => c.Name);
        }
    }
}
