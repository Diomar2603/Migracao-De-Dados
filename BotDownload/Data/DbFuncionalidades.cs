using BotDownload.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDownload.Data
{
    internal class DbFuncionalidades
    {
        private MongoClient _client = new MongoClient("mongodb://localhost:27017"); //Conectar no servidor

        private IMongoDatabase database;

        private IMongoCollection<Empresa> collectionEmpresa;

        private IMongoCollection<Socio> collectionSocio;

        public DbFuncionalidades()
        {
            database = _client.GetDatabase("OrganizacaoEmpresas");
            collectionEmpresa = database.GetCollection<Empresa>("Empresas");
            collectionSocio = database.GetCollection<Socio>("Socios");
        }

        public void InsertAllEmpresa(List<Empresa> empresas)
        {
            if (empresas.Any())
                collectionEmpresa.InsertMany(empresas);
        }

        public void InsertAllSocio(List<Socio> socios)
        {
            if (socios.Any())
                collectionSocio.InsertMany(socios);
        }

    }
}
