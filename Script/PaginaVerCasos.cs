using OpenQA.Selenium;

namespace PageObjects
{

    public class PaginaVerCasos
    {
        IWebDriver driver;
        int timeoutTempoEmSegundos;

        public PaginaVerCasos(IWebDriver driver, int timeoutTempoEmSegundos)
        {
            this.driver = driver;
            this.timeoutTempoEmSegundos = timeoutTempoEmSegundos;
        }

        /// <summary>
        /// Método para validar o campo 'Descrição' do caso;
        /// </summary>
        /// <param name="descricao"></param>
        /// <returns></returns>
        public IWebElement DescricaoDoCaso(string descricao)
        {
            return driver.FindElement(By.XPath("//td[contains(text(), '" + descricao + "')]"), timeoutTempoEmSegundos);
        }

        /// <summary>
        /// Método para validar o campo 'Resumo' do caso;
        /// </summary>
        /// <param name="resumo"></param>
        /// <returns></returns>
        public IWebElement ResumoDoCaso(string resumo)
        {
            return driver.FindElement(By.XPath("//td[contains(text(), '" + resumo + "')]"), timeoutTempoEmSegundos);
        }

    }
}
