using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
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

        public void NavegarPara(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void MaximizarTela()
        {
            driver.Manage().Window.Maximize();
        }
        
        public void FecharNavegador()
        {
            driver.Close();
        }
        
    }
}
