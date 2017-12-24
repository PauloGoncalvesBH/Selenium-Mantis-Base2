using System;
using OpenQA.Selenium;

namespace PageObjects
{

    public class Browser
    {
        IWebDriver driver;
        
        public Browser(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Método para acesso à uma URL;
        /// </summary>
        /// <param name="url"></param>
        public void NavegarPara(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Método que maximiza a tela do browser;
        /// </summary>
        public void MaximizarTela()
        {
            driver.Manage().Window.Maximize();
        }
        
        /// <summary>
        /// Método que fechar o browser;
        /// </summary>
        public void FecharNavegador()
        {
            driver.Close();
        }
        
    }
}
