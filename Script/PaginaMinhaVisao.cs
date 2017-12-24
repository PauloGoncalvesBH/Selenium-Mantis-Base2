using OpenQA.Selenium;

namespace PageObjects
{
    public class PaginaMinhaVisao
    {
        IWebDriver driver;
        int timeoutTempoEmSegundos;

        public PaginaMinhaVisao(IWebDriver driver, int timeoutTempoEmSegundos)
        {
            this.driver = driver;
            this.timeoutTempoEmSegundos = timeoutTempoEmSegundos;
        }

        /// <summary>
        ///  Método para validar que o texto 'Acessando como' não está presente;
        /// </summary>
        /// <returns></returns>
        public By ByAcessandoComo()
        {
            return By.ClassName("login-info-left");
        }

        /// <summary>
        /// Método para validar que o texto 'Acessando como' está presente;
        /// </summary>
        /// <returns></returns>
        public IWebElement TextoAcessandoComo()
        {
            return driver.FindElement(ByAcessandoComo(), timeoutTempoEmSegundos);
        }

        /// <summary>
        /// Método para validar a presença de mensagem de usuário ou senha incorretos;
        /// </summary>
        /// <returns></returns>
        public IWebElement TextoSenhaUsuarioIncorreta()
        {
            return driver.FindElement(By.XPath("//font[text() = 'Your account may be disabled or blocked or the username/password you entered is incorrect.']"), timeoutTempoEmSegundos);
        }

    }
}
