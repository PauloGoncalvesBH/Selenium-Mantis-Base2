using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PaginaParametros : PaginaBase
    {

        public String ObterValorParametro(String id)
        {
            return GetDriver().FindElement(By.Id(id)).GetAttribute("value");
        }

        public void ConfirmarParametros()
        {
            GetDriver().FindElement(By.Id("btnConfirm")).Click();
        }
    }
}
