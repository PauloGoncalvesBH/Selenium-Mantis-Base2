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
    class TestePaginaRelatarCaso
    {
        public Browser browser;
        public PaginaLogin paginaLogin;
        public PrintScreen printScreen;
        public PaginaRelatarCaso paginaRelatarCaso;
        public ItensGeraisMantis itensGeraisMantis;

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

            // @arrange
            browser.MaximizarTela();
            paginaLogin.Visita();
            paginaLogin.RealizarLoginComUsuarioESenhaCorretos();
            paginaRelatarCaso.Visita();
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
        /// Teste que preenche todos os campos obrigatórios de um caso e valida se surge mensagem de 'Operação realizada com sucesso';
        /// </summary>
        [Test]
        public void RelatarCaso_PreencherCamposObrigatoriosESalvar()
        {
            // @act
            paginaRelatarCaso.RelatarCasoPreenchendoCamposObrigatorios(PaginaRelatarCaso.Categoria.TestePaulo, "teste", "resumoteste");

            // @assert
            Assert.AreEqual(itensGeraisMantis.MensagemOperacaoRealizadaComSucesso().Displayed, true);
        }

        /// <summary>
        /// Teste que não preenche os campos obrigatórios e valida se ocorreu erro na inclusão;
        /// </summary>
        [Test]
        public void RelatarCaso_NãoPreencherCampoObrigatorioDescricaoESalvar()
        {
            // @act
            paginaRelatarCaso.RelatarCasoPreenchendoCamposObrigatorios(PaginaRelatarCaso.Categoria.TestePaulo, "resumoteste", "");

            // @assert
            Assert.AreEqual(itensGeraisMantis.Erro11CampoObrigatorioNaoPreenchido().Displayed, true);

            bool presencaOperacaoRealizadaComSucesso = driver.ElementIsPresent(itensGeraisMantis.ByMensagemOperacaoRealizadaComSucesso());
            Assert.AreEqual(presencaOperacaoRealizadaComSucesso, false);
        }

    }

}
