namespace iWords
{
    partial class WordDetails
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
            this.lblWord = new System.Windows.Forms.Label();
            this.lblMeaning = new System.Windows.Forms.Label();
            this.lblExample = new System.Windows.Forms.Label();
            this.lblKnowCnt = new System.Windows.Forms.Label();
            this.lblDontKnowCnt = new System.Windows.Forms.Label();
            this.btnKnow = new System.Windows.Forms.Button();
            this.btnDntKnw = new System.Windows.Forms.Button();
            this.lnkHome = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWord.Location = new System.Drawing.Point(58, 28);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(133, 39);
            this.lblWord.TabIndex = 0;
            this.lblWord.Text = "lblWord";
            // 
            // lblMeaning
            // 
            this.lblMeaning.AutoSize = true;
            this.lblMeaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeaning.Location = new System.Drawing.Point(81, 74);
            this.lblMeaning.Name = "lblMeaning";
            this.lblMeaning.Size = new System.Drawing.Size(64, 25);
            this.lblMeaning.TabIndex = 1;
            this.lblMeaning.Text = "label2";
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExample.Location = new System.Drawing.Point(83, 119);
            this.lblExample.MaximumSize = new System.Drawing.Size(500, 0);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(46, 17);
            this.lblExample.TabIndex = 2;
            this.lblExample.Text = "label3";
            // 
            // lblKnowCnt
            // 
            this.lblKnowCnt.AutoSize = true;
            this.lblKnowCnt.Location = new System.Drawing.Point(81, 204);
            this.lblKnowCnt.Name = "lblKnowCnt";
            this.lblKnowCnt.Size = new System.Drawing.Size(35, 13);
            this.lblKnowCnt.TabIndex = 3;
            this.lblKnowCnt.Text = "label4";
            // 
            // lblDontKnowCnt
            // 
            this.lblDontKnowCnt.AutoSize = true;
            this.lblDontKnowCnt.Location = new System.Drawing.Point(81, 256);
            this.lblDontKnowCnt.Name = "lblDontKnowCnt";
            this.lblDontKnowCnt.Size = new System.Drawing.Size(35, 13);
            this.lblDontKnowCnt.TabIndex = 4;
            this.lblDontKnowCnt.Text = "label5";
            // 
            // btnKnow
            // 
            this.btnKnow.Location = new System.Drawing.Point(60, 178);
            this.btnKnow.Name = "btnKnow";
            this.btnKnow.Size = new System.Drawing.Size(97, 23);
            this.btnKnow.TabIndex = 5;
            this.btnKnow.Text = "I know this";
            this.btnKnow.UseVisualStyleBackColor = true;
            this.btnKnow.Click += new System.EventHandler(this.btnKnow_Click);
            this.btnKnow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WordDetails_KeyUp);
            // 
            // btnDntKnw
            // 
            this.btnDntKnw.Location = new System.Drawing.Point(61, 230);
            this.btnDntKnw.Name = "btnDntKnw";
            this.btnDntKnw.Size = new System.Drawing.Size(97, 23);
            this.btnDntKnw.TabIndex = 6;
            this.btnDntKnw.Text = "I don\'t know this";
            this.btnDntKnw.UseVisualStyleBackColor = true;
            this.btnDntKnw.Click += new System.EventHandler(this.btnDntKnw_Click);
            this.btnDntKnw.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WordDetails_KeyUp);
            // 
            // lnkHome
            // 
            this.lnkHome.AutoSize = true;
            this.lnkHome.Location = new System.Drawing.Point(12, 9);
            this.lnkHome.Name = "lnkHome";
            this.lnkHome.Size = new System.Drawing.Size(86, 13);
            this.lnkHome.TabIndex = 7;
            this.lnkHome.TabStop = true;
            this.lnkHome.Text = "Return To Home";
            this.lnkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHome_LinkClicked);
            // 
            // WordDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 319);
            this.Controls.Add(this.lnkHome);
            this.Controls.Add(this.btnDntKnw);
            this.Controls.Add(this.btnKnow);
            this.Controls.Add(this.lblDontKnowCnt);
            this.Controls.Add(this.lblKnowCnt);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.lblMeaning);
            this.Controls.Add(this.lblWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WordDetails";
            this.Text = "WordDetails";
            this.Load += new System.EventHandler(this.WordDetails_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WordDetails_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WordDetails_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WordDetails_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WordDetails_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblMeaning;
        private System.Windows.Forms.Label lblExample;
        private System.Windows.Forms.Label lblKnowCnt;
        private System.Windows.Forms.Label lblDontKnowCnt;
        private System.Windows.Forms.Button btnKnow;
        private System.Windows.Forms.Button btnDntKnw;
        private System.Windows.Forms.LinkLabel lnkHome;
    }
}