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

        public void VisitaPaginaLogin()
        {
            NavegarPara("http://mantis-prova.base2.com.br");
        }

    }
}
