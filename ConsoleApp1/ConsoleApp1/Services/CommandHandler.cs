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
            commands.Add(new GamesFolderCommand(this, state));

        }

        internal bool ContainsKey(string command, Guid? parentId) 
        {
            return commands
                .Where(x => x.ParentId == parentId)
                .Any(c => c.Name == command);
        }

        internal Command GetCommand(string command, Guid? parentId) 
        {
            return commands
                .Where(x => x.ParentId == parentId)
                .FirstOrDefault(c => c.Name == command);
        }

        internal IEnumerable<string> GetCommandKeys(Guid? parentId) 
        {
            return commands
                .Where(x => x.ParentId == parentId)
                .Select(c => c.Name);
        }

        internal void Add(Command command) 
        {
            commands.Add(command);
        }
    }
}
