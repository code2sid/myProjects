namespace iWords
{
    partial class AddWords
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
            this.Add = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.txtMeaning = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExample = new System.Windows.Forms.TextBox();
            this.lnkHome = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(218, 270);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(92, 23);
            this.Add.TabIndex = 4;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            this.Add.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Add_KeyUp);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(316, 270);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 5;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            this.Reset.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reset_KeyUp);
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(218, 98);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(315, 20);
            this.txtWord.TabIndex = 2;
            this.txtWord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtWord_KeyUp);
            // 
            // txtMeaning
            // 
            this.txtMeaning.Location = new System.Drawing.Point(218, 134);
            this.txtMeaning.Multiline = true;
            this.txtMeaning.Name = "txtMeaning";
            this.txtMeaning.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMeaning.Size = new System.Drawing.Size(315, 49);
            this.txtMeaning.TabIndex = 3;
            this.txtMeaning.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMeaning_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Meaning";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Example";
            // 
            // txtExample
            // 
            this.txtExample.Location = new System.Drawing.Point(218, 197);
            this.txtExample.Multiline = true;
            this.txtExample.Name = "txtExample";
            this.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExample.Size = new System.Drawing.Size(315, 49);
            this.txtExample.TabIndex = 4;
            this.txtExample.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExample_KeyUp);
            // 
            // lnkHome
            // 
            this.lnkHome.AutoSize = true;
            this.lnkHome.Location = new System.Drawing.Point(12, 9);
            this.lnkHome.Name = "lnkHome";
            this.lnkHome.Size = new System.Drawing.Size(86, 13);
            this.lnkHome.TabIndex = 11;
            this.lnkHome.TabStop = true;
            this.lnkHome.Text = "Return To Home";
            this.lnkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHome_LinkClicked);
            // 
            // AddWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 319);
            this.Controls.Add(this.lnkHome);
            this.Controls.Add(this.txtExample);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMeaning);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddWords";
            this.Text = "AddWords";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddWords_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AddWords_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AddWords_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.TextBox txtMeaning;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExample;
        private System.Windows.Forms.LinkLabel lnkHome;
    }
}