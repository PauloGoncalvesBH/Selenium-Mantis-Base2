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
using System.IO;
using System.Drawing;

namespace PageObjects
{

    public class PaginaBase
    {
        IWebDriver driver;
        TimeSpan tempoDeEspera = TimeSpan.FromSeconds(10);

        public PaginaBase(IWebDriver driver)
        {
            this.driver = driver;
            EsperaImplicita();
        }

        public PaginaBase()
        {
            this.driver = new FirefoxDriver();
            EsperaImplicita();
        }

        private void EsperaImplicita()
        {
            this.driver.Manage().Timeouts().ImplicitWait = tempoDeEspera;
        }

        protected void NavegarPara(String url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        public void MaximizarTela()
        {
            this.driver.Manage().Window.Maximize();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void FecharNavegador()
        {
            GetDriver().Close();
        }

        protected void FinalizaTeste()
        {
            FecharNavegador();
            this.driver = null;

        }
        
    }
}
