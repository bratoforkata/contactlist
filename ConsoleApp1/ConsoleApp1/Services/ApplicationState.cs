namespace ConsoleApp1.Services
{
    public class ApplicationState
    {
        bool isRunning = true;
        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
        public string GetNextLine()
        {
            string nextLine = Console.ReadLine();
            return nextLine.Trim();
        }
        public Queue<string> GetCommandQueue()
        {
            string nextLine = GetNextLine();
            var words = nextLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> command = new Queue<string>(words);
            return command;
        }
    }
}
