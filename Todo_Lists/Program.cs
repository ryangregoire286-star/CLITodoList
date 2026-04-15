using Todo_Lists.DbClientStuff;

namespace Todo_Lists
{
    internal abstract class Program
    {
        private const int NumLists = 5;
        private static readonly List<string> Todos = [];

        public static void Main(string[] args)
        {
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