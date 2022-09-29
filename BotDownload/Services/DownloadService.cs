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

            try
            {
                IWebDriver driver = new ChromeDriver(pathDriver, options);
                WebDriverWait waitElements = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                WebDriverWait waitDownload = new WebDriverWait(driver, TimeSpan.FromSeconds(500));


                driver.Navigate()
                    .GoToUrl(linkArquivoCnpj);

                waitElements.Until(ExpectedConditions.ElementExists(By.Id(btnDownload)));

                driver.FindElement(By.Id(btnDownload)).Click();

                waitDownload.Until( _ => pastaCriada = File.Exists(Path.Combine(pathDownload, "DADOS_ABERTOS_CNPJ_01.zip")));

                driver.Quit();

            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + "Erro disparado ao tentar Baixar o arquivo: " + e.Message
                    + "\n" + e.InnerException);
            }
        }
    }
}
