using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // Necessário para ser utilizado em validação que verificar que esse elemento não existe;
        public By ByAcessandoComo()
        {
            return By.ClassName("login-info-left");
        }

        public IWebElement TextoAcessandoComo()
        {
            return driver.FindElement(By.ClassName("login-info-left"), timeoutTempoEmSegundos);
        }

        public IWebElement TextoSenhaUsuarioIncorreta()
        {
            return driver.FindElement(By.XPath("//font[text() = 'Your account may be disabled or blocked or the username/password you entered is incorrect.']"), timeoutTempoEmSegundos);
        }

    }
}
