namespace FootballManager
{
    partial class ClubsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvClubs = new DataGridView();
            txtName = new TextBox();
            txtCity = new TextBox();
            btnInitDb = new Button();
            btnAdd = new Button();
            btnLoad = new Button();
            btnClear = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClubs).BeginInit();
            SuspendLayout();
            // 
            // dgvClubs
            // 
            dgvClubs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClubs.Location = new Point(31, 12);
            dgvClubs.Name = "dgvClubs";
            dgvClubs.Size = new Size(730, 150);
            dgvClubs.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(345, 203);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            txtName.Text = "Name";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(205, 203);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(100, 23);
            txtCity.TabIndex = 2;
            txtCity.Text = "City";
            // 
            // btnInitDb
            // 
            btnInitDb.Location = new Point(31, 203);
            btnInitDb.Name = "btnInitDb";
            btnInitDb.Size = new Size(75, 23);
            btnInitDb.TabIndex = 3;
            btnInitDb.Text = "InitDb";
            btnInitDb.UseVisualStyleBackColor = true;
            btnInitDb.Click += btnInitDb_Click_1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(31, 307);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(31, 254);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(31, 404);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(31, 358);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(131, 404);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // ClubsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnClear);
            Controls.Add(btnLoad);
            Controls.Add(btnAdd);
            Controls.Add(btnInitDb);
            Controls.Add(txtCity);
            Controls.Add(txtName);
            Controls.Add(dgvClubs);
            Name = "ClubsForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvClubs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClubs;
        private TextBox txtName;
        private TextBox txtCity;
        private Button btnInitDb;
        private Button btnAdd;
        private Button btnLoad;
        private Button btnClear;
        private Button btnEdit;
        private Button btnDelete;
    }
}
