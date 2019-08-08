using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace SeleniumTest
{
    class Program
    {
        private const string UrlLogin = "http://localhost:3000/Login";
        private const string UrlEmpresa = "http://localhost:3000/Empresas/Adicionar";
        private const string UrlArea = "http://localhost:3000/Areas/Adicionar";
        private const string Text = "admin@testetechvirtus.com.br";
        private const string Senha = "123456";

        static void Main(string[] args)
        {
            FirefoxDriver firefoxDriver = new FirefoxDriver();
            FirefoxDriver driver = firefoxDriver;

            #region Pagina de Login
            try
            {
                driver.Navigate().GoToUrl(UrlLogin); //carregando pagina de login
                driver.FindElementById("Email").SendKeys(Text); //preenchendo email
                driver.FindElementById("Senha").SendKeys(Senha); //preenchendo senha
                driver.FindElementById("btnEntrar").Click(); //clicando no botao entrar

                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("linkSairSistema"))));//aguardando entrar no sistema
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
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("CPF_CNPJ"))));//aguardando carregamento do elemento da pagina
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
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id("toast-container")));//aguardando carregamento da pagina

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

                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id("empresas")));
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
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("Nome"))));
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
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated((By.Id("overlay-background"))));

                //adicionando nome da area
                IWebElement nomeFantasia = driver.FindElementById("Nome");
                nomeFantasia.Clear();
                nomeFantasia.SendKeys("Selenium");

                //clicar no botao de submeter
                driver.FindElementByXPath("/html/body/div[3]/div[2]/div/div[3]/div/div/div[2]/form/div[2]/div/div/button").Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id("divSalvo")));
                Console.WriteLine("Salvou a area com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Houve o seguinte erro ao tentar adicionar a área: {ex.Message}");
            }
            #endregion

            Console.WriteLine("Fim");
        }
    }
}
