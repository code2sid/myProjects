using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarrStyle.BLL.User;
using System.Data;
using KarrStyle.BLL.KSException;

namespace KarrStyle.Pages
{
    public partial class AddItems : System.Web.UI.Page
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

        readonly KarrStyle.BLL.Product.clsProduct _objProduct = new KarrStyle.BLL.Product.clsProduct(1);

        private clsUsers UserObject
        {
            get
            {
                return ((SiteMaster)this.Master).UserObject;
            }
        }

        public static int NoOfPages;
        public static int NoOfRecords;

        #endregion Props & objects


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && UserObject != null)
            {
                BindProducts();
            }
        }


        #region UDFs
        internal void BindProducts()
        {
            try
            {
                using (DataTable _dtProducts = _objProduct.GetProducts("", "", 1, 10, out NoOfPages, out NoOfRecords))
                {
                    if (_dtProducts != null)
                    {
                        grdProducts.DataSource = _dtProducts;
                        grdProducts.DataBind();
                        //ucCustomPaging1.NoOfPages = NoOfPages;
                        //ucCustomPaging1.NoOfRecords = NoOfRecords;

                        if (_dtProducts.Rows.Count > 0)
                        {
                            ViewState["vw_Products"] = _dtProducts;
                            //ucCustomPaging1.SetControlVisibility(false);
                            //ucCustomPaging1.BindPaging();
                        }
                        else
                        {
                            //ucCustomPaging1.SetControlVisibility(true);
                            //ucCustomPaging1.clearPaging();
                        }
                    }
                    else
                    {
                        grdProducts.DataSource = null;
                        grdProducts.DataBind();
                        //ucCustomPaging1.SetControlVisibility(true);
                        //ucCustomPaging1.clearPaging();
                    }

                }
            }
            catch (Exception ex)
            {
                SetErrorMessage = "Error in Binding Products";
                ExceptionHandler.HandleException(ex, "BindProducts", KarrStyleException.ExceptionLevel.Error);
            }

        }

        #endregion UDFs

        protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Success = 0;
            try
            {
                if (e.CommandName == "edit")
                {
                    /*
                    TextBox txtOrganizationID = (TextBox)grdProducts.FooterRow.FindControl("txtOrganizationID");
                    CheckBox chkIsGlobalSiteYearCurrent = (CheckBox)grdProducts.FooterRow.FindControl("chkIsGlobalSiteYearCurrent");
                    HiddenField hdfGlobalSiteYearId = (HiddenField)grdProducts.FooterRow.FindControl("hdfGlobalSiteYearId");

                    DataSet ds = (DataSet)ViewState["GlobalSiteYearDetails"];
                    DataRow[] dr = ds.Tables[0].Select("GlobalSiteYearId = " + e.CommandArgument);

                    txtOrganizationID.Text = dr[0]["OrganizationID"].ToString();
                    txtGlobalSiteYear.Text = dr[0]["GlobalSiteYear"].ToString();
                    txtStartMonth.Text = dr[0]["StartMonth"].ToString();
                    txtStartYear.Text = dr[0]["StartYear"].ToString();
                    txtEndMonth.Text = dr[0]["EndMonth"].ToString();
                    chkIsGlobalSiteYearCurrent.Checked = Convert.ToBoolean(dr[0]["GlobalSiteYearCurrent"]);
                    txtEndYear.Text = dr[0]["EndYear"].ToString();
                    txtGlobalSiteYearOrder.Text = dr[0]["GlobalSiteYearOrder"].ToString();
                    txtSiteYearGoal.Text = dr[0]["SiteYearGoal"].ToString();
                    hdfGlobalSiteYearId.Value = e.CommandArgument.ToString();*/
                }

                if (e.CommandName == "Add")
                {
                    string _productTypeID = ((DropDownList)grdProducts.FooterRow.FindControl("ddlProductType")).SelectedValue;
                    string _productName = ((TextBox)grdProducts.FooterRow.FindControl("txtProductName")).Text;
                    //fuProductFile
                    string _quantity = ((DropDownList)grdProducts.FooterRow.FindControl("ddlQuantity")).SelectedValue;


                    _objProduct.ProductTypeID = Convert.ToInt32(_productTypeID);
                    _objProduct.ProductName = Convert.ToString(_productName);
                    _objProduct.ProductDesc = "";
                    _objProduct.Quantity = Convert.ToInt32(_quantity);
                    _objProduct.Createdby = Convert.ToInt32(UserObject.UserID);


                    Success = _objProduct.AddEditProducts();

                    BindProducts();
                    //ucCustomPaging1.BindPaging();

                    if (Convert.ToInt32(Success) > 0)
                    {
                        SetInformationMessage = "Product Added/Updated Successfully.";
                    }

                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void grdProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList _ddlPtypes = (DropDownList)e.Row.FindControl("ddlProductType");
                if (_ddlPtypes != null)
                {
                    _ddlPtypes.DataSource = _objProduct.GetProcutTypes(0);
                    _ddlPtypes.DataTextField = "ProductType";
                    _ddlPtypes.DataValueField = "TypeID";
                    _ddlPtypes.DataBind();

                }
            }
        }

    }
}