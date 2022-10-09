namespace ApiMigracaoDeDados.Data
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string EmpresasCollectionName { get; set; }

        public string SociosCollectionName { get; set; }
    }

    public interface IDbSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string EmpresasCollectionName { get; set; }

        string SociosCollectionName { get; set; }
    }
}
