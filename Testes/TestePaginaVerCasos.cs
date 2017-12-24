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
    class TestePaginaVerCasos
    {
        public Browser browser;
        public PaginaLogin paginaLogin;
        public PrintScreen printScreen;
        public PaginaRelatarCaso paginaRelatarCaso;
        public ItensGeraisMantis itensGeraisMantis;
        public PaginaVerCasos paginaVerCasos;

        int timeoutTempoEmSegundos = 10;
        string path = @"C:\Users\Paulo\Desktop";
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver();

            paginaLogin = new PaginaLogin(driver, timeoutTempoEmSegundos);
            browser = new Browser(driver);
            printScreen = new PrintScreen(driver);
            paginaRelatarCaso = new PaginaRelatarCaso(driver, timeoutTempoEmSegundos);
            itensGeraisMantis = new ItensGeraisMantis(driver, timeoutTempoEmSegundos);
            paginaVerCasos = new PaginaVerCasos(driver, timeoutTempoEmSegundos);

            // @arrange
            browser.MaximizarTela();
            paginaLogin.Visita();
            paginaLogin.RealizarLoginComUsuarioESenhaCorretos();
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
        /// Teste que preenche um caso e valida se os dados foram preenchidos corretamente;
        /// </summary>
        [Test]
        public void VerCasos_ValidarDadosDoCaso()
        {
            PaginaRelatarCaso.Categoria categoria = PaginaRelatarCaso.Categoria.TestePaulo;
            string resumo = "Resumo teste";
            string descricao = "Descrição teste";

            // @arrange
            paginaRelatarCaso.Visita();
            paginaRelatarCaso.RelatarCasoPreenchendoCamposObrigatorios(categoria, resumo, descricao);

            // @act
            itensGeraisMantis.ClicarEmVisualizarCasoEnviado();

            // @assert
            Assert.AreEqual(paginaVerCasos.DescricaoDoCaso(descricao).Displayed, true);
            Assert.AreEqual(paginaVerCasos.ResumoDoCaso(resumo).Displayed, true);
        }

    }

}
