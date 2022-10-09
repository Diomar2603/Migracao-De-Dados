using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ApiMigracaoDeDados.Models
{
    public class Socio
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CnpjEmpresa { get; set; }
        public string RazaoNomeSocial { get; set; }
        public string IdSocio { get; set; }
        public string CnpjCpfSocio { get; set; }
        public Empresa Empresa { get; set; }
    }
}
