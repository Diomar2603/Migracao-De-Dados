using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDownload.Models
{
    internal class Empresa
    {
        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string IdMatrizFilial { get; set; }

        public string NmFantasia { get; set; }

        public string StCadastral { get; set; }

        public double CapitalSocial { get; set; }

        public DateTime DtCadastral { get; set; }

        public string Cep { get; set; }
    }
}
