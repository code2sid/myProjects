using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iWords
{
    public partial class RevisionCards : Form
    {
        public DataSet dsWordRepos = new DataSet();
        int index = 0, preVal = 0;
        public RevisionCards()
        {
            InitializeComponent();
        }

        public void LoadWords(int index = 0)
        {
            dsWordRepos.ReadXml(Application.StartupPath + "\\WordsRepos.xml");
            btnWord.Text = dsWordRepos.Tables[0].Rows[index]["Title"].ToString();
        }
        private void RevisionCards_Load(object sender, EventArgs e)
        {
            LoadWords();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            preVal = index;
            Random r = new Random();
            while (preVal == index)
                index = r.Next(0, dsWordRepos.Tables[0].Rows.Count - 1);
            LoadWords(index);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            LoadWords(preVal);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            this.Hide();
            WordDetails wd = new WordDetails();
            foreach (var item in wd.Controls)
            {
                if (item.GetType().Equals(typeof(Label)))
                    if (((Label)item).Name.Equals("lblWord"))
                        ((Label)item).Text = btnWord.Text;
            }
            SelectOption.Show_Location(this.Location, wd);

        }

        private void lnkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SelectOption.Show_Location(this.Location, new SelectOption());

        }

        private void btnWord_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void btnNext_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void btnPrevious_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void RevisionCards_MouseDown(object sender, MouseEventArgs e)
        {
            WordDetails.mouseDown = true;
            WordDetails.lastLocation = e.Location;
        }

        private void RevisionCards_MouseUp(object sender, MouseEventArgs e)
        {
            WordDetails.mouseDown = false;
        }

        private void RevisionCards_MouseMove(object sender, MouseEventArgs e)
        {
            if (WordDetails.mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - WordDetails.lastLocation.X) + e.X, (this.Location.Y - WordDetails.lastLocation.Y) + e.Y);

                this.Update();
            }
        }
    }
}
