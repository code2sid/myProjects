using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarrStyle.BLL.User;
using System.Web.Security;
using KarrStyle.BLL;

namespace KarrStyle
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        #region private variables
        private clsUsers _userObject = null;
        #endregion

        #region internal Properties for Error Message & UserProfile Object

        internal clsUsers UserObject
        {
            get
            {
                if (_userObject == null)
                {
                    try
                    {
                        if (Session[clsConstants.UserProfile] != null)
                        {
                            _userObject = (clsUsers)Session[clsConstants.UserProfile];
                        }
                        else
                        {
                            clsConstants.RemoveAllSession();
                            FormsAuthentication.SignOut();
                            Response.Redirect(clsConstants.HomePageURL);
                        }
                    }
                    finally { }
                }
                return _userObject;
            }
            set
            {
                if (value == null)
                    clsConstants.RemoveSessionObject(clsConstants.UserProfile);
                else
                    _userObject = value;
            }
        }

        internal string SetErrorMessage
        {
            set
            {
                ErrorLabel.Text = value;
                ErrorPanel.Visible = true;
            }
        }

        internal string SetInformationMessage
        {
            set
            {
                InformationLabel.Text = value;
                InformationPanel.Visible = true;
            }
        }

        #endregion
     
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        internal void LogUserUsage(string visitedPage, string comments)
        {
            clsConstants _objCons = null;
            try
            {
                if (UserObject != null)
                {
                    _objCons = new clsConstants(UserObject.UserID);
                    _objCons.AddUserUsageLog(UserObject.UserName, 0, visitedPage, comments);
                }
            }
            finally
            {
                _objCons = null;
            }
        }


       
    }
}
