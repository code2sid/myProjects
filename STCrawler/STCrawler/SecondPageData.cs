﻿using System;
using System.IO;
using System.Net;
using System.Text;

namespace STCrawler
{
    class SecondPageData
    {
        internal string GetSecondaryLoginPage(string loginurl, string secondurl, string username, string password, string cookieName = null)
        {
            string formData = @"ctl00%24ContentPlaceHolder1%24txtEmailID={0}&ctl00%24ContentPlaceHolder1%24txtPassword={1}&ctl00%24ContentPlaceHolder1%24CndSignIn=LOGIN";

            string postData1 = String.Format(
   "__VIEWSTATE={0}&UsernameTextBox={1}&PasswordTextBox={2}&LoginButton=Login",
   "", username, password);

            // Create a request using a URL that can receive a post. 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(loginurl);
            // Set the Method property of the request to POST.
            request.Method = "POST";

            CookieContainer container = new CookieContainer();

            if (cookieName != null)
                container.Add(new Cookie(cookieName, username, "/", new Uri(loginurl).Host));

            request.CookieContainer = container;

            // Create POST data and convert it to a byte array.  Modify this line accordingly
            string postData = String.Format(formData, username, password);

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            using (StreamWriter outfile =
            new StreamWriter("output.html"))
            {
                outfile.Write(responseFromServer.ToString());
            }

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            request = (HttpWebRequest)WebRequest.Create(secondurl);
            request.CookieContainer = container;

            response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            reader = new StreamReader(dataStream);
            // Read the content.
            responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }


        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
