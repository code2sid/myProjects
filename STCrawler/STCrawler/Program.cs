using System.Net;

namespace STCrawler
{
    class Program
    {
        public CookieContainer CookieContainer { get; private set; }
        static void Main(string[] args)
        {
            string loginurl = "https://www.socialtrade.biz/login.aspx";
            string secondurl = "https://www.socialtrade.biz/User/TodayTask.aspx#!";

            string username = "61053682";
            string password = "smile1510";
            //var o = new SecondPageData();
            //o.GetSecondaryLoginPage(loginurl, secondurl, username, password);

            //WebBrowser.Navigate("http://www.google.com");


            //var p = new scrapping();
            //p.ProcessRequest(username, password, loginurl, secondurl);


            BrowserDriver m = new BrowserDriver();
            m.setup();
            m.ClickController();




        }

    }



}
