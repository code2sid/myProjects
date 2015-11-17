using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KarrStyle.BLL;

namespace KarrStyle.UserControls
{
    public partial class ucCustomPaging : System.Web.UI.UserControl
    {
        #region Paging Properties

        public int StartPage
        {
            get
            {

                if (ViewState[clsConstants.ucStartPage] != null)
                    return int.Parse((ViewState[clsConstants.ucStartPage]).ToString());
                else
                    return 1;
            }
            set { ViewState[clsConstants.ucStartPage] = value; }
        }

        public int EndPage
        {
            get
            {

                if (ViewState[clsConstants.ucEndPage] != null)
                    return int.Parse((ViewState[clsConstants.ucEndPage]).ToString());
                else
                    return 1;
            }
            set { ViewState[clsConstants.ucEndPage] = value; }
        }

        public int CurrentPage
        {
            get
            {
                if (ViewState[clsConstants.ucCurrentPage] != null)
                    return int.Parse((ViewState[clsConstants.ucCurrentPage]).ToString());
                else
                    return 1;
            }
            set { ViewState[clsConstants.ucCurrentPage] = value; }
        }

        public int RecsPerPage
        {
            get
            {
                if (ViewState[clsConstants.ucRecsPerPage] != null)
                    return int.Parse(ViewState[clsConstants.ucRecsPerPage].ToString());
                else
                    return 10;
            }
            set { ViewState[clsConstants.ucRecsPerPage] = value; }
        }

        public string ShortOrder
        {
            get
            {
                if (ViewState[clsConstants.ucShortOrder] != null)
                    return (ViewState[clsConstants.ucShortOrder].ToString());
                else
                    return "desc";
            }
            set { ViewState[clsConstants.ucShortOrder] = value; }
        }

        public string ShortBy
        {
            get
            {
                if (ViewState[clsConstants.ucShortBy] != null)
                    return (ViewState[clsConstants.ucShortBy].ToString());
                else
                    return " ";
            }

            set { ViewState[clsConstants.ucShortBy] = value; }
        }

        public string CurrentBindMethod
        {
            get
            {
                if (ViewState[clsConstants.ucCurrentBindMethod] != null)
                    return (ViewState[clsConstants.ucCurrentBindMethod]).ToString();
                else
                    return "";
            }
            set { ViewState[clsConstants.ucCurrentBindMethod] = value; }
        }

        public int NoOfPages
        {
            get
            {

                if (ViewState[clsConstants.ucNoOfPages] != null)
                    return int.Parse((ViewState[clsConstants.ucNoOfPages]).ToString());
                else
                    return 0;
            }
            set { ViewState[clsConstants.ucNoOfPages] = value; }
        }

        public int NoOfRecords
        {
            get
            {

                if (ViewState[clsConstants.ucNoOfRecords] != null)
                    return int.Parse((ViewState[clsConstants.ucNoOfRecords]).ToString());
                else
                    return 0;
            }
            set { ViewState[clsConstants.ucNoOfRecords] = value; }
        }



        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            txtPageNo.Enabled = true;
            btnGo.Enabled = true;
        }

        #region Paging

        public void Paging_Bind(object sender, CommandEventArgs e)
        {
            string btnId = (((LinkButton)sender).ID).Remove(0, 3);
            if (!String.IsNullOrEmpty(btnId))
            {
                if (btnId == "next")
                {
                    StartPage += 5;
                    CurrentPage = StartPage;
                }
                else if (btnId == "pre")
                {
                    StartPage = (StartPage > 5) ? (StartPage -= 5) : 1;
                    CurrentPage = StartPage;
                }
                else
                {
                    CurrentPage = Convert.ToInt32(btnId);
                }
                this.Page.GetType().InvokeMember("" + CurrentBindMethod + "", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
                lblPaging.Controls.Clear();
                BindPaging();
            }
        }

        public void BindPaging()
        {
            clearPaging();
            if (NoOfRecords > 10)
            {
                tb2.Visible = true;
                if (NoOfRecords != 0)
                {
                    EndPage = StartPage + 4;
                    if (StartPage > 1)
                    {
                        LinkButton lnkBtn_Paging = new LinkButton();
                        lnkBtn_Paging.ID = "lnkpre";
                        lnkBtn_Paging.CausesValidation = false;
                        lnkBtn_Paging.Attributes.Add("runat", "server");
                        lnkBtn_Paging.CssClass = "";
                        lnkBtn_Paging.Style["padding-right"] = "8px";
                        lnkBtn_Paging.Style["padding-left"] = "8px";
                        lnkBtn_Paging.ForeColor = System.Drawing.Color.Black;
                        lnkBtn_Paging.Text = "...";
                        lnkBtn_Paging.Command += new CommandEventHandler(Paging_Bind);
                        lnkBtn_Paging.CommandArgument = "pre";
                        lblPaging.Controls.Add(lnkBtn_Paging);

                        AsyncPostBackTrigger trig = new AsyncPostBackTrigger();
                        trig.ControlID = lnkBtn_Paging.ID.ToString();
                        trig.EventName = "Click";
                        UPucPaging.Triggers.Add(trig);
                    }
                    for (int pageindex = StartPage; pageindex <= ((EndPage > NoOfPages) ? NoOfPages : EndPage); pageindex++)
                    {
                        LinkButton lnkBtn_Paging = new LinkButton();
                        lnkBtn_Paging.ID = "lnk" + pageindex;
                        lnkBtn_Paging.CausesValidation = false;
                        lnkBtn_Paging.Attributes.Add("runat", "server");
                        lnkBtn_Paging.CssClass = "";
                        lnkBtn_Paging.Style["padding-right"] = "8px";
                        lnkBtn_Paging.Style["padding-left"] = "8px";
                        lnkBtn_Paging.ForeColor = System.Drawing.Color.Black;
                        lnkBtn_Paging.Text = pageindex.ToString();
                        lnkBtn_Paging.Command += new CommandEventHandler(Paging_Bind);
                        lnkBtn_Paging.CommandArgument = pageindex.ToString();
                        if (pageindex == CurrentPage)
                            lnkBtn_Paging.Style["text-decoration"] = "underline";
                        lblPaging.Controls.Add(lnkBtn_Paging);

                        AsyncPostBackTrigger trig = new AsyncPostBackTrigger();
                        trig.ControlID = lnkBtn_Paging.ID.ToString();
                        trig.EventName = "Click";
                        UPucPaging.Triggers.Add(trig);
                    }
                    if (EndPage < NoOfPages)
                    {
                        LinkButton lnkBtn_Paging = new LinkButton();
                        lnkBtn_Paging.ID = "lnknext";
                        lnkBtn_Paging.CausesValidation = false;
                        lnkBtn_Paging.Attributes.Add("runat", "server");
                        lnkBtn_Paging.CssClass = "";
                        lnkBtn_Paging.Style["padding-right"] = "8px";
                        lnkBtn_Paging.Style["padding-left"] = "8px";
                        lnkBtn_Paging.ForeColor = System.Drawing.Color.Black;
                        lnkBtn_Paging.Text = "...";
                        lnkBtn_Paging.Command += new CommandEventHandler(Paging_Bind);
                        lnkBtn_Paging.CommandArgument = "next";
                        lblPaging.Controls.Add(lnkBtn_Paging);

                        AsyncPostBackTrigger trig = new AsyncPostBackTrigger();
                        trig.ControlID = lnkBtn_Paging.ID;
                        trig.EventName = "Click";
                        UPucPaging.Triggers.Add(trig);
                    }
                }
            }
            else
            {
                tb2.Visible = false;
            }
        }

        public void clearPaging()
        {
            lblPaging.Controls.Clear();

        }

        protected void m_cmdPrev2_Click(object sender, EventArgs e)
        {
            CurrentPage = CurrentPage - 1;
            this.Page.GetType().InvokeMember("" + CurrentBindMethod + "", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
            if (CurrentPage < StartPage || CurrentPage > EndPage)
            {
                StartPage = CurrentPage;
            }
            lblPaging.Controls.Clear();
            BindPaging();
        }

        protected void m_cmdNext2_Click(object sender, EventArgs e)
        {
            CurrentPage = CurrentPage + 1;
            this.Page.GetType().InvokeMember("" + CurrentBindMethod + "", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
            if (CurrentPage < StartPage || CurrentPage > EndPage)
            {
                StartPage = CurrentPage;
            }
            lblPaging.Controls.Clear();
            BindPaging();

        }

        protected void m_cmdfirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            lblPaging.Controls.Clear();
            this.Page.GetType().InvokeMember("" + CurrentBindMethod + "", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
            StartPage = CurrentPage;
            BindPaging();
        }

        protected void m_cmdLast_Click(object sender, EventArgs e)
        {
            CurrentPage = NoOfPages;
            lblPaging.Controls.Clear();
            this.Page.GetType().InvokeMember("" + CurrentBindMethod + "", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
            StartPage = CurrentPage;
            BindPaging();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (txtPageNo.Text != "")
            {

                if (NoOfPages < int.Parse(txtPageNo.Text.Trim()) || int.Parse(txtPageNo.Text.Trim()) < 1)
                {
                    this.Page.GetType().InvokeMember("" + CurrentBindMethod + "", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });

                    if (CurrentPage < StartPage || CurrentPage > EndPage)
                    {
                        StartPage = CurrentPage;

                    }
                }
                else
                {

                    CurrentPage = int.Parse(txtPageNo.Text.Trim());

                    this.Page.GetType().InvokeMember("" + CurrentBindMethod + "", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });

                    if (CurrentPage < StartPage || CurrentPage > EndPage)
                    {
                        StartPage = CurrentPage;
                    }

                }


                lblPaging.Controls.Clear();
                BindPaging();
            }
        }

        protected void ddlRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState[clsConstants.RecsPerPage] = int.Parse("10");
            this.Page.GetType().InvokeMember("" + CurrentBindMethod + "", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] { });
            BindPaging();
        }

        public void SetControlVisibility(bool IsEmptyGrid)
        {
            if (NoOfPages == 1)
            {
                m_cmdPrev2.Enabled = false;
                m_cmdNext2.Enabled = false;
                m_cmdfirst.Enabled = false;
                m_cmdLast.Enabled = false;

            }
            if (CurrentPage == 1)
            {
                m_cmdfirst.Enabled = false;
            }
            else if (NoOfPages > 1)
            {
                m_cmdfirst.Enabled = true;
            }

            if (CurrentPage == NoOfPages)
            {
                m_cmdLast.Enabled = false;
            }
            else if (NoOfPages > 1)
            {
                m_cmdLast.Enabled = true;
            }

            if (CurrentPage == 1 && CurrentPage < NoOfPages)
            {
                m_cmdNext2.Enabled = true;
                m_cmdPrev2.Enabled = false;
            }
            else if (CurrentPage != 1 && CurrentPage == NoOfPages && CurrentPage > 0)
            {
                m_cmdNext2.Enabled = false;
                m_cmdPrev2.Enabled = true;
            }
            else if (CurrentPage != 1 && CurrentPage <= NoOfPages && CurrentPage > 0)
            {
                m_cmdNext2.Enabled = true;
                m_cmdPrev2.Enabled = true;
            }

            if (IsEmptyGrid)
            {
                tb2.Visible = false;
            }
            else
            {
                tb2.Visible = true;
            }


        }

        #endregion
    }
}