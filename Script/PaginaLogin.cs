using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PaginaLogin
    {
        IWebDriver driver;
        int timeoutTempoEmSegundos;

        public PaginaLogin(IWebDriver driver, int timeoutTempoEmSegundos)
        {
            this.driver = driver;
            this.timeoutTempoEmSegundos = timeoutTempoEmSegundos;
        }

        public void RealizaLogin(String usuario, String senha)
        {
            InputUsuario().Clear();
            InputUsuario().SendKeys(usuario);
            InputSenha().Clear();
            InputSenha().SendKeys(senha);
            BotaoLogin().Click();
        }

        public IWebElement InputUsuario()
        {
            return driver.FindElement(By.Name("username"), timeoutTempoEmSegundos);
        }

        public IWebElement BotaoLogin()
        {
            return driver.FindElement(By.CssSelector("[value='Login']"), timeoutTempoEmSegundos);
        }

        public IWebElement InputSenha()
        {
            return driver.FindElement(By.Name("password"), timeoutTempoEmSegundos);
        }

    }
}
