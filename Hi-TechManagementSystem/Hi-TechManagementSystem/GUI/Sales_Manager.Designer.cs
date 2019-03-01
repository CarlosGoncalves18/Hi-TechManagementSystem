namespace Hi_TechManagementSystem.GUI
{
    partial class Sales_Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Manager));
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelSearchBy = new System.Windows.Forms.Label();
            this.textBoxInfoClient = new System.Windows.Forms.TextBox();
            this.comboBoxSearchClient = new System.Windows.Forms.ComboBox();
            this.buttonDeleteClient = new System.Windows.Forms.Button();
            this.buttonSaveClient = new System.Windows.Forms.Button();
            this.buttonUpdateClient = new System.Windows.Forms.Button();
            this.buttonListClient = new System.Windows.Forms.Button();
            this.groupBoxClientInformation = new System.Windows.Forms.GroupBox();
            this.textBoxEmailClient = new System.Windows.Forms.TextBox();
            this.labelClientEmail = new System.Windows.Forms.Label();
            this.textBoxZipCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInstitutionCity = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.maskedTextBoxPhoneClient = new System.Windows.Forms.MaskedTextBox();
            this.textBoxInstitutionAddress = new System.Windows.Forms.TextBox();
            this.textBoxInstitutionName = new System.Windows.Forms.TextBox();
            this.textBoxClientID = new System.Windows.Forms.TextBox();
            this.labelPhoneNumberClient = new System.Windows.Forms.Label();
            this.labelAdress = new System.Windows.Forms.Label();
            this.labelInstitutionName = new System.Windows.Forms.Label();
            this.labelClientNumber = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.listViewClient = new System.Windows.Forms.ListView();
            this.colClientID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInstitutionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colZipCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxClient.SuspendLayout();
            this.groupBoxClientInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.Controls.Add(this.buttonSearch);
            this.groupBoxClient.Controls.Add(this.labelSearchBy);
            this.groupBoxClient.Controls.Add(this.textBoxInfoClient);
            this.groupBoxClient.Controls.Add(this.comboBoxSearchClient);
            this.groupBoxClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxClient.Location = new System.Drawing.Point(557, 105);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Size = new System.Drawing.Size(233, 126);
            this.groupBoxClient.TabIndex = 55;
            this.groupBoxClient.TabStop = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Silver;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.Black;
            this.buttonSearch.Location = new System.Drawing.Point(152, 44);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(70, 31);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelSearchBy
            // 
            this.labelSearchBy.AutoSize = true;
            this.labelSearchBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchBy.ForeColor = System.Drawing.Color.White;
            this.labelSearchBy.Location = new System.Drawing.Point(6, 18);
            this.labelSearchBy.Name = "labelSearchBy";
            this.labelSearchBy.Size = new System.Drawing.Size(69, 13);
            this.labelSearchBy.TabIndex = 27;
            this.labelSearchBy.Text = "Search By:";
            // 
            // textBoxInfoClient
            // 
            this.textBoxInfoClient.Location = new System.Drawing.Point(5, 78);
            this.textBoxInfoClient.Name = "textBoxInfoClient";
            this.textBoxInfoClient.Size = new System.Drawing.Size(133, 22);
            this.textBoxInfoClient.TabIndex = 0;
            // 
            // comboBoxSearchClient
            // 
            this.comboBoxSearchClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchClient.FormattingEnabled = true;
            this.comboBoxSearchClient.Items.AddRange(new object[] {
            "Client Number"});
            this.comboBoxSearchClient.Location = new System.Drawing.Point(5, 34);
            this.comboBoxSearchClient.Name = "comboBoxSearchClient";
            this.comboBoxSearchClient.Size = new System.Drawing.Size(133, 24);
            this.comboBoxSearchClient.TabIndex = 22;
            // 
            // buttonDeleteClient
            // 
            this.buttonDeleteClient.BackColor = System.Drawing.Color.Silver;
            this.buttonDeleteClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeleteClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteClient.ForeColor = System.Drawing.Color.Black;
            this.buttonDeleteClient.Location = new System.Drawing.Point(159, 126);
            this.buttonDeleteClient.Name = "buttonDeleteClient";
            this.buttonDeleteClient.Size = new System.Drawing.Size(70, 31);
            this.buttonDeleteClient.TabIndex = 8;
            this.buttonDeleteClient.Text = "&Delete";
            this.buttonDeleteClient.UseVisualStyleBackColor = false;
            this.buttonDeleteClient.Click += new System.EventHandler(this.buttonDeleteClient_Click);
            // 
            // buttonSaveClient
            // 
            this.buttonSaveClient.BackColor = System.Drawing.Color.Silver;
            this.buttonSaveClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaveClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveClient.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveClient.Location = new System.Drawing.Point(37, 126);
            this.buttonSaveClient.Name = "buttonSaveClient";
            this.buttonSaveClient.Size = new System.Drawing.Size(70, 31);
            this.buttonSaveClient.TabIndex = 7;
            this.buttonSaveClient.Text = "&Save";
            this.buttonSaveClient.UseVisualStyleBackColor = false;
            this.buttonSaveClient.Click += new System.EventHandler(this.buttonSaveClient_Click);
            // 
            // buttonUpdateClient
            // 
            this.buttonUpdateClient.BackColor = System.Drawing.Color.Silver;
            this.buttonUpdateClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUpdateClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateClient.ForeColor = System.Drawing.Color.Black;
            this.buttonUpdateClient.Location = new System.Drawing.Point(286, 126);
            this.buttonUpdateClient.Name = "buttonUpdateClient";
            this.buttonUpdateClient.Size = new System.Drawing.Size(70, 31);
            this.buttonUpdateClient.TabIndex = 9;
            this.buttonUpdateClient.Text = "&Update";
            this.buttonUpdateClient.UseVisualStyleBackColor = false;
            this.buttonUpdateClient.Click += new System.EventHandler(this.buttonUpdateClient_Click);
            // 
            // buttonListClient
            // 
            this.buttonListClient.BackColor = System.Drawing.Color.Silver;
            this.buttonListClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonListClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListClient.ForeColor = System.Drawing.Color.Black;
            this.buttonListClient.Location = new System.Drawing.Point(413, 126);
            this.buttonListClient.Name = "buttonListClient";
            this.buttonListClient.Size = new System.Drawing.Size(70, 31);
            this.buttonListClient.TabIndex = 10;
            this.buttonListClient.Text = "&List";
            this.buttonListClient.UseVisualStyleBackColor = false;
            this.buttonListClient.Click += new System.EventHandler(this.buttonListClient_Click);
            // 
            // groupBoxClientInformation
            // 
            this.groupBoxClientInformation.Controls.Add(this.buttonDeleteClient);
            this.groupBoxClientInformation.Controls.Add(this.textBoxEmailClient);
            this.groupBoxClientInformation.Controls.Add(this.buttonSaveClient);
            this.groupBoxClientInformation.Controls.Add(this.labelClientEmail);
            this.groupBoxClientInformation.Controls.Add(this.buttonUpdateClient);
            this.groupBoxClientInformation.Controls.Add(this.textBoxZipCode);
            this.groupBoxClientInformation.Controls.Add(this.buttonListClient);
            this.groupBoxClientInformation.Controls.Add(this.label1);
            this.groupBoxClientInformation.Controls.Add(this.textBoxInstitutionCity);
            this.groupBoxClientInformation.Controls.Add(this.labelCity);
            this.groupBoxClientInformation.Controls.Add(this.maskedTextBoxPhoneClient);
            this.groupBoxClientInformation.Controls.Add(this.textBoxInstitutionAddress);
            this.groupBoxClientInformation.Controls.Add(this.textBoxInstitutionName);
            this.groupBoxClientInformation.Controls.Add(this.textBoxClientID);
            this.groupBoxClientInformation.Controls.Add(this.labelPhoneNumberClient);
            this.groupBoxClientInformation.Controls.Add(this.labelAdress);
            this.groupBoxClientInformation.Controls.Add(this.labelInstitutionName);
            this.groupBoxClientInformation.Controls.Add(this.labelClientNumber);
            this.groupBoxClientInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxClientInformation.ForeColor = System.Drawing.Color.White;
            this.groupBoxClientInformation.Location = new System.Drawing.Point(12, 105);
            this.groupBoxClientInformation.Name = "groupBoxClientInformation";
            this.groupBoxClientInformation.Size = new System.Drawing.Size(539, 173);
            this.groupBoxClientInformation.TabIndex = 53;
            this.groupBoxClientInformation.TabStop = false;
            this.groupBoxClientInformation.Text = "Client Information";
            // 
            // textBoxEmailClient
            // 
            this.textBoxEmailClient.Location = new System.Drawing.Point(408, 41);
            this.textBoxEmailClient.Name = "textBoxEmailClient";
            this.textBoxEmailClient.Size = new System.Drawing.Size(115, 21);
            this.textBoxEmailClient.TabIndex = 6;
            // 
            // labelClientEmail
            // 
            this.labelClientEmail.AutoSize = true;
            this.labelClientEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientEmail.Location = new System.Drawing.Point(405, 25);
            this.labelClientEmail.Name = "labelClientEmail";
            this.labelClientEmail.Size = new System.Drawing.Size(41, 13);
            this.labelClientEmail.TabIndex = 13;
            this.labelClientEmail.Text = "Email:";
            // 
            // textBoxZipCode
            // 
            this.textBoxZipCode.Location = new System.Drawing.Point(408, 91);
            this.textBoxZipCode.Name = "textBoxZipCode";
            this.textBoxZipCode.Size = new System.Drawing.Size(115, 21);
            this.textBoxZipCode.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Zip Code:";
            // 
            // textBoxInstitutionCity
            // 
            this.textBoxInstitutionCity.Location = new System.Drawing.Point(286, 91);
            this.textBoxInstitutionCity.Name = "textBoxInstitutionCity";
            this.textBoxInstitutionCity.Size = new System.Drawing.Size(115, 21);
            this.textBoxInstitutionCity.TabIndex = 3;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCity.Location = new System.Drawing.Point(283, 75);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(32, 13);
            this.labelCity.TabIndex = 9;
            this.labelCity.Text = "City:";
            // 
            // maskedTextBoxPhoneClient
            // 
            this.maskedTextBoxPhoneClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxPhoneClient.Location = new System.Drawing.Point(286, 41);
            this.maskedTextBoxPhoneClient.Mask = "(999) 000-0000";
            this.maskedTextBoxPhoneClient.Name = "maskedTextBoxPhoneClient";
            this.maskedTextBoxPhoneClient.Size = new System.Drawing.Size(115, 22);
            this.maskedTextBoxPhoneClient.TabIndex = 5;
            // 
            // textBoxInstitutionAddress
            // 
            this.textBoxInstitutionAddress.Location = new System.Drawing.Point(19, 91);
            this.textBoxInstitutionAddress.Name = "textBoxInstitutionAddress";
            this.textBoxInstitutionAddress.Size = new System.Drawing.Size(261, 21);
            this.textBoxInstitutionAddress.TabIndex = 2;
            // 
            // textBoxInstitutionName
            // 
            this.textBoxInstitutionName.Location = new System.Drawing.Point(140, 42);
            this.textBoxInstitutionName.Name = "textBoxInstitutionName";
            this.textBoxInstitutionName.Size = new System.Drawing.Size(140, 21);
            this.textBoxInstitutionName.TabIndex = 1;
            // 
            // textBoxClientID
            // 
            this.textBoxClientID.Location = new System.Drawing.Point(19, 42);
            this.textBoxClientID.Name = "textBoxClientID";
            this.textBoxClientID.Size = new System.Drawing.Size(115, 21);
            this.textBoxClientID.TabIndex = 0;
            // 
            // labelPhoneNumberClient
            // 
            this.labelPhoneNumberClient.AutoSize = true;
            this.labelPhoneNumberClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhoneNumberClient.Location = new System.Drawing.Point(283, 27);
            this.labelPhoneNumberClient.Name = "labelPhoneNumberClient";
            this.labelPhoneNumberClient.Size = new System.Drawing.Size(98, 13);
            this.labelPhoneNumberClient.TabIndex = 5;
            this.labelPhoneNumberClient.Text = "Phone Number :";
            // 
            // labelAdress
            // 
            this.labelAdress.AutoSize = true;
            this.labelAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdress.Location = new System.Drawing.Point(19, 75);
            this.labelAdress.Name = "labelAdress";
            this.labelAdress.Size = new System.Drawing.Size(56, 13);
            this.labelAdress.TabIndex = 4;
            this.labelAdress.Text = "Address:";
            // 
            // labelInstitutionName
            // 
            this.labelInstitutionName.AutoSize = true;
            this.labelInstitutionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstitutionName.Location = new System.Drawing.Point(137, 26);
            this.labelInstitutionName.Name = "labelInstitutionName";
            this.labelInstitutionName.Size = new System.Drawing.Size(112, 13);
            this.labelInstitutionName.TabIndex = 3;
            this.labelInstitutionName.Text = "Institution\'s Name:";
            // 
            // labelClientNumber
            // 
            this.labelClientNumber.AutoSize = true;
            this.labelClientNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientNumber.Location = new System.Drawing.Point(19, 26);
            this.labelClientNumber.Name = "labelClientNumber";
            this.labelClientNumber.Size = new System.Drawing.Size(60, 13);
            this.labelClientNumber.TabIndex = 2;
            this.labelClientNumber.Text = "Client ID:";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(16, 21);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(657, 64);
            this.Title.TabIndex = 86;
            this.Title.Text = "Hi-Tech Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(690, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 85;
            this.pictureBox1.TabStop = false;
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackColor = System.Drawing.Color.Silver;
            this.buttonReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.ForeColor = System.Drawing.Color.Black;
            this.buttonReturn.Location = new System.Drawing.Point(588, 242);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(85, 41);
            this.buttonReturn.TabIndex = 0;
            this.buttonReturn.Text = "&Return";
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Silver;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.Black;
            this.buttonExit.Location = new System.Drawing.Point(690, 242);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(84, 41);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "&Logout";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // listViewClient
            // 
            this.listViewClient.BackColor = System.Drawing.Color.Gray;
            this.listViewClient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colClientID,
            this.colInstitutionName,
            this.colAddress,
            this.colCity,
            this.colZipCode,
            this.colPhoneNumber,
            this.colEmail});
            this.listViewClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewClient.ForeColor = System.Drawing.Color.Black;
            this.listViewClient.GridLines = true;
            this.listViewClient.Location = new System.Drawing.Point(12, 294);
            this.listViewClient.Name = "listViewClient";
            this.listViewClient.Size = new System.Drawing.Size(778, 200);
            this.listViewClient.TabIndex = 81;
            this.listViewClient.UseCompatibleStateImageBehavior = false;
            this.listViewClient.View = System.Windows.Forms.View.Details;
            // 
            // colClientID
            // 
            this.colClientID.Text = "Client ID:";
            this.colClientID.Width = 75;
            // 
            // colInstitutionName
            // 
            this.colInstitutionName.Text = "Institution\'s Name:";
            this.colInstitutionName.Width = 142;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address:";
            this.colAddress.Width = 144;
            // 
            // colCity
            // 
            this.colCity.Text = "City:";
            this.colCity.Width = 64;
            // 
            // colZipCode
            // 
            this.colZipCode.Text = "ZipCode:";
            this.colZipCode.Width = 79;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.Text = "PhoneNumber:";
            this.colPhoneNumber.Width = 108;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email:";
            this.colEmail.Width = 135;
            // 
            // Sales_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(802, 506);
            this.Controls.Add(this.listViewClient);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxClient);
            this.Controls.Add(this.groupBoxClientInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sales_Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales_Manager";
            this.groupBoxClient.ResumeLayout(false);
            this.groupBoxClient.PerformLayout();
            this.groupBoxClientInformation.ResumeLayout(false);
            this.groupBoxClientInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.Button buttonDeleteClient;
        private System.Windows.Forms.Button buttonSaveClient;
        private System.Windows.Forms.TextBox textBoxInfoClient;
        private System.Windows.Forms.Button buttonUpdateClient;
        private System.Windows.Forms.Button buttonListClient;
        private System.Windows.Forms.ComboBox comboBoxSearchClient;
        private System.Windows.Forms.GroupBox groupBoxClientInformation;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPhoneClient;
        private System.Windows.Forms.TextBox textBoxInstitutionAddress;
        private System.Windows.Forms.TextBox textBoxInstitutionName;
        private System.Windows.Forms.TextBox textBoxClientID;
        private System.Windows.Forms.Label labelPhoneNumberClient;
        private System.Windows.Forms.Label labelAdress;
        private System.Windows.Forms.Label labelInstitutionName;
        private System.Windows.Forms.Label labelClientNumber;
        private System.Windows.Forms.TextBox textBoxInstitutionCity;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxZipCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmailClient;
        private System.Windows.Forms.Label labelClientEmail;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelSearchBy;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListView listViewClient;
        private System.Windows.Forms.ColumnHeader colClientID;
        private System.Windows.Forms.ColumnHeader colInstitutionName;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colCity;
        private System.Windows.Forms.ColumnHeader colZipCode;
        private System.Windows.Forms.ColumnHeader colPhoneNumber;
        private System.Windows.Forms.ColumnHeader colEmail;
    }
}