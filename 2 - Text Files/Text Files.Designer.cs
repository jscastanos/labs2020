namespace _2___Text_Files
{
    partial class frmTextFile
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblFname = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblIsAlive = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.chkIsAlive = new System.Windows.Forms.CheckBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnSaveList = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(12, 25);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(301, 40);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Text File Challenge";
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFname.Location = new System.Drawing.Point(15, 97);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(122, 25);
            this.lblFname.TabIndex = 1;
            this.lblFname.Text = "First Name:";
            // 
            // txtFname
            // 
            this.txtFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.Location = new System.Drawing.Point(143, 91);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(195, 31);
            this.txtFname.TabIndex = 2;
            // 
            // txtLname
            // 
            this.txtLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLname.Location = new System.Drawing.Point(143, 144);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(193, 31);
            this.txtLname.TabIndex = 4;
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLname.Location = new System.Drawing.Point(15, 150);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(121, 25);
            this.lblLname.TabIndex = 3;
            this.lblLname.Text = "Last Name:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(16, 205);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(56, 25);
            this.lblAge.TabIndex = 5;
            this.lblAge.Text = "Age:";
            // 
            // lblIsAlive
            // 
            this.lblIsAlive.AutoSize = true;
            this.lblIsAlive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsAlive.Location = new System.Drawing.Point(15, 255);
            this.lblIsAlive.Name = "lblIsAlive";
            this.lblIsAlive.Size = new System.Drawing.Size(81, 25);
            this.lblIsAlive.TabIndex = 6;
            this.lblIsAlive.Text = "Is Alive";
            // 
            // numAge
            // 
            this.numAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAge.Location = new System.Drawing.Point(143, 199);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(76, 31);
            this.numAge.TabIndex = 7;
            // 
            // chkIsAlive
            // 
            this.chkIsAlive.AutoSize = true;
            this.chkIsAlive.Location = new System.Drawing.Point(143, 262);
            this.chkIsAlive.Name = "chkIsAlive";
            this.chkIsAlive.Size = new System.Drawing.Size(15, 14);
            this.chkIsAlive.TabIndex = 8;
            this.chkIsAlive.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(21, 302);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(317, 55);
            this.btnAddUser.TabIndex = 9;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.BtnAddUser_Click);
            // 
            // btnSaveList
            // 
            this.btnSaveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveList.Location = new System.Drawing.Point(19, 363);
            this.btnSaveList.Name = "btnSaveList";
            this.btnSaveList.Size = new System.Drawing.Size(317, 55);
            this.btnSaveList.TabIndex = 10;
            this.btnSaveList.Text = "Save List";
            this.btnSaveList.UseVisualStyleBackColor = true;
            this.btnSaveList.Click += new System.EventHandler(this.BtnSaveList_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 25;
            this.lstUsers.Location = new System.Drawing.Point(369, 91);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(404, 329);
            this.lstUsers.TabIndex = 11;
            // 
            // frmTextFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.btnSaveList);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.chkIsAlive);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.lblIsAlive);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.lblLname);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.lblFname);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmTextFile";
            this.Text = "Text_Files";
            this.Load += new System.EventHandler(this.FrmTextFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblIsAlive;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.CheckBox chkIsAlive;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnSaveList;
        private System.Windows.Forms.ListBox lstUsers;
    }
}

