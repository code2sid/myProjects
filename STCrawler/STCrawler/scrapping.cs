using System;
using System.IO;
using System.Net;
using System.Web;

namespace STCrawler
{
    public class scrapping
    {

        private string ExtractViewState(string s)
        {
            string viewStateNameDelimiter = "__VIEWSTATE";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter);
            int viewStateValuePosition = s.IndexOf(
                  valueDelimiter, viewStateNamePosition
               );

            int viewStateStartPosition = viewStateValuePosition +
                                         valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition);

            return HttpUtility.UrlEncodeUnicode(
                     s.Substring(
                        viewStateStartPosition,
                        viewStateEndPosition - viewStateStartPosition
                     )
                  );
        }


        public void ProcessRequest(string username, string password, string login_url,string page_url)
        {
            // first, request the login form to get the viewstate value
            HttpWebRequest webRequest = WebRequest.Create(login_url) as HttpWebRequest;
            StreamReader responseReader = new StreamReader(
                  webRequest.GetResponse().GetResponseStream()
               );
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = ExtractViewState(responseData);
            string postData =
                  String.Format(
                     @"
                       __VIEWSTATE={0}&
                       __VIEWSTATEGENERATOR=C2EE9ABB&ctl00%24HFSessionID=&
                       ctl00%24ContentPlaceHolder1%24txtEmailID={1}&
                       ctl00%24ContentPlaceHolder1%24txtPassword={2}&
                       ctl00%24ContentPlaceHolder1%24CndSignIn=LOGIN"
                     , viewState, username, password
                  );

            // have a cookie container ready to receive the forms auth cookie
            CookieContainer cookies = new CookieContainer();

            // now post to the login form
            webRequest = WebRequest.Create(login_url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;

            // write the form values into the request message
            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();

            // we don't need the contents of the response, just the cookie it issues
            webRequest.GetResponse().Close();

            // now we can send out cookie along with a request for the protected page
            webRequest = WebRequest.Create(page_url) as HttpWebRequest;
            webRequest.CookieContainer = cookies;
            responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());

            // and read the response
            responseData = responseReader.ReadToEnd();
            responseReader.Close();

            Console.WriteLine(responseData);
        }


    }
}
