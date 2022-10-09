using MongoDB.Driver;

namespace ApiMigracaoDeDados.Data
{
    public class DbConnection
    {
        private MongoClient _db;

        public IMongoDatabase Database { get; set; }

        public DbConnection(IDbSettings settings)
        {
            _db = new MongoClient(settings.ConnectionString);
            Database = _db.GetDatabase(settings.DatabaseName);
        }
    }
}
