using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
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
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$txtEmailID")).SendKeys("61053682");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$txtPassword")).SendKeys("smile1510");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$CndSignIn")).Click();
            driver.Navigate().GoToUrl(todayTaskPath);

            Console.WriteLine("Response strted.............");

            WebRequest request = WebRequest.Create(todayTaskPath);
            WebResponse response = request.GetResponse();

            Console.WriteLine("Gotccha.....................");


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

        }

        public void ExecuteClicks(int strt =1 , int stp = 250)
        {
            for (int i = strt; i <= stp; i++)
            {
                Console.WriteLine(string.Format("clicking row:{0} link", i));
                try
                {
                    if (i <= 20)
                    {
                        driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + "t");
                        driver.Navigate().GoToUrl(todayTaskPath);

                        if (driver.FindElements(By.XPath(".//*[@id='ctl00_ContentPlaceHolder1_UpPanel1']/div/table/tbody/tr["
                            + (i + 1) + "]/td[4]/div/table/tbody/tr/td[1]/div/a")).Count > 0)
                        {
                            driver.FindElement(By.XPath(".//*[@id='ctl00_ContentPlaceHolder1_UpPanel1']/div/table/tbody/tr["
                                    + (i + 1) + "]/td[4]/div/table/tbody/tr/td[1]/div/a")).Click();
                        }
                    }

                    else
                    {
                        driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + "\t");
                        driver.Navigate().Refresh();
                        if (driver.FindElements(By.XPath(".//*[@id='ctl00_ContentPlaceHolder1_UpPanel1']/div/table/tbody/tr["
                            + (i + 1) + "]/td[4]/div/table/tbody/tr/td[1]/div/a")).Count > 0)
                        {
                            driver.FindElement(By.XPath(".//*[@id='ctl00_ContentPlaceHolder1_UpPanel1']/div/table/tbody/tr["
                                    + (i + 1) + "]/td[4]/div/table/tbody/tr/td[1]/div/a")).Click();

                        }
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
