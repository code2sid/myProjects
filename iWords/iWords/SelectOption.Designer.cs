namespace iWords
{
    partial class SelectOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Revision = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Revision
            // 
            this.Revision.Location = new System.Drawing.Point(64, 73);
            this.Revision.Name = "Revision";
            this.Revision.Size = new System.Drawing.Size(257, 102);
            this.Revision.TabIndex = 0;
            this.Revision.Text = "Revision";
            this.Revision.UseVisualStyleBackColor = true;
            this.Revision.Click += new System.EventHandler(this.Revision_Click);
            this.Revision.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Revision_KeyUp);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(351, 73);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(257, 102);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add New";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            this.Add.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Add_KeyUp);
            // 
            // SelectOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 319);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Revision);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectOption";
            this.Text = "SelectOption";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SelectOption_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectOption_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectOption_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SelectOption_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Revision;
        private System.Windows.Forms.Button Add;
    }
}

