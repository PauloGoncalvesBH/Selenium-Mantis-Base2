using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Testes
{

    [TestFixture]
    sealed class ParametroTest
    {
        public Browser browser;
        public PaginaLogin paginaLogin;
        public PrintScreen printScreen;

        public static IWebDriver driver;
        string paginaLoginMantis = "http://mantis-prova.base2.com.br";

        [SetUp]
        public void AcessarPaginaLogin()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            paginaLogin = new PaginaLogin(driver);
            browser = new Browser(driver);
            printScreen = new PrintScreen(driver);
            
            browser.NavegarPara(paginaLoginMantis);
            browser.MaximizarTela();
        }

        [TearDown]
        public void FinalizaTesteLogin()
        {
            browser.FecharNavegador();

            if (driver != null)
                driver.Dispose();
        }

        [Test]
        public void RealizarLoginComSucessoPreenchendoCorretamenteUsuarioeSenha()
        {
            paginaLogin.RealizaLogin("paulo.goncalves", "123456789");
            printScreen.TirarScreenshotComData(@"C:\Users\Pichau\Desktop", "teste");
        }

    }

}
