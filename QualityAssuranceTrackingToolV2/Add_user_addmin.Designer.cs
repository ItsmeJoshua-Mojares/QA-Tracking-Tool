namespace QualityAssuranceTrackingToolV2
{
    partial class Add_user_addmin
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.usertb = new System.Windows.Forms.TextBox();
            this.tableloginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appData = new QualityAssuranceTrackingToolV2.AppData();
            this.passtb = new System.Windows.Forms.TextBox();
            this.rolecb = new System.Windows.Forms.ComboBox();
            this.newbtn = new System.Windows.Forms.Button();
            this.editbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableloginTableAdapter = new QualityAssuranceTrackingToolV2.AppDataTableAdapters.tableloginTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.tableadmin = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tableloginBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableadmin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // usertb
            // 
            this.usertb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableloginBindingSource, "Username", true));
            this.usertb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertb.Location = new System.Drawing.Point(122, 30);
            this.usertb.Name = "usertb";
            this.usertb.Size = new System.Drawing.Size(198, 22);
            this.usertb.TabIndex = 3;
            // 
            // tableloginBindingSource
            // 
            this.tableloginBindingSource.DataMember = "tablelogin";
            this.tableloginBindingSource.DataSource = this.appData;
            // 
            // appData
            // 
            this.appData.DataSetName = "AppData";
            this.appData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // passtb
            // 
            this.passtb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tableloginBindingSource, "Password", true));
            this.passtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passtb.Location = new System.Drawing.Point(122, 73);
            this.passtb.Name = "passtb";
            this.passtb.Size = new System.Drawing.Size(198, 22);
            this.passtb.TabIndex = 4;
            // 
            // rolecb
            // 
            this.rolecb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.tableloginBindingSource, "Role", true));
            this.rolecb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolecb.FormattingEnabled = true;
            this.rolecb.Items.AddRange(new object[] {
            "ADMIN",
            "USER"});
            this.rolecb.Location = new System.Drawing.Point(122, 116);
            this.rolecb.Name = "rolecb";
            this.rolecb.Size = new System.Drawing.Size(123, 24);
            this.rolecb.TabIndex = 5;
            // 
            // newbtn
            // 
            this.newbtn.Location = new System.Drawing.Point(37, 177);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(283, 23);
            this.newbtn.TabIndex = 6;
            this.newbtn.Text = "New";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // editbtn
            // 
            this.editbtn.Location = new System.Drawing.Point(37, 220);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(283, 23);
            this.editbtn.TabIndex = 7;
            this.editbtn.Text = "Edit";
            this.editbtn.UseVisualStyleBackColor = true;
            this.editbtn.Click += new System.EventHandler(this.editbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(37, 263);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(283, 23);
            this.savebtn.TabIndex = 8;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(37, 310);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(283, 23);
            this.deletebtn.TabIndex = 9;
            this.deletebtn.Text = "Delete";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(37, 356);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(283, 23);
            this.cancelbtn.TabIndex = 10;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Role:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(723, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "X";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tableloginTableAdapter
            // 
            this.tableloginTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(283, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tableadmin
            // 
            this.tableadmin.AllowUserToAddRows = false;
            this.tableadmin.AllowUserToDeleteRows = false;
            this.tableadmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableadmin.Location = new System.Drawing.Point(350, 36);
            this.tableadmin.Name = "tableadmin";
            this.tableadmin.ReadOnly = true;
            this.tableadmin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableadmin.Size = new System.Drawing.Size(398, 380);
            this.tableadmin.TabIndex = 17;
            this.tableadmin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableadmin_CellContentClick);
            // 
            // Add_user_addmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 428);
            this.Controls.Add(this.tableadmin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.editbtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.rolecb);
            this.Controls.Add(this.passtb);
            this.Controls.Add(this.usertb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_user_addmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add user addmin";
            this.Load += new System.EventHandler(this.Add_user_addmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableloginBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableadmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usertb;
        private System.Windows.Forms.TextBox passtb;
        private System.Windows.Forms.ComboBox rolecb;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Button editbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private AppData appData;
        private System.Windows.Forms.BindingSource tableloginBindingSource;
        private AppDataTableAdapters.tableloginTableAdapter tableloginTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tableadmin;
    }
}