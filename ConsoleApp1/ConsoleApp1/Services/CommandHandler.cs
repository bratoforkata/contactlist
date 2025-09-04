using ConsoleApp1.Commands;
using ConsoleApp1.Commands.Core;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.Services
{
    public class CommandHandler : ICommandHandler
    {
        List<Command> commands = new List<Command>();

        public CommandHandler(
            IContactRepository contactRepository,
            ApplicationState state,
            ISentenceRepository sentenceRepository,
            ISentenceScoreRepository scoreRepository,
            IFileService fileService,
            BulgarianRepository bulgarianRepository)

        {
          //  var bulgarianRepository = new BulgarianRepository(fileService);
            commands.Add(new HelpCommand(this));
            commands.Add(new AddCommand(contactRepository,fileService));
            commands.Add(new PrintCommand(contactRepository, fileService));
            commands.Add(new SearchCommand(contactRepository));
            commands.Add(new EditCommand(contactRepository, state));
            commands.Add(new DeleteCommand(contactRepository));
            commands.Add(new ExitCommand(state));
            commands.Add(new ClearCommand(this));
            commands.Add(new GamesFolderCommand(this, state, sentenceRepository, scoreRepository));
            commands.Add(new BulgarianCommand(fileService, bulgarianRepository));
        }
        // internal bool ContainsKey(string command, Guid? parentId)
        public bool ContainsKey(string command, Guid? parentId)
        {
            return commands
                .Where(x => x.ParentId == parentId)
                .Any(c => c.Name == command);
        }

        //internal Command GetCommand(string command, Guid? parentId)
        public Command GetCommand(string command, Guid? parentId)
        {
            return commands
                .Where(x => x.ParentId == parentId)
                .FirstOrDefault(c => c.Name == command);
        }

        //internal IEnumerable<string> GetCommandKeys(Guid? parentId)
        public IEnumerable<string> GetCommandKeys(Guid? parentId)
        {
            return commands
                .Where(x => x.ParentId == parentId)
                .Select(c => c.Name);
        }

        //  internal void Add(Command command)
        public void Add(Command command)
        {
            commands.Add(command);
        }
    }
}
