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
using OpenQA.Selenium.Support.UI;

namespace Testes
{

    [TestFixture]
    class TestePaginaLogin
    {
        public Browser browser;
        public PaginaLogin paginaLogin;
        public PrintScreen printScreen;
        public PaginaMinhaVisao paginaMinhaVisao;

        public static IWebDriver driver = new FirefoxDriver();
        string paginaLoginMantis = "http://mantis-prova.base2.com.br";
        int timeoutTempoEmSegundos = 10;

        [SetUp]
        public void AcessarPaginaLogin()
        {
            // @arrange            
            paginaLogin = new PaginaLogin(driver, timeoutTempoEmSegundos);
            browser = new Browser(driver);
            printScreen = new PrintScreen(driver);
            
            browser.NavegarPara(paginaLoginMantis);
            browser.MaximizarTela();
        }

        [TearDown]
        public void FinalizaTesteLogin()
        {
            printScreen.TirarScreenshotComData(@"C:\Users\Pichau\Desktop", "teste");

            browser.FecharNavegador();

            if (driver != null)
                driver.Dispose();
        }

        [Test]
        public void Realizar_Login_Com_Sucesso_Preenchendo_Corretamente_Usuario_e_Senha()
        {
            string usuario = "paulo.goncalves";
            string senha = "#descubra";

            // @act
            paginaLogin.RealizaLogin(usuario, senha);

            // @assert
            paginaMinhaVisao = new PaginaMinhaVisao(driver, timeoutTempoEmSegundos);
            Assert.AreEqual(paginaMinhaVisao.TextoAcessandoComo().Displayed, true);
        }

        [Test]
        public void Realizar_Login_Com_Falha_Preenchendo_Usuario_e_Senha_inexistentes()
        {
            string usuario = "usuarioInexistente";
            string senha = "senhaInexistente";

            // @act
            paginaLogin.RealizaLogin(usuario, senha);

            // @assert
            paginaMinhaVisao = new PaginaMinhaVisao(driver, timeoutTempoEmSegundos);
            bool presencaTextoAcessandoComo = driver.ElementIsPresent(paginaMinhaVisao.ByAcessandoComo());

            // Valida a existência 
            Assert.AreEqual(paginaMinhaVisao.TextoSenhaUsuarioIncorreta().Displayed, true);
            Assert.AreEqual(presencaTextoAcessandoComo, false);
        }

    }

}
