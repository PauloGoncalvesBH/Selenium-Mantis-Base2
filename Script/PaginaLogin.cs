using OpenQA.Selenium;

namespace PageObjects
{
    public class PaginaLogin
    {
        IWebDriver driver;
        public Browser browser;
        int timeoutTempoEmSegundos;

        public PaginaLogin(IWebDriver driver, int timeoutTempoEmSegundos)
        {
            this.driver = driver;
            this.timeoutTempoEmSegundos = timeoutTempoEmSegundos;
        }

        /// <summary>
        /// Método para realizar o login;
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        public void RealizaLogin(string usuario, string senha)
        {
            InputUsuario().Clear();
            InputUsuario().SendKeys(usuario);
            InputSenha().Clear();
            InputSenha().SendKeys(senha);
            BotaoLogin().Click();
        }

        /// <summary>
        /// Método para realizar o login com usuário existente, tirando a necessidade de passar argumentos;
        /// </summary>
        public void RealizarLoginComUsuarioESenhaCorretos()
        {
            string usuario = "paulo.goncalves";
            string senha = "ALTERAR";

            RealizaLogin(usuario, senha);
        }

        /// <summary>
        /// Método para encapsular o input de usuário;
        /// </summary>
        /// <returns></returns>
        public IWebElement InputUsuario()
        {
            return driver.FindElement(By.Name("username"), timeoutTempoEmSegundos);
        }

        /// <summary>
        /// Método para encapsular o botão de login;
        /// </summary>
        /// <returns></returns>
        public IWebElement BotaoLogin()
        {
            return driver.FindElement(By.CssSelector("[value='Login']"), timeoutTempoEmSegundos);
        }

        /// <summary>
        /// Método para encapsular o input de senha;
        /// </summary>
        /// <returns></returns>
        public IWebElement InputSenha()
        {
            return driver.FindElement(By.Name("password"), timeoutTempoEmSegundos);
        }

        /// <summary>
        /// Método para acessar página de login do Mantis;
        /// </summary>
        public void Visita()
        {
            browser = new Browser(driver);
            browser.NavegarPara("http://mantis-prova.base2.com.br");
        }

    }
}
