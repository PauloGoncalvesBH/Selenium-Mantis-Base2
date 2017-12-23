using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObjects;

namespace Testes
{

    public class ParametroTest : PaginaBase
    {

        private void AcessandoPaginaLogin()
        {
            NavegarPara("www.google.com.br");
        }

        private void adotandoQueUsuarioLogado()
        {
            this.AcessandoPaginaLogin = new PaginaLogin(this.PaginaBase.getDriver());
            this.paginaInicial = paginaLogin.logar("admin", "admin123");
        }

        private void acessaMenuParametro()
        {
            this.paginaParametros = paginaInicial.acessaPaginaDeParametros();
        }

        private void verificaValorParametro()
        {
            Assert.assertEquals("30", this.paginaParametros.obterValorParametro("prTempMax"));
        }

        private void confirmaEntaoParametros()
        {
            this.paginaParametros.confirmarParametros();
        }

        private void fechaNavegador()
        {
            this.paginaBase.closeNavegator();
        }

    }

}
