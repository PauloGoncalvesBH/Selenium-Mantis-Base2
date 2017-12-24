using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PaginaLogin
    {
        IWebDriver driver;

        public PaginaLogin(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void RealizaLogin(String usuario, String senha)
        {
            IWebElement inputUsuario = driver.FindElement(By.Name("username"));
            IWebElement inputSenha = driver.FindElement(By.Name("password"));
            IWebElement botaoLogin = driver.FindElement(By.CssSelector("[value='Login']"));

            inputUsuario.Clear();
            inputUsuario.SendKeys(usuario);
            inputSenha.Clear();
            inputSenha.SendKeys(senha);
            botaoLogin.Click();
        }

    }
}
