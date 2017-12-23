using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace PageObjects
{

    public class PaginaBase
    {

        IWebDriver driver;

        public PaginaBase(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PaginaBase()
        {
            this.driver = new FirefoxDriver();
        }

        public void NavegarPara(String url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void FecharNavegador()
        {
            GetDriver().Close();
        }
        
    }
}
