using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Wait = SeleniumExtras.WaitHelpers;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirefoxDriver driver = new FirefoxDriver();

            //#region Pagina de Login
            //try
            //{
            //    driver.Navigate().GoToUrl(UrlLogin); //carregando pagina de login
            //    driver.FindElementById("Email").SendKeys(Text); //preenchendo email
            //    driver.FindElementById("Senha").SendKeys(Senha); //preenchendo senha
            //    driver.FindElementById("btnEntrar").Click(); //clicando no botao entrar

            //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("linkSairSistema"))));//aguardando entrar no sistema
            //    Console.WriteLine("Acessou o sistema com sucesso");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Houve o seguinte erro ao tentar acessar o sistema: {ex.Message}");
            //}
            //#endregion

            //#region Pagina de empresa
            //try
            //{
            //    driver.Navigate().GoToUrl(UrlEmpresa); //carregando pagina para adicionar a empresa
            //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("CPF_CNPJ"))));//aguardando carregamento do elemento da pagina
            //    Console.WriteLine("Carregou a pagina de adicao da empresa com sucesso");

            //    //fazendo o 
            //    //aqui tive que fazer por action por causa do javascript maldito que faz placeholder e nao libera o botao se nao teclar
            //    Actions actions = new Actions(driver);
            //    IWebElement cpf_cnpj = driver.FindElementById("CPF_CNPJ");
            //    actions.MoveToElement(cpf_cnpj);
            //    actions.Click();
            //    actions.SendKeys("09.509.531/0010-70");
            //    actions.Build().Perform();

            //    //buscando o cnpj
            //    driver.FindElementById("btnCnpj").Click();
            //    new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("toast-container")));//aguardando carregamento da pagina

            //    //adicionando nome fantasia
            //    IWebElement nomeFantasia = driver.FindElementById("NomeFantasia");
            //    nomeFantasia.Clear();
            //    nomeFantasia.SendKeys("@Selenium");

            //    //adicionando razão social
            //    IWebElement razaoSocial = driver.FindElementById("RazaoSocial");
            //    razaoSocial.Clear();
            //    razaoSocial.SendKeys("@Selenium");

            //    //selecionando o segmento
            //    IWebElement clickSegmento = driver.FindElementById("select2-IdTipoEmpresa-container");
            //    clickSegmento.Click();
            //    ReadOnlyCollection<IWebElement> segmentos = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
            //    foreach (IWebElement segmento in segmentos)
            //    {
            //        if (segmento.Text.ToLower() == "industria")
            //        {
            //            segmento.Click();
            //            break;
            //        }
            //    }

            //    driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[1]/div[18]/div[1]/div/div[1]").Click();
            //    driver.FindElementById("DataInicialPadraoAnaliseMensal").SendKeys("01/01/2019");
            //    driver.FindElementById("DataFinalPadraoAnaliseMensal").SendKeys("01/05/2019");

            //    //clicar no botao de submeter
            //    driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[2]/div/div/button").Click();

            //    new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("empresas")));
            //    Console.WriteLine("Salvou a empresa com sucesso");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Houve o seguinte erro ao tentar salvar a empresa: {ex.Message}");
            //}
            //#endregion

            //#region Página da Area
            //try
            //{
            //    driver.Navigate().GoToUrl(UrlArea); //carregando pagina para adicionar a area                
            //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("Nome"))));
            //    Console.WriteLine("Carregou a pagina de adicao da área com sucesso");

            //    //selecionando o contratante
            //    IWebElement clickSegmento = driver.FindElementById("select2-IdEmpresa-container");
            //    clickSegmento.Click();
            //    ReadOnlyCollection<IWebElement> segmentos = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
            //    foreach (IWebElement segmento in segmentos)
            //    {
            //        if (segmento.Text.ToLower() == "@selenium")
            //        {
            //            segmento.Click();
            //            break;
            //        }
            //    }

            //    //aguardando a busca
            //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.InvisibilityOfElementLocated((By.Id("overlay-background"))));

            //    //adicionando nome da area
            //    IWebElement nomeFantasia = driver.FindElementById("Nome");
            //    nomeFantasia.Clear();
            //    nomeFantasia.SendKeys("Selenium");

            //    //clicar no botao de submeter
            //    driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[2]/div/div/button").Click();

            //    new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("areas")));
            //    Console.WriteLine("Salvou a area com sucesso");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Houve o seguinte erro ao tentar adicionar a área: {ex.Message}");
            //}
            //#endregion

            //#region Página da Amostragem
            //try
            //{
            //    //chamar a pagina de amostragem                
            //    driver.Navigate().GoToUrl(UrlAmostragem);
            //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("select2-idTipoAmostragem-container"))));
            //    Console.WriteLine("Carregou a pagina de adicao da amostragem com sucesso");

            //    //escolher tipo de amostragem Valor real
            //    IWebElement clickTipo = driver.FindElementById("select2-idTipoAmostragem-container");
            //    clickTipo.Click();
            //    ReadOnlyCollection<IWebElement> tipos = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
            //    foreach (IWebElement tipo in tipos)
            //    {
            //        if (tipo.Text.ToLower() == "valor real")
            //        {
            //            tipo.Click();
            //            break;
            //        }
            //    }

            //    //escolher contratante @Selenium
            //    IWebElement clickContratante = driver.FindElementById("select2-IdEmpresa-container");
            //    clickContratante.Click();
            //    ReadOnlyCollection<IWebElement> contratantes = driver.FindElementsByXPath("/html/body/span/span/span[2]/ul/li");
            //    foreach (IWebElement contratante in contratantes)
            //    {
            //        if (contratante.Text.ToLower() == "@selenium")
            //        {
            //            contratante.Click();
            //            break;
            //        }
            //    }

            //    //clicando no botao adicionar
            //    driver.FindElementById("Adicionar-Faixa").Click();
            //    driver.FindElementByClassName("txtQuantidadeAdmitidos").SendKeys("1");
            //    driver.FindElementByClassName("txtQuantidadeDemitidos").SendKeys("1");
            //    driver.FindElementByClassName("txtQuantidadeAtivos").SendKeys("3");
            //    driver.FindElementByClassName("txtFaixaInicial").SendKeys("0");
            //    driver.FindElementByClassName("txtFaixaFinal").SendKeys("9999");
            //    driver.FindElementByClassName("txtQuantidadeMinima").SendKeys("1");


            //    //clicar no botao de submeter
            //    driver.FindElementById("btn-salvar-amostragem").Click();

            //    new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(Wait.ExpectedConditions.ElementExists(By.Id("amostragenscolaborador")));
            //    Console.WriteLine("Salvou a amostragem com sucesso");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Houve o seguinte erro ao tentar adicionar a amostragem: {ex.Message}");
            //}
            //#endregion

            //Console.WriteLine("Fim");            
        }

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl(UrlLogin);
            Console.WriteLine("Acessando a pagina");
        }

        [Test]
        public void ExecuteTest()
        {
            driver.Navigate().GoToUrl(UrlLogin);
            driver.FindElementById("Email").SendKeys(Text);
            driver.FindElementById("Senha").SendKeys(Senha);
            driver.FindElementById("btnEntrar").Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(Wait.ExpectedConditions.ElementExists((By.Id("linkSairSistema"))));

            Console.WriteLine("Executando teste");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            Console.WriteLine("Fechando o browser");
        }
    }
}
