using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Testes
{

    [TestFixture]
    public class ParametroTest : PaginaBase
    {
        PaginaBase paginaBase = new PaginaBase(new FirefoxDriver());
        PaginaLogin paginaLogin;

        [SetUp]
        public void AcessarPaginaLogin()
        {
            paginaLogin.VisitaPaginaLogin();
            paginaBase.MaximizarTela();
        }

        [TearDown]
        public void FinalizaTesteLogin()
        {
            paginaBase.FecharNavegador();
        }

        [Test]
        public void Teste()
        {

        }



        //private void AdotandoQueUsuarioLogado()
        //{
        //    this.AcessandoPaginaLogin = new PaginaLogin(this.PaginaBase.getDriver());
        //    this.paginaInicial = paginaLogin.logar("admin", "admin123");
        //}

        //private void AcessaMenuParametro()
        //{
        //    this.paginaParametros = paginaInicial.acessaPaginaDeParametros();
        //}

        //private void VerificaValorParametro()
        //{
        //    Assert.assertEquals("30", this.paginaParametros.obterValorParametro("prTempMax"));
        //}

        //private void ConfirmaEntaoParametros()
        //{
        //    this.paginaParametros.confirmarParametros();
        //}

        //private void FechaNavegador()
        //{
        //    this.paginaBase.closeNavegator();
        //}

    }

}
