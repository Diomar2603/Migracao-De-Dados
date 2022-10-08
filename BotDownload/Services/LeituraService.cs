using BotDownload.Data;
using BotDownload.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDownload.Services
{
    internal class LeituraService
    {

        DbFuncionalidades _db;

        public List<Empresa> EmpresasList { get; } = new List<Empresa>();
        public List<Socio> SociosList { get; } = new List<Socio>();

        public void LerArquivo(string pathExtraido)
        {
            string arquivoExtraido = Path.Combine(pathExtraido, Directory.GetFiles(pathExtraido).FirstOrDefault());
            Console.WriteLine("Leitura do documento iniciada, pode demorar um \npouco devido a quantidade de dados");
            using (FileStream fs = File.Open(arquivoExtraido, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        _db = new DbFuncionalidades();
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            ConverterDados(line);
                        }
                        Console.WriteLine("Dados estão sendo inseridos no banco");
                        _db.InsertAllEmpresa(EmpresasList);
                        _db.InsertAllSocio(SociosList);

                    }
                }
            }
            File.Delete(arquivoExtraido);
            Console.WriteLine("Dados já foram inseridos no banco, favor rodar a API para consultar os CNPJ's");
        }

        private void ConverterDados(string linha)
        {
            try
            {
                if (linha.StartsWith("1"))
                {
                    var empresa = new Empresa();
                    empresa.Cnpj = linha.Substring(3, 14).Trim();
                    empresa.RazaoSocial = linha.Substring(18, 150).Trim();
                    empresa.IdMatrizFilial = linha.Substring(17, 1).Trim();
                    empresa.NomeFantasia = linha.Substring(168, 55).Trim();
                    empresa.SituacaoCadastral = linha.Substring(223, 2).Trim();
                    empresa.CapitalSocial = Convert.ToDouble(linha.Substring(891, 14).Trim());
                    empresa.DataSituacaoCadastral = DateTime.ParseExact(linha.Substring(225, 8).Trim(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    empresa.Cep = linha.Substring(674, 8).Trim();

                    EmpresasList.Add(empresa);
                }
                else if (linha.StartsWith("2"))
                {
                    var socio = new Socio();
                    socio.CnpjEmpresa = linha.Substring(3, 14).Trim();
                    socio.CnpjCpfSocio = linha.Substring(168, 14).Trim();
                    socio.RazaoNomeSocial = linha.Substring(18, 150).Trim();
                    socio.IdSocio = linha.Substring(17, 1).Trim();

                    SociosList.Add(socio);
                }
                
            }
            catch (Exception e)
            {
                
            }
        }


    }
}
