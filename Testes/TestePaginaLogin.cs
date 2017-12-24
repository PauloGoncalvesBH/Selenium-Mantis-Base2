using PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Testes
{

    [TestFixture]
    class TestePaginaLogin
    {
        public Browser browser;
        public PaginaLogin paginaLogin;
        public PrintScreen printScreen;
        public PaginaMinhaVisao paginaMinhaVisao;
        
        int timeoutTempoEmSegundos = 10;
        string path = @"C:\Users\Paulo\Desktop";
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            // @arrange
            driver = new ChromeDriver();

            paginaLogin = new PaginaLogin(driver, timeoutTempoEmSegundos);
            browser = new Browser(driver);
            printScreen = new PrintScreen(driver);

            browser.MaximizarTela();
            paginaLogin.Visita();
        }

        [TearDown]
        public void AfterEach()
        {
            printScreen.TirarScreenshot(path);

            browser.FecharNavegador();

            if (driver != null)
                driver.Dispose();
        }

        /// <summary>
        /// Teste que realiza login com usuário e senha existentes e valida se ocorreu acesso com sucesso;
        /// </summary>
        [Test]
        public void Login_RealizarLoginComSucesso()
        {
            // @act
            paginaLogin.RealizarLoginComUsuarioESenhaCorretos();

            // @assert
            paginaMinhaVisao = new PaginaMinhaVisao(driver, timeoutTempoEmSegundos);
            Assert.AreEqual(paginaMinhaVisao.TextoAcessandoComo().Displayed, true);
        }

        /// <summary>
        /// Teste que valida que ao inserir dados de usuários inexistentes é impedido o acesso;
        /// Teste executado 9 vezes validando os principais casos de testes de login com falha;
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        [Test, Pairwise]
        public void Login_RealizarLoginUsuarioESenhainexistentes(
            [Values("usuarioInexistente", "", "!!!!!!!!")] string usuario,
            [Values("senhaInexistente", "", "@@@@@@@@")] string senha)
        {
            // @act
            paginaLogin.RealizaLogin(usuario, senha);

            // @assert
            paginaMinhaVisao = new PaginaMinhaVisao(driver, timeoutTempoEmSegundos);
            Assert.AreEqual(paginaMinhaVisao.TextoSenhaUsuarioIncorreta().Displayed, true);
            
            bool presencaTextoAcessandoComo = driver.ElementIsPresent(paginaMinhaVisao.ByAcessandoComo());
            Assert.AreEqual(presencaTextoAcessandoComo, false);
        }

    }

}
