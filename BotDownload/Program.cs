using BotDownload.Services;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        string caminhoResources , caminhoArquivosZipados, caminhoArquivosExtraidos, caminhoWebDriver,
               arquivoZipado, arquivoExtraido;

        caminhoResources = Path.GetDirectoryName(typeof(Program).Assembly.Location);
        caminhoResources = caminhoResources.Split(@"BotDownload\")[0] + @"BotDownload\Resources";

        caminhoArquivosZipados = Path.Combine(caminhoResources,"ArquivosZipados");
        caminhoArquivosExtraidos = Path.Combine(caminhoResources,"ArquivosExtraidos");
        caminhoWebDriver = Path.Combine(caminhoResources,"WebDrivers");

        //Criar pastas
        if (!Directory.Exists(caminhoArquivosZipados))
        {
            Directory.CreateDirectory(caminhoArquivosZipados);
        }
        if (!Directory.Exists(caminhoArquivosExtraidos))
        {
            Directory.CreateDirectory(caminhoArquivosExtraidos);
        }

        bool arquivoExtraidosExiste = Directory.GetFiles(caminhoArquivosExtraidos).Length != 0;

        //baixar arquivo
        if (Directory.GetFiles(caminhoArquivosZipados).Length == 0 && !arquivoExtraidosExiste)
        {

            DownloadService downloadService = new DownloadService();

            downloadService.BaixarArquivosCnpj(caminhoWebDriver, caminhoArquivosZipados);

        }

        //Descompactar arquivo
        if (!arquivoExtraidosExiste)
        {
            DescompactaService service = new DescompactaService();
            service.DescompactaPasta(caminhoArquivosZipados, caminhoArquivosExtraidos);
        }



    }
}