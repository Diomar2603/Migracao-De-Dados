internal class Program
{
    private static void Main(string[] args)
    {
        string caminhoResources , caminhoArquivosZipados, caminhoArquivosExtraidos;
        caminhoResources = Path.GetDirectoryName(typeof(Program).Assembly.Location);
        caminhoResources = caminhoResources.Split(@"BotDownload\")[0] + @"BotDownload\Resources";

        caminhoArquivosZipados = caminhoResources + @"\ArquivosZipados";
        caminhoArquivosExtraidos = caminhoResources + @"\ArquivosExtraidos";

        if (!Directory.Exists(caminhoArquivosZipados))
        {
            Directory.CreateDirectory(caminhoArquivosZipados);
        }
        if (!Directory.Exists(caminhoArquivosExtraidos))
        {
            Directory.CreateDirectory(caminhoArquivosExtraidos);
        }


        

    }
}