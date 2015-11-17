using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using KarrStyle.DAL;

namespace KarrStyle.BLL.User
{
    public class clsUsers
    {

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string Zip { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int isAdmin { get; set; }
        public string HomePage { get; set; }

        public clsUsers(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        internal bool UserValidate()
        {
            return false;
        }

        internal clsUsers ValidateUser()
        {
            DataSet userDetails = null;
            SqlCommand commandObject = null;
            KSDB dataObject = null;

            try
            {
                commandObject = new SqlCommand();
                commandObject.CommandType = CommandType.StoredProcedure;
                commandObject.CommandText = "ks_ValidateUser";
                commandObject.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
                commandObject.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;

                dataObject = new KSDB();
                userDetails = dataObject.GetDataSet(commandObject);
            }

            finally
            {
                if (commandObject != null)
                {
                    commandObject.Dispose();
                    commandObject = null;
                }
                dataObject = null;
            }

            return GetUserProfile(userDetails, UserName, Password);
        }

        protected clsUsers GetUserProfile(DataSet userDetails, string userName, string userPassword)
        {
            clsUsers _objUser = null;
            DataTable authenticatedUserDetails = null;

            try
            {
                if (userDetails != null && userDetails.Tables[0].Rows.Count > 0)
                {
                    authenticatedUserDetails = userDetails.Tables[0];
                    _objUser = new clsUsers(userName, userPassword);

                    _objUser.UserID = CleanAndFormat.CleanInteger(authenticatedUserDetails.Rows[0]["UserId"]);
                    _objUser.FirstName = CleanAndFormat.CleanText(authenticatedUserDetails.Rows[0]["FirstName"]);
                    _objUser.LastName = CleanAndFormat.CleanText(authenticatedUserDetails.Rows[0]["LastName"]);
                    _objUser.UserName = CleanAndFormat.CleanText(authenticatedUserDetails.Rows[0]["UserName"]);
                    _objUser.isAdmin = CleanAndFormat.CleanInteger(authenticatedUserDetails.Rows[0]["isAdmin"]);
                    //userProfileObject.HomePage = CleanAndFormat.CleanText(authenticatedUserDetails.Rows[0]["HomePage"]);

                }
            }
            finally
            {
                if (authenticatedUserDetails != null)
                {
                    authenticatedUserDetails.Dispose();
                    authenticatedUserDetails = null;
                }

                if (userDetails != null)
                {
                    userDetails.Clear();
                    userDetails.Dispose();
                }

                userDetails = null;
            }



            return _objUser;

        }

    }
}