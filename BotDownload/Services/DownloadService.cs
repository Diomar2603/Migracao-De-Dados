using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BotDownload.Services
{
    internal class DownloadService
    {

     

        private void BaixarArquivosCnpj(string path, string link)
        {
            
            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + "Erro disparado ao tentar Baixar o arquivo: " + e.Message
                    + "\n" + e.InnerException);
            }
        }
    }
}
