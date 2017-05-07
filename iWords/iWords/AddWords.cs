using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace iWords
{
    public partial class AddWords : Form
    {
        public AddWords()
        {
            InitializeComponent();
        }


        private void AddWord()
        {
            XmlDocument xmlSchedule = new XmlDocument();
            xmlSchedule.Load(ConfigurationSettings.AppSettings["configurationfilePath"].ToString());
            XmlElement ParentElement = xmlSchedule.CreateElement("Word");
            XmlElement Title = xmlSchedule.CreateElement("Title"); Title.InnerText = txtWord.Text;
            XmlElement Meaning = xmlSchedule.CreateElement("Meaning"); Meaning.InnerText = txtMeaning.Text;
            XmlElement Example = xmlSchedule.CreateElement("Example"); Example.InnerText = txtExample.Text;
            XmlElement KnowThis = xmlSchedule.CreateElement("KnowThis"); KnowThis.InnerText = "1";
            ParentElement.AppendChild(Title);
            ParentElement.AppendChild(Meaning);
            ParentElement.AppendChild(Example);
            ParentElement.AppendChild(KnowThis);
            xmlSchedule.DocumentElement.AppendChild(ParentElement);
            xmlSchedule.Save(ConfigurationSettings.AppSettings["configurationfilePath"].ToString());

        }
        private void ClearAll()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType().Equals(typeof(TextBox)))
                    ((TextBox)item).Text = "";
            }
        }

        
        private void Add_Click(object sender, EventArgs e)
        {
            AddWord();
            ClearAll();
            txtWord.Focus();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void lnkHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SelectOption so = new SelectOption();
            so.Show();
        }


        private void txtWord_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void txtMeaning_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void txtExample_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void Add_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void Reset_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void AddWords_MouseDown(object sender, MouseEventArgs e)
        {
            WordDetails.mouseDown = true;
            WordDetails.lastLocation = e.Location;
        }

        private void AddWords_MouseMove(object sender, MouseEventArgs e)
        {
            if (WordDetails.mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - WordDetails.lastLocation.X) + e.X, (this.Location.Y - WordDetails.lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void AddWords_MouseUp(object sender, MouseEventArgs e)
        {
            WordDetails.mouseDown = false;
        }

    }
}
