namespace iWords
{
    partial class RevisionCards
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.hdnPreWord = new System.Windows.Forms.Label();
            this.btnWord = new System.Windows.Forms.Button();
            this.lnkHome = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(623, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(44, 319);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnNext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnNext_KeyUp);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(-1, 0);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(45, 319);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            this.btnPrevious.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnPrevious_KeyUp);
            // 
            // hdnPreWord
            // 
            this.hdnPreWord.AutoSize = true;
            this.hdnPreWord.Location = new System.Drawing.Point(64, 28);
            this.hdnPreWord.Name = "hdnPreWord";
            this.hdnPreWord.Size = new System.Drawing.Size(67, 13);
            this.hdnPreWord.TabIndex = 3;
            this.hdnPreWord.Text = "hdnPreWord";
            this.hdnPreWord.Visible = false;
            // 
            // btnWord
            // 
            this.btnWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWord.Location = new System.Drawing.Point(67, 118);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(529, 65);
            this.btnWord.TabIndex = 0;
            this.btnWord.Text = "Word";
            this.btnWord.UseVisualStyleBackColor = true;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            this.btnWord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnWord_KeyUp);
            // 
            // lnkHome
            // 
            this.lnkHome.AutoSize = true;
            this.lnkHome.Location = new System.Drawing.Point(64, 9);
            this.lnkHome.Name = "lnkHome";
            this.lnkHome.Size = new System.Drawing.Size(86, 13);
            this.lnkHome.TabIndex = 5;
            this.lnkHome.TabStop = true;
            this.lnkHome.Text = "Return To Home";
            this.lnkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHome_LinkClicked);
            // 
            // RevisionCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 319);
            this.Controls.Add(this.lnkHome);
            this.Controls.Add(this.btnWord);
            this.Controls.Add(this.hdnPreWord);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RevisionCards";
            this.Text = "RevisionCards";
            this.Load += new System.EventHandler(this.RevisionCards_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RevisionCards_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RevisionCards_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RevisionCards_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label hdnPreWord;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.LinkLabel lnkHome;
    }
}