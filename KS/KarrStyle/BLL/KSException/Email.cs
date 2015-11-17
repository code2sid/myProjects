using System;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using Icreon.Tools.Email;

namespace KarrStyle.BLL.KSException
{
    public class Email
    {

        /// <summary>
        /// Gets the Email text body from file
        /// </summary>
        public string GetEmailText(string fileName)
        {
            StringBuilder fileContents = null;

            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    fileContents = new StringBuilder(sr.ReadToEnd());
                }
            }
            else
            {
                throw new FileNotFoundException("The email template " + fileName +
                                            "is not found or access denied.", fileName);
            }
            return fileContents.ToString();
        }


        /// <summary>
        /// Sends the email
        /// </summary>
        public bool SendMail(string toAddress, string ccAddress, string subject, string body, bool isBodyHtml, string fromAddress = "", string Path="")
        {
            //Changed
           // body = GetEmailBody(body, 1, Path);

            MailMessage mailMessageObject = null;
            SmtpClient smtpClientObject = null;
            bool emailSend = false;
            string[] address;

            try
            {
                mailMessageObject = new MailMessage();

                if (fromAddress == "")
                {
                    fromAddress = ConfigurationManager.AppSettings["SmtpServerEmailID"].ToString();
                }
                String ReplyToEmail = ConfigurationManager.AppSettings["SmtpServerReplyToEmailID"].ToString();
                
                
                mailMessageObject.From = new MailAddress(fromAddress);
                mailMessageObject.ReplyToList.Add(ReplyToEmail); 

                               
                address = toAddress.Split(',');
                for (int i = 0; i < address.Length; i++)
                {
                    address[i] = CleanAndFormat.CleanText(address[i]);
                    if (address[i].Length > 0)
                        mailMessageObject.To.Add(address[i]);
                }


                address = ccAddress.Split(',');
                for (int i = 0; i < address.Length; i++)
                {
                    address[i] = CleanAndFormat.CleanText(address[i]);
                    if (address[i].Length > 0)
                        mailMessageObject.CC.Add(address[i]);
                }
                

                mailMessageObject.Subject = subject;
                mailMessageObject.Body = body;
                //changed
                mailMessageObject.IsBodyHtml = isBodyHtml;

                smtpClientObject = new SmtpClient();
                smtpClientObject.Send(mailMessageObject);
                emailSend = true;
            }
            catch (Exception er)
            { }
            finally
            {
                if (mailMessageObject != null)
                {
                    //mailMessageObject.Dispose();
                    //mailMessageObject = null;
                }
                //smtpClientObject = null;
            }
            return emailSend;
        }


        internal string GetEmailBody(string strBody, int OrganizationID,string Path)
        {           
            Template eTemplate = new Template();
            String sPath = Path;

            //String sPath = Path;

            bool doesFolderexists = eTemplate.SetFolderPath(sPath);
            if (doesFolderexists)
            {
                int isValidTemplate;

                if (OrganizationID == 1)
                {
                    isValidTemplate = eTemplate.LoadTemplate("MMMsg.xml", true);
                }
                else if (OrganizationID == 2)
                {
                    isValidTemplate = eTemplate.LoadTemplate("YRMsg.xml", true);
                }
                else if (OrganizationID == 3)
                {
                    isValidTemplate = eTemplate.LoadTemplate("DTFSMsg.xml", true);
                }
                else if (OrganizationID == 4)
                {
                    isValidTemplate = eTemplate.LoadTemplate("DXCSMsg.xml", true);
                }
                else
                {
                    isValidTemplate = eTemplate.LoadTemplate("MainMsg.xml", true);
                }

                eTemplate.SetVar("BODYHTML", strBody);
            }
            return eTemplate.GetBody();
        }


    }
}
