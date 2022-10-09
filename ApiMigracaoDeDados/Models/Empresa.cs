using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ApiMigracaoDeDados.Models
{
    public class Empresa
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string IdMatrizFilial { get; set; }
        public string NmFantasia { get; set; }
        public string StCadastral { get; set; }
        public double CapitalSocial { get; set; }
        public DateTime DtCadastral { get; set; }
        public string Cep { get; set; }
        public List<Socio> Socios { get; set; } = new List<Socio>();
    }
}
