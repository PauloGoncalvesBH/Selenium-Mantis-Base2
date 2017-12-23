using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace PageObjects
{
    class Screenshot
    {
        int contadorPrint = 0;
        PaginaBase paginaBase;

        private void TirarScreenshotComData(string directory, string nomeArquivo, ScreenshotImageFormat formato)
        {

            IWebDriver instanciaBrowser = paginaBase.GetDriver();

            contadorPrint++; //Updates the number of screenshots that we took during the execution

            StringBuilder timeAndDate = new StringBuilder(DateTime.Now.ToString());
            timeAndDate.Replace("/", "_");
            timeAndDate.Replace(":", "_");

            DirectoryInfo validation = new DirectoryInfo(directory);
            bool hasDirectory = validation.Exists == true;

            // Se não tiver o diretório vai criar o mesmo;
            if (hasDirectory)
            {
                ((ITakesScreenshot)instanciaBrowser).GetScreenshot().SaveAsFile(directory + this.contadorPrint.ToString() + "." + nomeArquivo + timeAndDate.ToString() + "." + formato, formato);
            }
            else
            {
                validation.Create();
                ((ITakesScreenshot)instanciaBrowser).GetScreenshot().SaveAsFile(directory + this.contadorPrint.ToString() + "." + nomeArquivo + timeAndDate.ToString() + "." + formato, formato);
            }
        }
    }
}
