using System;
using System.IO;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PrintScreen
    {
        IWebDriver driver;

        public PrintScreen(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Método para tirar e salvar o screenshot da página ativa;
        /// </summary>
        /// <param name="directory"></param>
        public void TirarScreenshot(string directory)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            byte[] imageBytes = Convert.FromBase64String(screenshot.ToString());

            using (BinaryWriter bw = new BinaryWriter(new FileStream(directory, FileMode.Append,
            FileAccess.Write)))
            {
                bw.Write(imageBytes);
                bw.Close();
            }
        }
    }
}
