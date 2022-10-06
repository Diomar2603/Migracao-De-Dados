using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDownload.Services
{
    internal class DescompactaService
    {

        public void DescompactaPasta(string pathZipado, string pathExtraido)
        {
            string arquivoZipado = Path.Combine(pathZipado,Directory.GetFiles(pathZipado).FirstOrDefault());

            try
            {
                Console.WriteLine("Extraçao de arquivo iniciada.");                
                ZipFile.ExtractToDirectory(arquivoZipado, pathExtraido);
                Console.WriteLine("Extraçao de arquivo Finalizada.");

                //Deletar arquivo novo
                File.Delete(arquivoZipado);
                Console.WriteLine("Arquivo .Zip deletado ;).\n");

            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + "Erro disparado ao tentar Desconpactar o arquivo: " + e.Message
                    + "\n" + e.InnerException);
            }  
        }
    }
}
