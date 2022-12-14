using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BotDownload.Services
{
    internal class DownloadService
    {

        private const string linkArquivoCnpj = "https://drive.google.com/uc?export=download&id=11JEE8WKSD9_FBAfGfiFq_z-ZtS1bmGeR";

        public void BaixarArquivosCnpj(string pathDriver, string pathDownload)
        {

            string btnDownload = "uc-download-link";
            bool pastaCriada;

            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", pathDownload);
            options.AddArguments("--headless");


            try
            {
                IWebDriver driver = new ChromeDriver(pathDriver, options);
                WebDriverWait waitElements = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                WebDriverWait waitDownload = new WebDriverWait(driver, TimeSpan.FromSeconds(500));

                Console.Clear();
                Console.WriteLine("Iniciando Downloa de Arquivo.");

                driver.Navigate()
                    .GoToUrl(linkArquivoCnpj);

                waitElements.Until(ExpectedConditions.ElementExists(By.Id(btnDownload)));

                driver.FindElement(By.Id(btnDownload)).Click();

                var i = 1;
                waitDownload.Until(_ => {

                    string reticencias = "";

                    for (int j = 0; j < i; j++)
                    {
                        reticencias = reticencias +".";
                        
                    }

                    if (i == 3)
                    {
                        i = 1;
                    }
                    else
                    {
                        i += 1;
                    }

                    Console.Clear();
                    Console.WriteLine("Iniciando Downloa de Arquivo.");
                    Console.WriteLine("Baiando" + reticencias);

                     Thread.Sleep(200);
                     return pastaCriada = File.Exists(Path.Combine(pathDownload, "DADOS_ABERTOS_CNPJ_01.zip"));});

                driver.Quit();

                Console.Clear();
                Console.WriteLine("Downloa de Arquivo finalizado.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + "Erro disparado ao tentar Baixar o arquivo: " + e.Message
                    + "\n" + e.InnerException);
            }
        }
    }
}
