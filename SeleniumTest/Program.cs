using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using Wait = SeleniumExtras.WaitHelpers;

namespace SeleniumTest
{
    class Program
    {
        private const string UrlLogin = "http://localhost:3000/Login";
        private const string UrlEmpresa = "http://localhost:3000/Empresas/Adicionar";
        private const string UrlArea = "http://localhost:3000/Areas/Adicionar";
        private const string UrlAmostragem = "http://localhost:3000/AmostragensColaboradorCompetencia/Adicionar";
        private const string UrlContratos = "http://localhost:3000/Contratos/Adicionar";
        private const string UrlConfAnalise = "http://localhost:3000/ConfiguracoesAnaliseCompetencia/Adicionar";
        private const string Text = "admin@testetechvirtus.com.br";
        private const string Senha = "123456";

        static void Main(string[] args)
        {
            FirefoxDriver firefoxDriver = new FirefoxDriver();
            FirefoxDriver driver = firefoxDriver;

            #region Pagina de Login
            try
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(UrlLogin); //carregando pagina de login
                driver.FindElementById("Email").SendKeys(Text); //preenchendo email
                driver.FindElementById("Senha").SendKeys(Senha); //preenchendo senha
                driver.FindElementById("btnEntrar").Click(); //clicando no botao entrar

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("linkSairSistema"))));//aguardando entrar no sistema
                Console.WriteLine("Acessou o sistema com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve o seguinte erro ao tentar acessar o sistema: {ex.Message}");
            }
            #endregion

            #region Pagina de empresa
            try
            {
                driver.Navigate().GoToUrl(UrlEmpresa); //carregando pagina para adicionar a empresa
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("CPF_CNPJ"))));//aguardando carregamento do elemento da pagina
                Console.WriteLine("Carregou a pagina de adicao da empresa com sucesso");

                //fazendo o 
                //aqui tive que fazer por action por causa do javascript maldito que faz placeholder e nao libera o botao se nao teclar
                Actions actions = new Actions(driver);
                IWebElement cpf_cnpj = driver.FindElementById("CPF_CNPJ");
                actions.MoveToElement(cpf_cnpj);
                actions.Click();
                actions.SendKeys("09.509.531/0010-70");
                actions.Build().Perform();

                //buscando o cnpj
                driver.FindElementById("btnCnpj").Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("toast-container")));//aguardando carregamento da pagina

                //adicionando nome fantasia
                IWebElement nomeFantasia = driver.FindElementById("NomeFantasia");
                nomeFantasia.Clear();
                nomeFantasia.SendKeys("@Selenium");

                //adicionando razão social
                IWebElement razaoSocial = driver.FindElementById("RazaoSocial");
                razaoSocial.Clear();
                razaoSocial.SendKeys("@Selenium");

                //selecionando o segmento
                IWebElement clickSegmento = driver.FindElementById("select2-IdTipoEmpresa-container");
                clickSegmento.Click();
                ReadOnlyCollection<IWebElement> segmentos = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement segmento in segmentos)
                {
                    if (segmento.Text.ToLower() == "industria")
                    {
                        segmento.Click();
                        break;
                    }
                }

                driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[1]/div[18]/div[1]/div/div[1]").Click();
                driver.FindElementById("DataInicialPadraoAnaliseMensal").SendKeys("01/01/2019");
                driver.FindElementById("DataFinalPadraoAnaliseMensal").SendKeys("01/05/2019");

                //clicar no botao de submeter
                driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[2]/div/div/button").Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("empresas")));
                Console.WriteLine("Salvou a empresa com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve o seguinte erro ao tentar salvar a empresa: {ex.Message}");
            }
            #endregion

            #region Página da Area
            try
            {
                driver.Navigate().GoToUrl(UrlArea); //carregando pagina para adicionar a area                
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("Nome"))));
                Console.WriteLine("Carregou a pagina de adicao da área com sucesso");

                //selecionando o contratante
                IWebElement clickSegmento = driver.FindElementById("select2-IdEmpresa-container");
                clickSegmento.Click();
                ReadOnlyCollection<IWebElement> segmentos = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement segmento in segmentos)
                {
                    if (segmento.Text.ToLower() == "@selenium")
                    {
                        segmento.Click();
                        break;
                    }
                }

                //aguardando a busca
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.InvisibilityOfElementLocated((By.Id("overlay-background"))));

                //adicionando nome da area
                IWebElement nomeFantasia = driver.FindElementById("Nome");
                nomeFantasia.Clear();
                nomeFantasia.SendKeys("Selenium");

                //clicar no botao de submeter
                driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[2]/div/div/button").Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("areas")));
                Console.WriteLine("Salvou a area com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve o seguinte erro ao tentar adicionar a área: {ex.Message}");
            }
            #endregion

            #region Página da Amostragem
            try
            {
                //chamar a pagina de amostragem                
                driver.Navigate().GoToUrl(UrlAmostragem);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("select2-idTipoAmostragem-container"))));
                Console.WriteLine("Carregou a pagina de adicao da amostragem com sucesso");

                //escolher tipo de amostragem Valor percentual
                IWebElement clickTipo = driver.FindElementById("select2-idTipoAmostragem-container");
                clickTipo.Click();
                ReadOnlyCollection<IWebElement> tipos = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement tipo in tipos)
                {
                    if (tipo.Text.ToLower() == "valor percentual")
                    {
                        tipo.Click();
                        break;
                    }
                }

                //escolher contratante @Selenium
                IWebElement clickContratante = driver.FindElementById("select2-IdEmpresa-container");
                clickContratante.Click();
                ReadOnlyCollection<IWebElement> contratantes = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement contratante in contratantes)
                {
                    if (contratante.Text.ToLower() == "@selenium")
                    {
                        contratante.Click();
                        break;
                    }
                }

                //clicando no botao adicionar
                driver.FindElementById("Adicionar-Faixa").Click();
                driver.FindElementByClassName("txtQuantidadeAdmitidos").SendKeys("20");
                driver.FindElementByClassName("txtQuantidadeDemitidos").SendKeys("20");
                driver.FindElementByClassName("txtQuantidadeAtivos").SendKeys("60");
                driver.FindElementByClassName("txtFaixaInicial").SendKeys("0");
                driver.FindElementByClassName("txtFaixaFinal").SendKeys("9999");
                driver.FindElementByClassName("txtQuantidadeMinima").SendKeys("10");


                //clicar no botao de submeter
                driver.FindElementById("btn-salvar-amostragem").Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("amostragenscolaborador")));
                Console.WriteLine("Salvou a amostragem com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve o seguinte erro ao tentar adicionar a amostragem: {ex.Message}");
            }
            #endregion

            #region Página de Contrato
            try
            {
                //chamar a pagina de contrato                
                driver.Navigate().GoToUrl(UrlContratos);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("select2-IdEmpresaCliente-container"))));
                Console.WriteLine("Carregou a pagina de adicao de contrato com sucesso");

                //escolher a empresa
                IWebElement clickEmpresa = driver.FindElementById("select2-IdEmpresaCliente-container");
                clickEmpresa.Click();
                ReadOnlyCollection<IWebElement> empresas = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement empresa in empresas)
                {
                    if (empresa.Text.ToLower() == "@selenium")
                    {
                        empresa.Click();
                        break;
                    }
                }

                //aguardando a busca
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.InvisibilityOfElementLocated((By.Id("overlay-background"))));

                //adicionando numero do contrato
                IWebElement nomeFantasia = driver.FindElementById("Numero");
                nomeFantasia.Clear();
                nomeFantasia.SendKeys("Selenium123");

                //escolhendo responsavel do contratante
                IWebElement clickResponsavel = driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[1]/div[4]/div/div/span/div/button/span");
                clickResponsavel.Click();
                IWebElement clickAdmin = driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[1]/div[4]/div/div/span/div/ul/li[3]/a/label");
                clickAdmin.Click();
                clickResponsavel.Click();

                //escolhendo a empresa tomadora
                IWebElement clickTomadora = driver.FindElementById("select2-IdEmpresaTomadora-container");
                clickTomadora.Click();
                ReadOnlyCollection<IWebElement> tomadoras = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement tomadora in tomadoras)
                {
                    if (tomadora.Text.ToLower() == "@selenium")
                    {
                        tomadora.Click();
                        break;
                    }
                }

                //escolhendo a area
                IWebElement clickArea = driver.FindElementById("select2-IdAreaTomadora-container");
                clickArea.Click();
                ReadOnlyCollection<IWebElement> areas = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement area in areas)
                {
                    if (area.Text.ToLower() == "selenium")
                    {
                        area.Click();
                        break;
                    }
                }

                //escolhendo a prestadora
                IWebElement clickPrestadora = driver.FindElementById("select2-IdEmpresaPrestadora-container");
                clickPrestadora.Click();
                ReadOnlyCollection<IWebElement> prestadoras = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement prestadora in prestadoras)
                {
                    if (prestadora.Text.ToLower() == "3ra comercio, consultoria e servicos de informatica ltda - 07.616.010/0001-03")
                    {
                        prestadora.Click();
                        break;
                    }
                }

                //escolhendo o tipo de competencia
                IWebElement clickTipo = driver.FindElementById("select2-IdTipoCompetenciaPadrao-container");
                clickTipo.Click();
                ReadOnlyCollection<IWebElement> tipos = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement tipo in tipos)
                {
                    if (tipo.Text.ToLower() == "mensal")
                    {
                        tipo.Click();
                        break;
                    }
                }

                driver.FindElementById("DescricaoServico").SendKeys("Teste Selenium");
                driver.FindElementById("LocalServico").SendKeys("Recife");
                driver.FindElementById("DataInicial").SendKeys("01/01/2019");
                driver.FindElementById("DataFinal").SendKeys("01/05/2019");


                //salvar
                driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[2]/div/div/button").Click();

                //aguardando salvar
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("contratacoes")));
                Console.WriteLine("Salvou o contrato com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve o seguinte erro ao tentar adicionar o contrato: {ex.Message}");
            }
            #endregion

            #region Página de Configuracao Analise
            try
            {
                driver.Navigate().GoToUrl(UrlConfAnalise);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("select2-IdEmpresa-container"))));
                Console.WriteLine("Carregou a pagina de adicao de configuracao de Analise");

                //escolher a empresa
                IWebElement clickEmpresa = driver.FindElementById("select2-IdEmpresa-container");
                clickEmpresa.Click();
                ReadOnlyCollection<IWebElement> empresas = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
                foreach (IWebElement empresa in empresas)
                {
                    if (empresa.Text.ToLower() == "@selenium")
                    {
                        empresa.Click();
                        break;
                    }
                }

                //adicionando escopo
                IWebElement clickEscopo = driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div/div[1]/div[5]/ul/li[1]/a/span/i");
                clickEscopo.Click();

                //abrir area do escopo
                IWebElement clickAreaEscopo = driver.FindElementByXPath("/ html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div/div[1]/div[5]/div/div[1]/div/div/div[1]/ul/li/i[2]");
                clickAreaEscopo.Click();

                //adicionando caged ao escopo
                Actions ac = new Actions(driver);
                IWebElement source = driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div/div[1]/div[5]/div/div[1]/div/div/div[2]/ul/li[4]");
                IWebElement target = driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div/div[1]/div[5]/div/div[1]/div/div/div[1]/ul/li/div[2]/ul");

                ac.DragAndDrop(source, target);
                ac.Build().Perform();

                //busca cartao de ponto
                Actions ab = new Actions(driver);
                IWebElement busca = driver.FindElementById("procurar-objeto-analise-mensal");
                ab.MoveToElement(busca);
                ab.Click();
                ab.SendKeys("ponto");
                ab.Build().Perform();

                //adiciona cartao de ponto
                Actions ap = new Actions(driver);
                IWebElement ponto = driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div/div[1]/div[5]/div/div[1]/div/div/div[2]/ul/li[21]/b/p");

                ap.DragAndDrop(ponto, target);
                ap.Build().Perform();

                //salvar a configuracao
                driver.FindElementById("salvar").Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementIsVisible(By.Id("Modal-Informacao")));
                driver.FindElementById("btn-Salvar-Com-Informacao").Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("configuracoes")));
                Console.WriteLine("Salvou a configuracao com sucesso");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Houve o seguinte erro ao tentar adicionar a análise: {ex.Message}");
            }
            #endregion

            Console.WriteLine("Fim");



            //driver.Close();
        }
    }
}
