using MongoDB.Bson;
using MongoDB.Driver;

namespace Todo_Lists.DbClientStuff
{
    internal abstract class ClientUri
    {
        private static string Uri()
        {
            return "mongodb://localhost:27017";
        }
        
        public static void StartClient(List<string> data)
        {
            try
            {
                var client = new MongoClient(Uri());
                var dbResult = client.GetDatabase("Todos");
                var collResult = dbResult.GetCollection<BsonDocument>("Todo");
                var iOptions = new InsertOneOptions()
                {
                    BypassDocumentValidation = true,
                };
                
                foreach (var se in data)
                {
                    collResult.InsertOne(new BsonDocument("data", se), iOptions);                    
                }

            }
            catch (Exception ce)
            {
                Console.WriteLine(ce.Message);
            }
        }
    }
}