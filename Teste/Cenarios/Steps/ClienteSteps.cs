using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Teste.Cenarios.Steps
{
    [Binding]
    public sealed class ClienteSteps
    {
        [Given(@"que sou um cliente, irei acessar https://localhost:44309/Api")]
        
        public void DadoQueSouUmClienteIreiAcessarHttpsLocalhostApi(string p0)
        {
            ScenarioContext.Current["Endpoint"] = p0;
        }

    }
}
