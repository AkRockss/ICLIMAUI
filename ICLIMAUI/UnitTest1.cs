using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.XmlTransform;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ICLIMAUI
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\WebDriver";

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory); // fast
           // _driver = new FirefoxDriver(DriverDirectory);  // slow
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }


        [TestMethod]
        public void TestMethod()
        {
            //string urlOnCom = "file:///C:/Users/Sande/Desktop/3.%20semester/Afleveringer/EksamensProjekt/weather/index.html";
            string urlOnline = "https://iclima.azurewebsites.net/";
            //string urlOnLocal = "http://127.0.0.1:5501/index.html";
            _driver.Navigate().GoToUrl(urlOnline);

            Assert.AreEqual("Selenium", _driver.Title);

            //CLICKING THE GET ALL BUTTON

            IWebElement buttonElementGetAll = _driver.FindElement(By.Id("getAllButton"));
            buttonElementGetAll.Click();

            IWebElement buttonElementControlePanel = _driver.FindElement(By.Id("getAllButton"));
            buttonElementGetAll.Click();

            //TESTING CONTROLEPANEL BUTTON WORKING FORWARDING TOO RIGHT URL

            _driver.FindElement(By.XPath("// html / body / div / div / div / div[1] / ul / li[2] / a")).Click();

            Assert.AreEqual("https://iclima.azurewebsites.net/controlePanel.html", _driver.Url);


            //TESTING THAT INPUT WORKS ON TEMPERATURE CHANGE IN CONTROLEPANEL

     
            //CCS SELECTOR::

            System.Threading.Thread.Sleep(5000);
           _driver.FindElement(By.Id("inputField1")).SendKeys("666");
            
            System.Threading.Thread.Sleep(5000);
            _driver.FindElement(By.Id("button")).Click();


            System.Threading.Thread.Sleep(5000);
            IWebElement outputElement = _driver.FindElement(By.Id("outputElement"));

            System.Threading.Thread.Sleep(5000);
            string text = outputElement.Text;

     
            Assert.IsTrue(text.Contains("22666"));


        }


    }
}
