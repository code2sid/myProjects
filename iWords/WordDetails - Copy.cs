using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace iWords
{
    public partial class WordDetails : Form
    {
        public static bool mouseDown = false;
        public static Point lastLocation;
        public RevisionCards rc = new RevisionCards();
        DataRow[] result = null;
        DataSet dsWordRepos = new DataSet();
        int rowIndex = 0;
        public WordDetails()
        {
            InitializeComponent();
        }

        private void WordDetails_Load(object sender, EventArgs e)
        {

            dsWordRepos.ReadXml(ConfigurationSettings.AppSettings["configurationfilePath"].ToString());
            var word = dsWordRepos.Tables[0].Select(string.Format("title='{0}'", lblWord.Text));
            if (word.Length > 0)
            {
                lblMeaning.Text = word[0]["Meaning"].ToString();
                lblExample.Text = word[0]["Example"].ToString();
                lblKnowCnt.Text = dsWordRepos.Tables[0].Select("knowthis='1'").Length.ToString();
                lblDontKnowCnt.Text = dsWordRepos.Tables[0].Select("knowthis='0'").Length.ToString();

            }


        }

        private void btnKnow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void WordDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void WordDetails_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void WordDetails_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void WordDetails_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void btnKnow_Click(object sender, EventArgs e)
        {
            result = dsWordRepos.Tables[0].Select(string.Format("title='{0}'", lblWord.Text));
            rowIndex = dsWordRepos.Tables[0].Rows.IndexOf(result[0]);
            if (result.Length > 0)
            {
                dsWordRepos.Tables[0].Rows[rowIndex]["KnowThis"] = "1";
                dsWordRepos.WriteXml(ConfigurationSettings.AppSettings["configurationfilePath"].ToString());
            }

            lblKnowCnt.Text = dsWordRepos.Tables[0].Select("knowthis='1'").Length.ToString();
            lblDontKnowCnt.Text = dsWordRepos.Tables[0].Select("knowthis='0'").Length.ToString();
        }

        private void btnDntKnw_Click(object sender, EventArgs e)
        {

            result = dsWordRepos.Tables[0].Select(string.Format("title='{0}'", lblWord.Text));
            rowIndex = dsWordRepos.Tables[0].Rows.IndexOf(result[0]);
            if (result.Length > 0)
            {
                dsWordRepos.Tables[0].Rows[rowIndex]["KnowThis"] = "0";
                dsWordRepos.WriteXml(ConfigurationSettings.AppSettings["configurationfilePath"].ToString());
            }

            lblKnowCnt.Text = dsWordRepos.Tables[0].Select("knowthis='1'").Length.ToString();
            lblDontKnowCnt.Text = dsWordRepos.Tables[0].Select("knowthis='0'").Length.ToString();

        }

        private void lnkCards_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RevisionCards rc = new RevisionCards();
            rc.Show();
        }

    }
}
