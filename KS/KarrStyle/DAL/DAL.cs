using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using KarrStyle.BLL;
using System.Data.SqlClient;
using System.Data;
using System.Xml.XPath;
using System.Xml;

namespace KarrStyle.DAL
{
    public class KSDB
    {
        #region Private variables & property
        private string _ConnectionString;
        private int _CommandTimeout;

        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
        }

        public int CommandTimeout
        {
            get
            {
                return _CommandTimeout;
            }
        }

        #endregion

        #region Public Constructor
        public KSDB()
            : this(ConfigurationManager.ConnectionStrings["KarrStyle.DBConnection"].ConnectionString,
                    int.Parse(ConfigurationManager.AppSettings["Command.Timeout"].ToString()))
        {
        }

        public KSDB(string connectionString, int commandTimeout)
        {
            connectionString = CleanAndFormat.CleanText(connectionString, false, false);

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("SqlData:Data - Connection String is invalid");
            else
                _ConnectionString = connectionString;

            _CommandTimeout = commandTimeout;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// This function will connect to the database and disconnect. If you do not receive any error then 
        /// you have a valid connection to the database.
        /// </summary>
        public void TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                conn.Open();
                conn.Close();
            }
        }

        /// <summary>
        /// This connection is used to check if your connection is open or not
        /// </summary>
        /// <param name="conn">Connection you want to check if it is open or not</param>
        /// <returns></returns>
        public bool IsOpen(SqlConnection conn)
        {
            bool state = false;

            if (conn.State == ConnectionState.Open)
                state = true;

            return state;
        }

        /// <summary>
        /// This function returns a dataset
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <returns>Dataset with records</returns>
        public DataSet GetDataSet(SqlCommand sc)
        {
            DataSet ds = null;

            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                ds = GetDataSet(sc, conn);
                sc = null;
            }

            return ds;
        }

        /// <summary>
        /// This function returns a dataset
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <param name="conn">pass your own connection object</param>
        /// <returns>Dataset with records</returns>
        public DataSet GetDataSet(SqlCommand sc, SqlConnection conn)
        {
            DataSet ds = null;
            CheckCommandObject(sc);

            sc.Connection = conn;
            sc.CommandTimeout = _CommandTimeout;


            using (SqlDataAdapter sd = new SqlDataAdapter(sc))
            {
                ds = new DataSet();
                sd.Fill(ds);
                sc = null;
            }

            return ds;
        }

        /// <summary>
        /// This function returns a Execute Scaler
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <returns>First Single Record in String Format</returns>
        public void ExecuteScaler(SqlCommand sc)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                sc.Connection = conn;
                conn.Open();
                sc.ExecuteScalar();
                conn.Close();
                sc = null;
            }
        }

        /// <summary>
        /// This function returns a XPathDocument
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <returns>Dataset with records</returns>
        public XPathDocument GetXPathDocument(SqlCommand sc)
        {
            XPathDocument xd = null;

            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                xd = GetXPathDocument(sc, conn);
                sc = null;
            }

            return xd;
        }



        /// <summary>
        /// This function returns a XPathDocument
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <param name="conn">pass your own connection object</param>
        /// <returns>Dataset with records</returns>
        public XPathDocument GetXPathDocument(SqlCommand sc, SqlConnection conn)
        {
            XmlReader xr = null;
            XPathDocument xd = null;
            bool opened = false;

            try
            {
                CheckCommandObject(sc);

                if (!IsOpen(conn))
                {
                    conn.Open();
                    opened = true;
                }

                sc.Connection = conn;
                sc.CommandTimeout = _CommandTimeout;

                xr = sc.ExecuteXmlReader();
                xd = new XPathDocument(xr, XmlSpace.Preserve);

                if (opened)
                {
                    conn.Close();
                    opened = false;
                }
            }
            finally
            {
                sc = null;
                conn = null;
            }

            return xd;
        }

        /// <summary>
        /// This function returns a DataReader. This should also be used for Scalar values
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <returns>DataReader with records</returns>
        public SqlDataReader ExecuteReader(SqlCommand sc)
        {
            SqlDataReader sdr = null;
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(_ConnectionString);
                sdr = ExecuteReader(sc, conn);
            }
            finally
            {
                sc = null;
                conn = null;
            }
            return sdr;
        }

        /// <summary>
        /// This function returns a DataReader. This should also be used for Scalar values
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <param name="conn">pass your own connection object</param>
        /// <returns>DataReader with records</returns>
        public SqlDataReader ExecuteReader(SqlCommand sc, SqlConnection conn)
        {
            SqlDataReader sdr = null;

            try
            {
                if (!IsOpen(conn))
                {
                    conn.Open();
                }

                sc.Connection = conn;
                sc.CommandTimeout = _CommandTimeout;

                sdr = sc.ExecuteReader(CommandBehavior.CloseConnection);
            }
            finally
            {
                sc = null;
                conn = null;
            }
            return sdr;
        }

        /// <summary>
        /// This function executes a procedure which does not return any records.
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <returns>returns number of records affected</returns>
        public int ExecuteNonQuery(SqlCommand sc)
        {
            int affectedRecords = 0;

            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                affectedRecords = ExecuteNonQuery(sc, conn);
                sc = null;
            }

            return affectedRecords;
        }

        /// <summary>
        /// This function executes a procedure which does not return any records.
        /// </summary>
        /// <param name="sc">SQLCommand that carries your stored procedure, queries are not allowed</param>
        /// <param name="conn">pass your own connection object</param>
        /// <returns>returns number of records affected</returns>
        public int ExecuteNonQuery(SqlCommand sc, SqlConnection conn)
        {
            bool opened = false;
            int affectedRecords = 0;

            try
            {
                CheckCommandObject(sc);

                sc.Connection = conn;
                sc.CommandTimeout = _CommandTimeout;

                if (!IsOpen(conn))
                {
                    conn.Open();
                    opened = true;
                }

                affectedRecords = sc.ExecuteNonQuery();

                if (opened)
                {
                    conn.Close();
                    opened = false;
                }
            }
            finally
            {
                sc = null;
                conn = null;
            }
            return affectedRecords;
        }


        public bool Update(DataSet ds, SqlCommand selectCommand, SqlCommand insertCommand, SqlCommand updateCommand, SqlCommand deleteCommand)
        {
            bool success = false;
            SqlDataAdapter da = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(_ConnectionString);
                da = new SqlDataAdapter();

                if (selectCommand != null)
                {
                    CheckCommandObject(selectCommand);
                    selectCommand.Connection = conn;
                    selectCommand.CommandTimeout = _CommandTimeout;
                    da.SelectCommand = selectCommand;
                }

                if (insertCommand != null)
                {
                    CheckCommandObject(insertCommand);
                    insertCommand.Connection = conn;
                    insertCommand.CommandTimeout = _CommandTimeout;
                    da.InsertCommand = insertCommand;
                }

                if (updateCommand != null)
                {
                    CheckCommandObject(updateCommand);
                    updateCommand.Connection = conn;
                    updateCommand.CommandTimeout = _CommandTimeout;
                    da.UpdateCommand = updateCommand;
                }

                if (deleteCommand != null)
                {
                    CheckCommandObject(deleteCommand);
                    deleteCommand.Connection = conn;

                    deleteCommand.CommandTimeout = _CommandTimeout;
                    da.DeleteCommand = deleteCommand;
                }

                //DataAdapter = da;

                //DataAdapter.Update(ds);
                da.Update(ds);
                success = true;
            }
            finally
            {
                selectCommand = null;
                insertCommand = null;
                updateCommand = null;
                deleteCommand = null;

                ds = null;

                if (da != null)
                {
                    da.Dispose();
                    da = null;
                }

                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            }

            return success;
        }


        private void CheckCommandObject(SqlCommand sc)
        {
            if (sc.CommandType == CommandType.Text || sc.CommandType == CommandType.TableDirect)
                throw new ArgumentException("Data:CheckCommandObject - Direct SQL queries are not allowed");
        }

        #endregion
    }
}