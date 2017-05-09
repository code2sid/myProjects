using System;
using System.Drawing;
using System.Windows.Forms;

namespace iWords
{
    public partial class SelectOption : Form
    {

        public SelectOption()
        {
            InitializeComponent();
        }


        private void Revision_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectOption.Show_Location(this.Location, new RevisionCards());
        }

        private void Add_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectOption.Show_Location(this.Location, new AddWords());
            
        }

        private void Revision_KeyUp(object sender, KeyEventArgs e)
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

        private void SelectOption_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void SelectOption_MouseUp(object sender, MouseEventArgs e)
        {
            WordDetails.mouseDown = false;
        }

        private void SelectOption_MouseDown(object sender, MouseEventArgs e)
        {
            WordDetails.mouseDown = true;
            WordDetails.lastLocation = e.Location;
        }

        private void SelectOption_MouseMove(object sender, MouseEventArgs e)
        {
            if (WordDetails.mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - WordDetails.lastLocation.X) + e.X, (this.Location.Y - WordDetails.lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        public static void Show_Location(Point location, Form obj)
        {
            obj.Show();
            obj.Location = location;
            obj.Update();
        }
    }
}
