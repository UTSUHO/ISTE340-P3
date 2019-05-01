namespace BogaardP3
{
    partial class FacStaff
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.iA = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.interestArea = new System.Windows.Forms.Label();
            this.office = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.Label();
            this.website = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(204, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(12, 12);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(41, 12);
            this.name.TabIndex = 1;
            this.name.Text = "Name: ";
            // 
            // iA
            // 
            this.iA.AutoSize = true;
            this.iA.Location = new System.Drawing.Point(12, 75);
            this.iA.Name = "iA";
            this.iA.Size = new System.Drawing.Size(83, 12);
            this.iA.TabIndex = 2;
            this.iA.Text = "InterestArea:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(12, 48);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(47, 12);
            this.title.TabIndex = 3;
            this.title.Text = "Title: ";
            // 
            // interestArea
            // 
            this.interestArea.AutoSize = true;
            this.interestArea.Location = new System.Drawing.Point(17, 99);
            this.interestArea.Name = "interestArea";
            this.interestArea.Size = new System.Drawing.Size(0, 12);
            this.interestArea.TabIndex = 4;
            // 
            // office
            // 
            this.office.AutoSize = true;
            this.office.Location = new System.Drawing.Point(12, 123);
            this.office.Name = "office";
            this.office.Size = new System.Drawing.Size(53, 12);
            this.office.TabIndex = 6;
            this.office.Text = "Office: ";
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Location = new System.Drawing.Point(12, 152);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(47, 12);
            this.phone.TabIndex = 8;
            this.phone.Text = "Phone: ";
            // 
            // website
            // 
            this.website.AutoSize = true;
            this.website.Location = new System.Drawing.Point(12, 240);
            this.website.Name = "website";
            this.website.Size = new System.Drawing.Size(0, 12);
            this.website.TabIndex = 9;
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(12, 180);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(47, 12);
            this.email.TabIndex = 10;
            this.email.Text = "Email: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Website: ";
            // 
            // FacStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 323);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email);
            this.Controls.Add(this.website);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.office);
            this.Controls.Add(this.interestArea);
            this.Controls.Add(this.title);
            this.Controls.Add(this.iA);
            this.Controls.Add(this.name);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FacStaff";
            this.Text = "FacStaff";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label iA;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label interestArea;
        private System.Windows.Forms.Label office;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label website;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label label1;
    }
}