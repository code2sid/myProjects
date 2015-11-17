using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarrStyle.BLL;
using System.Configuration;
using System.Web.Security;
using KarrStyle.BLL.User;
using KarrStyle.BLL.KSException;

namespace KarrStyle.Account
{
    public partial class Login : System.Web.UI.Page
    {

        #region Set Error & Information Message
        internal string SetErrorMessage
        {
            set
            {
                ((SiteMaster)this.Master).SetErrorMessage = value;
            }
        }

        internal string SetInformationMessage
        {
            set
            {
                ((SiteMaster)this.Master).SetInformationMessage = value;
            }
        }
        #endregion

        #region Props & objects
        clsUsers _objuser;

        #endregion Props & objects

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

             bool maintenance = Convert.ToBoolean(CleanAndFormat.CleanInteger(ConfigurationManager.AppSettings["KarrStyle.Maintenance"]));
             if (maintenance)
             {
                 Page.Session.Clear();
                 Page.Session.RemoveAll();
                 FormsAuthentication.SignOut();
                 Response.Redirect(clsConstants.Maintenance);
             }
             else
             {
                 if (!Page.IsPostBack)
                 {

                     if (Request.Cookies["UName"] != null)
                     {
                         txtUserName.Text = Request.Cookies["UName"].Value;
                     }
                     Page.Session.Clear();
                     Page.Session.RemoveAll();
                     FormsAuthentication.SignOut();
                     if (!FormsAuthentication.CookiesSupported)
                         SetErrorMessage = clsConstants.CookieErrorText;


                 }
             }

        }

        #endregion Events


        #region UDM

        private void AuthenticateUser()
        {
            _objuser = new clsUsers(CleanAndFormat.CleanText(txtUserName.Text, false, false), CleanAndFormat.CleanText(txtPassword.Text, false, false));
            bool isAuthenticated = false;
            try
            {
                if (IsUserAuthenticated())
                {
                    //((KarrStyle.SiteMaster)this.Master).LogUserUsage("Login", "Logon Successful");

                    FormsAuthentication.SetAuthCookie(txtUserName.Text, false);

                    Response.Redirect(_objuser.HomePage, false);
                }
            }
            catch (System.Data.SqlClient.SqlException SqlEx)
            {
                //SetInformationMessage = SqlEx.Message;
                SetErrorMessage = SqlEx.Message;
            }
            catch (Exception ex)
            {
                SetErrorMessage = ex.Message;
                throw ex;
            }
        }

        private bool IsUserAuthenticated()
        {
            clsUsers userObject = null;
            bool isAuthenticated = false;
            try
            {
                userObject = new clsUsers(CleanAndFormat.CleanText(txtUserName.Text), clsConstants.encrypPassword(txtPassword.Text.Trim()));
                userObject = userObject.ValidateUser();

                Session[clsConstants.UserProfile] = userObject;

                Response.Cookies["UName"].Value = txtUserName.Text;
                Response.Cookies["UName"].Expires = DateTime.Now.AddDays(1);
                ((SiteMaster)this.Master).UserObject = userObject;

                isAuthenticated = true;
                Response.Redirect("~/Pages/Additems.aspx");
            }
            catch (Exception ex)
            {
                SetErrorMessage = ex.Message;
                ExceptionHandler.HandleException(ex, "", KarrStyleException.ExceptionLevel.Error);
            }
            finally
            {
                userObject = null;
            }
            return isAuthenticated;
        }

        private bool IsValidated()
        {
            bool res = false;
            try
            {
                if (txtUserName.Text.Trim() != "")
                {
                    res = true;
                }
                else
                {
                    SetErrorMessage = "Please Enter User Name";
                    return false;
                }

                if (txtPassword.Text.Trim() != "")
                {
                    res = true;
                }
                else
                {
                    SetErrorMessage = "Please Enter Password";
                    return false;
                }
            }
            catch (Exception ex)
            {
                SetErrorMessage = ex.Message;
                ExceptionHandler.HandleException(ex, "", KarrStyleException.ExceptionLevel.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "scrollUP();", true);
            }
            return res;
        }


        #endregion UDM

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (IsValidated())
                    {
                        AuthenticateUser();
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "", KarrStyleException.ExceptionLevel.Error);
            }
        }


    }
}
