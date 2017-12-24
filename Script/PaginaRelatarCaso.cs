using System;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PaginaRelatarCaso
    {
        IWebDriver driver;
        public Browser browser;
        int timeoutTempoEmSegundos;

        public PaginaRelatarCaso(IWebDriver driver, int timeoutTempoEmSegundos)
        {
            this.driver = driver;
            this.timeoutTempoEmSegundos = timeoutTempoEmSegundos;
        }

        public enum Categoria
        {
            Selecione = 1,
            app_14 = 42,
            Appteste = 43,
            DesafiojMeter = 45,
            General = 1,
            Principado = 34,
            TestePaulo = 47
        }

        /// <summary>
        /// Método que preenche o select 'Categoria', tendo como parâmetro o enum de categorias;
        /// </summary>
        /// <param name="categoria"></param>
        public void PreencherListaCategoria(Categoria categoria)
        {
            driver.FindElement(By.Name("category_id"), timeoutTempoEmSegundos).Click();
            driver.FindElement(By.XPath("//option[@value='"+ (int)categoria + "']"), timeoutTempoEmSegundos).Click();
        }

        /// <summary>
        /// Método para preencher o campo 'Descrição';
        /// </summary>
        /// <param name="descricao"></param>
        public void PreencherTextAreaDescrição(string descricao)
        {
            driver.FindElement(By.Name("description"), timeoutTempoEmSegundos).SendKeys(descricao);
        }

        /// <summary>
        /// Método para preencher o campo 'Resumo';
        /// </summary>
        /// <param name="resumo"></param>
        public void PreencherInputResumo(string resumo)
        {
            driver.FindElement(By.Name("summary"), timeoutTempoEmSegundos).SendKeys(resumo);
        }

        /// <summary>
        /// Método para clicar no botão 'Enviar Relatório';
        /// </summary>
        public void ClicarButtonEnviarRelatorio()
        {
            driver.FindElement(By.XPath("//input[@value='Enviar Relatório']"), timeoutTempoEmSegundos).Click();
        }

        /// <summary>
        /// Método para criar um caso preenchendo apenas os campos obrigatórios;
        /// </summary>
        /// <param name="categoria"></param>
        /// <param name="resumo"></param>
        /// <param name="descricao"></param>
        public void RelatarCasoPreenchendoCamposObrigatorios(Categoria categoria, string resumo, string descricao)
        {
            PreencherListaCategoria(categoria);
            PreencherInputResumo(resumo);
            PreencherTextAreaDescrição(descricao);
            ClicarButtonEnviarRelatorio();
        }

        /// <summary>
        /// Método para acessar a página de relatar caso do Mantis;
        /// </summary>
        public void Visita()
        {
            browser = new Browser(driver);
            browser.NavegarPara("http://mantis-prova.base2.com.br/bug_report_page.php");
        }
    }
}
