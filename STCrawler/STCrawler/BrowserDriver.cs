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
using System.Threading;

namespace STCrawler
{
    [TestFixture]
    [Parallelizable]
    class BrowserDriver
    {
        public static event ConsoleCancelEventHandler CancelKeyPress;
        private IWebDriver driver;
        public IList<string> allWindowHandles = null;
        string sitePath = "https://socialtrade.biz";
        int weLeftOn = 1;
        int reAttempts = 10;
        //public readonly ProgressBar pb = new ProgressBar();

        public void setup()
        {

            Console.Clear();
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);


            Console.WriteLine("Which driver (c/m/i)");
            var opt = Console.ReadLine();
            if (opt.ToLower().Contains("m"))
                driver = new FirefoxDriver();
            else if (opt.ToLower().Contains("c"))
                driver = new ChromeDriver(STConfigurations.Default.ChromePath);
            else
                driver = new FirefoxDriver();

            Console.Clear();
        }

        public void ClickController()
        {
            testConnection();

            if (driver.Title.ToLower().Contains("maintenance"))
            {
                Console.WriteLine("its is in under maintenance !!!!! try out after some time... Bbye !!!!");
                Console.ReadLine();
                return;
            }

            login_GetWork();
            Console.Clear();

            Console.Write("Pick you option:\n\r 1)Range \n\r 2)Specific Rows ");
            var opt = Console.ReadLine();
            Console.Clear();

            if (opt.CompareTo("2") == 0)
                Console.WriteLine("Enter ur Row Numbers(separated by space): ");
            else
                Console.Write("Do u knw the break number ? ");

            var input = Console.ReadLine();
            Console.Clear();


            var rows = input.Split(' ');
            try
            {
                if (rows.Count() > 1)
                    ExecuteClicks(rows);
                else
                    ExecuteClicks(strt: weLeftOn = int.Parse(rows[0]), singleTab: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Re-run attempts = {0}", reAttempts = int.Parse(STConfigurations.Default.ReAttempts)));
                testConnection();
                for (int reAttemCntr = 0; reAttemCntr < reAttempts; reAttemCntr++)
                    ExecuteClicks(strt: weLeftOn, singleTab: true);
            }
        }

        public void testConnection()
        {
            Console.Write("testing Connection...");
            try
            {
                driver.Navigate().GoToUrl(sitePath);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not in mood.... Go fuck around somewhere else !!!!");
                Console.ReadLine();
                Environment.Exit(0);
            }



        }

        public void login_GetWork()
        {
            Console.Clear();
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

            Console.Clear();
            Console.Write("Logging-in Please be patient...");
            driver.Navigate().GoToUrl(string.Concat(sitePath, "/login.aspx"));

            driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_txtEmailID']")).SendKeys(username);
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_txtPassword']")).SendKeys(password);
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$CndSignIn")).Click();

            Console.Clear();
            Console.Write("Getting todays work...");
            driver.Navigate().GoToUrl(string.Concat(sitePath, "/user/todayTask.aspx"));

            if (driver.FindElement(By.XPath("//*[@id='w2ui-popup']/div[1]/div")) != null)
                driver.FindElement(By.XPath("//*[@id='w2ui-popup']/div[1]/div")).Click();

            if (driver.FindElements(By.Id("ctl00_ContentPlaceHolder1_cmdGetWork")) != null)
                driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdGetWork")).Click();

        }

        public void ExecuteClicks(int strt = 1, int stp = 250, bool singleTab = true)
        {
            var linkNo = "0";
            if (!driver.PageSource.Contains("TodayTask"))
                driver.Navigate().GoToUrl(string.Concat(sitePath, "/user/todayTask.aspx"));

           
            for (int myCntr = strt; myCntr <= stp; myCntr++)
            {
                linkNo = (myCntr + 1).ToString().Length < 2 ? string.Concat("0", myCntr + 1) : (myCntr + 1).ToString();
                Console.WriteLine(string.Format("clicking row:{0} link", myCntr));
                try
                {
                    {
                        if (driver.FindElements(By.XPath(string.Format("//*[@id='ctl00_ContentPlaceHolder1_gvAssignment_ctl{0}_Panel4']/a", linkNo))).Count > 0)
                        {
                            driver.FindElement(By.XPath(string.Format("//*[@id='ctl00_ContentPlaceHolder1_gvAssignment_ctl{0}_Panel4']/a", linkNo))).Click();
                            Thread.Sleep(int.Parse(STConfigurations.Default.SleepBy));
                        }
                    }

                }
                catch (Exception e)
                {
                    weLeftOn = myCntr--;
                }
            }
        }

        public void ExecuteClicks(int strt = 1, int stp = 250)
        {
            var linkNo = "0";
            var tabCnt = 0;

            for (int myCntr = strt; myCntr <= stp; myCntr++)
            {
                linkNo = (myCntr + 1).ToString().Length < 2 ? string.Concat("0", myCntr + 1) : (myCntr + 1).ToString();
                Console.WriteLine(string.Format("clicking row:{0} link", myCntr));
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
                        driver.Navigate().GoToUrl(sitePath);

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
                    weLeftOn = myCntr--;
                    throw;

                }
            }
        }

        public void ExecuteClicks(string[] rows)
        {
            var linkNo = "0";
            var tabCnt = 0;
            int myCntr = 0;
            foreach (var row in rows)
            {
                myCntr = int.Parse(row);

                linkNo = (myCntr + 1).ToString().Length < 2 ? string.Concat("0", myCntr + 1) : (myCntr + 1).ToString();
                Console.WriteLine(string.Format("clicking row:{0} link", myCntr));
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
                        driver.Navigate().GoToUrl(sitePath);

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
                    weLeftOn = myCntr--;
                    throw;

                }



            }
        }

        public void CloseAll()
        {
            Console.Clear();
            Console.WriteLine("Have a break !!!! have a Kit-kat ;)");
            if (driver.CurrentWindowHandle != null)
                driver.Close();
            Console.ReadLine();
        }

        protected void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            CloseAll();
        }
    }
}
