using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PaginaLogin : PaginaBase
    {
        public PaginaLogin(IWebDriver driver)
        {
            base(driver);
        }

        public void RealizaLogin(String usuario, String senha)
        {
            IWebElement inputUsuario = GetDriver().FindElement(By.Name("username"));
            IWebElement inputSenha = GetDriver().FindElement(By.Name("password"));
            IWebElement botaoLogin = GetDriver().FindElement(By.CssSelector("[value='Login']"));

            inputUsuario.Clear();
            inputUsuario.SendKeys(usuario);
            inputSenha.Clear();
            inputSenha.SendKeys(senha);
            botaoLogin.Click();
        }

    }
}
