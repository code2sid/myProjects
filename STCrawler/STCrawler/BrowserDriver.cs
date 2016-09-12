using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections;
using System.Net;

namespace STCrawler
{
    [TestFixture]
    [Parallelizable]
    class BrowserDriver
    {
        private IWebDriver driver;
        string todayTaskPath = "https://www.socialtrade.biz/User/TodayTask.aspx";
        int weLeftOn = 1;

        [SetUp]
        public void setup()
        {

            Console.WriteLine("Which driver (c/m/i)");
            var opt = Console.ReadLine();
            if (opt.ToLower().Contains("m"))
                driver = new FirefoxDriver();
            else if (opt.ToLower().Contains("c"))
                driver = new ChromeDriver(@"C:\Users\siddharth.gupta\AppData\Local\Google\Chrome SxS\Application");
            else
                driver = new FirefoxDriver();
        }

        public void testConnection()
        {
            try
            {
                driver.Navigate().GoToUrl(todayTaskPath);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not in mood.... Go fuck around somewhere else !!!!");
                Console.ReadLine();
                Environment.Exit(0);
            }

        }

        [Test]
        public void ClickController()
        {
            Console.Write("Do u knw the break number ? ");
            weLeftOn = int.Parse(Console.ReadLine());
            testConnection();
            if (driver.Title.ToLower().Contains("maintenance"))
            {
                Console.WriteLine("its is in under maintenance !!!!! try out after some time... Bbye !!!!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter username: ");
            var username = Console.ReadLine();
            var password = "smile1510";
            if (string.Compare(username, "ruchi") == 0)
                username = "61053682";
            else
            {
                Console.WriteLine("Enter password: ");
                password = Utilitiy.ReadLineMasked();
            }

            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$txtEmailID")).SendKeys(username);
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$txtPassword")).SendKeys(password);
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$CndSignIn")).Click();
            driver.Navigate().GoToUrl(todayTaskPath);

            Console.WriteLine("Response strted.............");

            //WebRequest request = WebRequest.Create(todayTaskPath);
            //WebResponse response = request.GetResponse();

            Console.WriteLine("Gotccha my Response.........");


            if (driver.FindElements(By.Name("ctl00$ContentPlaceHolder1$cmdGetWork")).Count > 0)
                driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$cmdGetWork")).Click();

            try
            {
                ExecuteClicks(strt: weLeftOn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Have a break !!!! have a Kit-kat ;)");
                Console.WriteLine("Do u want to re-run (haan/nahi)");
                var option = Console.ReadLine();
                if (option.ToLower().Contains("h"))
                {
                    testConnection();
                    ExecuteClicks(strt: weLeftOn);
                }

            }

        }//*[@id="ctl00_ContentPlaceHolder1_gvAssignment_ctl03_Panel4"]/a
        //*[@id="ctl00_ContentPlaceHolder1_gvAssignment_ctl10_Panel4"]

        public void ExecuteClicks(int strt = 1, int stp = 250)
        {
            var linkNo = "0";
            var tabCnt = 0;
            IList<string> allWindowHandles = null;
            
            for (int i = strt; i <= stp; i++)
            {
                linkNo = (i + 1).ToString().Length < 2 ? string.Concat("0", i + 1) : (i + 1).ToString();
                Console.WriteLine(string.Format("clicking row:{0} link", i));
                try
                {
                    allWindowHandles = driver.WindowHandles;
                    foreach (var item in allWindowHandles)
                    {
                        if (item == driver.CurrentWindowHandle)
                            tabCnt++;
                    }
                    if (tabCnt <= 20)
                    {
                        driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + "t");
                        driver.Navigate().GoToUrl(todayTaskPath);

                        if (driver.FindElements(By.XPath(string.Format("//*[@id='ctl00_ContentPlaceHolder1_gvAssignment_ctl{0}_Panel4']/a", linkNo))).Count > 0)
                            driver.FindElement(By.XPath(string.Format("//*[@id='ctl00_ContentPlaceHolder1_gvAssignment_ctl{0}_Panel4']/a", linkNo))).Click();
                    }

                    else
                    {
                        driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + "\t");
                        driver.Navigate().Refresh();
                        if (driver.FindElements(By.XPath(string.Format("//*[@id='ctl00_ContentPlaceHolder1_gvAssignment_ctl{0}_Panel4']/a", linkNo))).Count > 0)
                            driver.FindElement(By.XPath(string.Format("//*[@id='ctl00_ContentPlaceHolder1_gvAssignment_ctl{0}_Panel4']/a", linkNo))).Click();
                    }
                }
                catch (Exception e)
                {
                    weLeftOn = i--;
                    throw;

                }



            }
        }

    }
}
