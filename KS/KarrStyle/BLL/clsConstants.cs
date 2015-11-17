using System;
using System.Web;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using System.Data.SqlClient;
using KarrStyle.DAL;
using System.Security.Cryptography;


namespace KarrStyle.BLL
{
    public class clsConstants
    {
        #region Constants
        public static string _userProfile;
        public static string UserProfile
        {

            get
            {
                _userProfile = GetPermission("UserProfile");
                return _userProfile;
            }

        }

        public static string _homePageURL;
        public static string HomePageURL
        {

            get
            {
                _homePageURL = GetPermission("HomePageURL");
                return _homePageURL;
            }

        }

        public static string _maintenance;
        public static string Maintenance
        {

            get
            {
                _maintenance = GetPermission("Maintenance");
                return _maintenance;
            }

        }


        public static string _CookieErrorText;
        public static string CookieErrorText
        {
            get
            {
                _CookieErrorText = GetPermission("CookieErrorText");
                return _CookieErrorText;
            }
        }


        public const string ucCurrentPage = "ucCurrentPage";
        public const string ucRecsPerPage = "ucRecsPerPage";
        public const string ucNoOfPages = "ucNoOfPages";
        public const string ucShortOrder = "ucShortOrder";
        public const string ucShortBy = "ucShortBy";
        public const string ucNoOfRecords = "ucNoOfRecords";
        public const string ucStartPage = "ucStartPage";
        public const string ucEndPage = "ucEndPage";
        public const string ucCurrentBindMethod = "ucCurrentBindMethod";
        public const string RecsPerPage = "RecsPerPage";



        #endregion Constants

        public int OrganizationID { get; set; }
        public int LoggedInUserID { get; set; }
        public clsConstants(int loggedInUserID)
        {
            LoggedInUserID = loggedInUserID;
        }
        

        static string GetPermission(string Category)
        {
            DataSet ds = new DataSet();
            string result = "";

            try
            {
                //List<CommonBO> objCommon = new List<CommonBO>();               
                XDocument xdoc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/BLL/Constants.xml"));
                string str = xdoc.ToString();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(str);
                XmlNodeReader xmlReader = new XmlNodeReader(doc);
                System.IO.StringReader xmlSR = new System.IO.StringReader(str);
                ds.ReadXml(xmlReader);
                DataRow[] dr = ds.Tables[0].Select("category='" + Category + "'");

                if (dr != null || dr.Length > 0)
                {
                    result = dr[0]["Value"].ToString();
                }
            }

            catch (Exception ex)
            {

            }

            return result;
        }

        static internal void RemoveSessionObject(string sessionObject)
        {
            if (HttpContext.Current.Session[sessionObject] != null)
                HttpContext.Current.Session.Remove(sessionObject);
        }

        static internal void RemoveAllSession()
        {
            RemoveSessionObject(UserProfile);
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now);
        }

        public void AddUserUsageLog(string loggedInUserName, int siteId, string visitedPage, string comments)
        {
            SqlCommand sc = null;
            KSDB d = null;

            try
            {
                sc = new SqlCommand("UsageLogAdd");
                sc.Parameters.Add("@OrganizationId", SqlDbType.Int).Value = OrganizationID;
                sc.Parameters.Add("@LoggedInUserId", SqlDbType.Int).Value = LoggedInUserID;
                sc.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = loggedInUserName;
                sc.Parameters.Add("@SiteId", SqlDbType.Int).Value = siteId;
                sc.Parameters.Add("@VisitedPage", SqlDbType.NVarChar).Value = visitedPage;
                sc.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = comments;
                sc.CommandType = CommandType.StoredProcedure;
                d = new KSDB();
                d.ExecuteNonQuery(sc);
            }
            finally
            {
                if (sc != null)
                {
                    sc.Dispose();
                    sc = null;
                }
                d = null;
            }
        }

        static internal string encrypPassword(string sData)
        {
            string encrypted = CipherUtility.Encrypt<AesManaged>(sData, "password@123", "salt@123");
            return encrypted;
        }
        public static string decryptPassword(string sData)
        {
            string decrypted = CipherUtility.Decrypt<AesManaged>(sData, "password@123", "salt@123");
            return decrypted;
        }



    }
}