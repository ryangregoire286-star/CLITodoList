using Todo_Lists.DbClientStuff;

namespace Todo_Lists
{
    internal abstract class Program
    {
        private const int NumLists = 5;
        private static readonly List<string> Todos = [];

        private static void Optional(string todoMessage = "Welcome to Todo Lists | CLI")
        {
            Console.WriteLine(todoMessage.ToUpper());
        }

        public static void Main(string[] args)
        {
            Optional();
            
            if (!args.Length.Equals(0)) return;
            for (var i = 0; i < NumLists; i++)
            {
                Console.WriteLine($"Enter Todo | {i}");
                var todo = Console.ReadLine() ?? "";
                Todos.Add(todo);
            }

            DBClient.DbSetup.GetDb(Todos.ToList());
        }
    }
}

namespace DBClient
{
    internal abstract class DbSetup
    {
        public static void GetDb(List<string> data)
        {

            ClientUri.StartClient(data);
            
        }
    }
}