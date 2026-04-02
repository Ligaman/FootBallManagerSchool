namespace FootballManager
{
    partial class PlayersForm
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
            dgvPlayers = new DataGridView();
            cboClubFilter = new ComboBox();
            cboPositionFilter = new ComboBox();
            txtSearchName = new TextBox();
            btnRefresh = new Button();
            txtFullName = new TextBox();
            dtpBirthDate = new DateTimePicker();
            cboClub = new ComboBox();
            cboPosition = new ComboBox();
            numShirtNumber = new NumericUpDown();
            cboStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            lblSearch = new Label();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numShirtNumber).BeginInit();
            SuspendLayout();
            // 
            // dgvPlayers
            // 
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlayers.Location = new Point(49, 15);
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.Size = new Size(673, 150);
            dgvPlayers.TabIndex = 0;
            // 
            // cboClubFilter
            // 
            cboClubFilter.FormattingEnabled = true;
            cboClubFilter.Location = new Point(33, 206);
            cboClubFilter.Name = "cboClubFilter";
            cboClubFilter.Size = new Size(121, 23);
            cboClubFilter.TabIndex = 1;
            cboClubFilter.Text = "Club Filter";
            // 
            // cboPositionFilter
            // 
            cboPositionFilter.FormattingEnabled = true;
            cboPositionFilter.Location = new Point(33, 246);
            cboPositionFilter.Name = "cboPositionFilter";
            cboPositionFilter.Size = new Size(121, 23);
            cboPositionFilter.TabIndex = 2;
            cboPositionFilter.Text = "Position Filter";
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(71, 286);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(100, 23);
            txtSearchName.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(497, 444);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(496, 206);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(100, 23);
            txtFullName.TabIndex = 5;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(496, 243);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 23);
            dtpBirthDate.TabIndex = 6;
            // 
            // cboClub
            // 
            cboClub.FormattingEnabled = true;
            cboClub.Location = new Point(496, 286);
            cboClub.Name = "cboClub";
            cboClub.Size = new Size(121, 23);
            cboClub.TabIndex = 7;
            cboClub.Text = "Club";
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Location = new Point(496, 336);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(121, 23);
            cboPosition.TabIndex = 8;
            cboPosition.Text = "Position";
            // 
            // numShirtNumber
            // 
            numShirtNumber.Location = new Point(497, 379);
            numShirtNumber.Name = "numShirtNumber";
            numShirtNumber.Size = new Size(120, 23);
            numShirtNumber.TabIndex = 9;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(187, 206);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(121, 23);
            cboStatus.TabIndex = 10;
            cboStatus.Text = "Status";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(496, 415);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(577, 444);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(577, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(294, 397);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(127, 70);
            btnClear.TabIndex = 14;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(23, 289);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 15);
            lblSearch.TabIndex = 15;
            lblSearch.Text = "Search";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(434, 209);
            lblName.Name = "lblName";
            lblName.Size = new Size(61, 15);
            lblName.TabIndex = 16;
            lblName.Text = "Full Name";
            // 
            // PlayersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 524);
            Controls.Add(lblName);
            Controls.Add(lblSearch);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cboStatus);
            Controls.Add(numShirtNumber);
            Controls.Add(cboPosition);
            Controls.Add(cboClub);
            Controls.Add(dtpBirthDate);
            Controls.Add(txtFullName);
            Controls.Add(btnRefresh);
            Controls.Add(txtSearchName);
            Controls.Add(cboPositionFilter);
            Controls.Add(cboClubFilter);
            Controls.Add(dgvPlayers);
            Name = "PlayersForm";
            Text = "PlayersForm";
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numShirtNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPlayers;
        private ComboBox cboClubFilter;
        private ComboBox cboPositionFilter;
        private TextBox txtSearchName;
        private Button btnRefresh;
        private TextBox txtFullName;
        private DateTimePicker dtpBirthDate;
        private ComboBox cboClub;
        private ComboBox cboPosition;
        private NumericUpDown numShirtNumber;
        private ComboBox cboStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label lblSearch;
        private Label lblName;
    }
}