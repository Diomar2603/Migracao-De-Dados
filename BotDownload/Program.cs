using BotDownload.Services;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        string caminhoResources , caminhoArquivosZipados, caminhoArquivosExtraidos, caminhoWebDriver;
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

        //baixar arquivo
        if (File.Exists(Path.Combine(caminhoArquivosZipados, "DADOS_ABERTOS_CNPJ_01.zip")))
        {
            DownloadService downloadService = new DownloadService();

            downloadService.BaixarArquivosCnpj(caminhoWebDriver, caminhoArquivosZipados);

        }





    }
}