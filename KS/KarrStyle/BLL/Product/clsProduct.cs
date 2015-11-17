using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using KarrStyle.DAL;
using System.Data;
using KarrStyle.BLL.KSException;

namespace KarrStyle.BLL.Product
{
    public class clsProduct
    {
        public int ProductID { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int Quantity { get; set; }
        public int Createdby { get; set; }


        public clsProduct(int _loggedINUserID)
        {
            Createdby = _loggedINUserID;
        }

        internal int AddEditProducts()
        {
            SqlCommand commandObject = null;
            KSDB dataObject = null;
            int Ret = 0;


            try
            {
                commandObject = new SqlCommand();
                commandObject.CommandType = CommandType.StoredProcedure;
                commandObject.CommandText = "ks_AddEditProducts";
                commandObject.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                commandObject.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = ProductTypeID;
                commandObject.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = ProductName;
                commandObject.Parameters.Add("@ProductDesc", SqlDbType.NVarChar).Value = ProductDesc;
                commandObject.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = Quantity;
                commandObject.Parameters.Add("@Createdby", SqlDbType.BigInt).Value = Createdby;
                SqlParameter outputParameter = null;

                outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@SuccessID";
                outputParameter.Direction = ParameterDirection.Output;
                outputParameter.SqlDbType = SqlDbType.Int;
                commandObject.Parameters.Add(outputParameter);

                dataObject = new KSDB();
                dataObject.ExecuteNonQuery(commandObject);
                Ret = CleanAndFormat.CleanInteger(outputParameter.Value);

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "clsProduct-AddEditProducts", KarrStyleException.ExceptionLevel.Error);
            }

            finally
            {

            }

            return Ret;
        }

        internal DataTable GetProducts(string ShortOrder, string ShortBy, int CurrentPage, int RecsPerPage, out int NoOfPages, out int NoOfRecords)
        {

            DataSet ds = null;
            SqlCommand commandObject = null;
            KSDB dataObject = null;
            SqlParameter outputParameter = null;
            SqlParameter outputParameter2 = null;


            try
            {
                commandObject = new SqlCommand();
                commandObject.CommandType = CommandType.StoredProcedure;
                commandObject.CommandText = "ks_GetAllProducts";
                commandObject.Parameters.Add("@Page", SqlDbType.Int).Value = CurrentPage;
                commandObject.Parameters.Add("@RecsPerPage", SqlDbType.Int).Value = RecsPerPage;
                commandObject.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                commandObject.Parameters.Add("@ShortOrder", SqlDbType.NVarChar).Value = ShortOrder;
                commandObject.Parameters.Add("@ShortBy", SqlDbType.NVarChar).Value = ShortBy;

                outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@NoOfPages";
                outputParameter.Direction = ParameterDirection.Output;
                outputParameter.SqlDbType = SqlDbType.Int;
                commandObject.Parameters.Add(outputParameter);

                outputParameter2 = new SqlParameter();
                outputParameter2.ParameterName = "@NoofRec";
                outputParameter2.Direction = ParameterDirection.Output;
                outputParameter2.SqlDbType = SqlDbType.Int;
                commandObject.Parameters.Add(outputParameter2);

                dataObject = new KSDB();
                ds = dataObject.GetDataSet(commandObject);

                NoOfPages = CleanAndFormat.CleanInteger(outputParameter.Value);
                NoOfRecords = CleanAndFormat.CleanInteger(outputParameter2.Value);


            }
            catch (Exception er)
            {
                NoOfPages = 0;
                NoOfRecords = 0;
            }


            finally
            {
                if (commandObject != null)
                {
                    commandObject.Dispose();
                }
                commandObject = null;
                dataObject = null;
            }
            return ds.Tables[0];
        }

        internal DataTable GetProcutTypes(int _typeid = 0)
        {
            DataSet ds = null;
            SqlCommand commandObject = null;
            KSDB dataObject = null;

            try
            {
                commandObject = new SqlCommand();
                commandObject.CommandType = CommandType.StoredProcedure;
                commandObject.CommandText = "ks_GetProductTypes";
                commandObject.Parameters.Add("@ProductTypeID", SqlDbType.Int).Value = _typeid;

                dataObject = new KSDB();
                ds = dataObject.GetDataSet(commandObject);

            }

            finally
            {
                if (commandObject != null)
                {
                    commandObject.Dispose();
                }
                commandObject = null;
                dataObject = null;
            }
            return ds.Tables[0];
        }




    }
}