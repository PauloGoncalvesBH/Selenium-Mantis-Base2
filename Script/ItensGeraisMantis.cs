using OpenQA.Selenium;

namespace PageObjects
{
    public class ItensGeraisMantis
    {
        IWebDriver driver;
        int timeoutTempoEmSegundos;

        public ItensGeraisMantis(IWebDriver driver, int timeoutTempoEmSegundos)
        {
            this.driver = driver;
            this.timeoutTempoEmSegundos = timeoutTempoEmSegundos;
        }

        /// <summary>
        /// Método utilizado para validar se a mensagem de 'Operação realizada com sucesso' está presente;
        /// </summary>
        /// <returns></returns>
        public IWebElement MensagemOperacaoRealizadaComSucesso()
        {
            return driver.FindElement(ByMensagemOperacaoRealizadaComSucesso());
        }

        /// <summary>
        /// Método utilizado para validar se a mensagem 'Operação realizada com sucesso' não está presente;
        /// </summary>
        /// <returns></returns>
        public By ByMensagemOperacaoRealizadaComSucesso()
        {
            return By.XPath("//div[contains(text(), 'Operação realizada com sucesso.')]");
        }

        /// <summary>
        /// Método utilizado para validar se a mensagem 'APPLICATION ERROR #11' está presente;
        /// </summary>
        /// <returns></returns>
        public IWebElement Erro11CampoObrigatorioNaoPreenchido()
        {
            return driver.FindElement(By.XPath("//td[text()='APPLICATION ERROR #11']"), timeoutTempoEmSegundos);
        }

        /// <summary>
        /// Método utilizado para clicar no hiperlink 'Visualizar Caso Enviado';
        /// </summary>
        public void ClicarEmVisualizarCasoEnviado()
        {
            driver.FindElement(By.XPath("//a[contains(text(), 'Visualizar Caso Enviado')]"), timeoutTempoEmSegundos).Click();
        }
    }
}
