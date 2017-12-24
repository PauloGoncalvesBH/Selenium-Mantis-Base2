using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PrintScreen
    {
        int contadorPrint = 0;

        IWebDriver driver;

        public PrintScreen(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TirarScreenshotComData(string directory, string nomeArquivo)
        {

            contadorPrint++; //Updates the number of screenshots that we took during the execution

            StringBuilder timeAndDate = new StringBuilder(DateTime.Now.ToString());
            timeAndDate.Replace("/", "_");
            timeAndDate.Replace(":", "_");
            
            var nomeScreenshot = "N° " + this.contadorPrint.ToString() + " - " + nomeArquivo + " - " + timeAndDate.ToString();
            ScreenshotImageFormat formato = ScreenshotImageFormat.Jpeg;

            DirectoryInfo validation = new DirectoryInfo(directory);
            bool hasDirectory = validation.Exists == true;

            // Se não tiver o diretório vai criar o mesmo;
            if (hasDirectory)
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(directory + nomeScreenshot + "." + formato, formato);
            }
            else
            {
                validation.Create();
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(directory + nomeScreenshot + "." + formato, formato);
            }
        }
    }
}
