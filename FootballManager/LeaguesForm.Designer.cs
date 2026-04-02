namespace FootballManager
{
    partial class LeaguesForm
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
            dgvLeagues = new DataGridView();
            dgvParticipants = new DataGridView();
            cboAvailableClubs = new ComboBox();
            txtLeagueName = new TextBox();
            txtSeason = new TextBox();
            btnAddLeague = new Button();
            btnEditLeague = new Button();
            btnDeleteLeague = new Button();
            btnAddClubToLeague = new Button();
            btnRemoveClubFromLeague = new Button();
            btnRefresh = new Button();
            lblLeagueName = new Label();
            lblSeason = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLeagues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).BeginInit();
            SuspendLayout();
            // 
            // dgvLeagues
            // 
            dgvLeagues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeagues.Location = new Point(22, 12);
            dgvLeagues.Name = "dgvLeagues";
            dgvLeagues.Size = new Size(419, 150);
            dgvLeagues.TabIndex = 0;
            // 
            // dgvParticipants
            // 
            dgvParticipants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParticipants.Location = new Point(22, 181);
            dgvParticipants.Name = "dgvParticipants";
            dgvParticipants.Size = new Size(419, 137);
            dgvParticipants.TabIndex = 1;
            // 
            // cboAvailableClubs
            // 
            cboAvailableClubs.FormattingEnabled = true;
            cboAvailableClubs.Location = new Point(478, 21);
            cboAvailableClubs.Name = "cboAvailableClubs";
            cboAvailableClubs.Size = new Size(198, 23);
            cboAvailableClubs.TabIndex = 2;
            // 
            // txtLeagueName
            // 
            txtLeagueName.Location = new Point(484, 91);
            txtLeagueName.Name = "txtLeagueName";
            txtLeagueName.Size = new Size(100, 23);
            txtLeagueName.TabIndex = 3;
            // 
            // txtSeason
            // 
            txtSeason.Location = new Point(629, 91);
            txtSeason.Name = "txtSeason";
            txtSeason.Size = new Size(100, 23);
            txtSeason.TabIndex = 4;
            // 
            // btnAddLeague
            // 
            btnAddLeague.Location = new Point(447, 224);
            btnAddLeague.Name = "btnAddLeague";
            btnAddLeague.Size = new Size(75, 23);
            btnAddLeague.TabIndex = 5;
            btnAddLeague.Text = "Add";
            btnAddLeague.UseVisualStyleBackColor = true;
            // 
            // btnEditLeague
            // 
            btnEditLeague.Location = new Point(528, 224);
            btnEditLeague.Name = "btnEditLeague";
            btnEditLeague.Size = new Size(75, 23);
            btnEditLeague.TabIndex = 6;
            btnEditLeague.Text = "Edit";
            btnEditLeague.UseVisualStyleBackColor = true;
            // 
            // btnDeleteLeague
            // 
            btnDeleteLeague.Location = new Point(609, 224);
            btnDeleteLeague.Name = "btnDeleteLeague";
            btnDeleteLeague.Size = new Size(75, 23);
            btnDeleteLeague.TabIndex = 7;
            btnDeleteLeague.Text = "Delete";
            btnDeleteLeague.UseVisualStyleBackColor = true;
            // 
            // btnAddClubToLeague
            // 
            btnAddClubToLeague.Location = new Point(446, 275);
            btnAddClubToLeague.Name = "btnAddClubToLeague";
            btnAddClubToLeague.Size = new Size(157, 23);
            btnAddClubToLeague.TabIndex = 8;
            btnAddClubToLeague.Text = "Add To League";
            btnAddClubToLeague.UseVisualStyleBackColor = true;
            // 
            // btnRemoveClubFromLeague
            // 
            btnRemoveClubFromLeague.Location = new Point(609, 275);
            btnRemoveClubFromLeague.Name = "btnRemoveClubFromLeague";
            btnRemoveClubFromLeague.Size = new Size(157, 23);
            btnRemoveClubFromLeague.TabIndex = 9;
            btnRemoveClubFromLeague.Text = "Remove From League";
            btnRemoveClubFromLeague.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(690, 224);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(76, 23);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblLeagueName
            // 
            lblLeagueName.AutoSize = true;
            lblLeagueName.Location = new Point(484, 73);
            lblLeagueName.Name = "lblLeagueName";
            lblLeagueName.Size = new Size(83, 15);
            lblLeagueName.TabIndex = 11;
            lblLeagueName.Text = "League Name:";
            // 
            // lblSeason
            // 
            lblSeason.AutoSize = true;
            lblSeason.Location = new Point(629, 65);
            lblSeason.Name = "lblSeason";
            lblSeason.Size = new Size(47, 15);
            lblSeason.TabIndex = 12;
            lblSeason.Text = "Season:";
            // 
            // LeagueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSeason);
            Controls.Add(lblLeagueName);
            Controls.Add(btnRefresh);
            Controls.Add(btnRemoveClubFromLeague);
            Controls.Add(btnAddClubToLeague);
            Controls.Add(btnDeleteLeague);
            Controls.Add(btnEditLeague);
            Controls.Add(btnAddLeague);
            Controls.Add(txtSeason);
            Controls.Add(txtLeagueName);
            Controls.Add(cboAvailableClubs);
            Controls.Add(dgvParticipants);
            Controls.Add(dgvLeagues);
            Name = "LeagueForm";
            Text = "LeagueForm";
            ((System.ComponentModel.ISupportInitialize)dgvLeagues).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLeagues;
        private DataGridView dgvParticipants;
        private ComboBox cboAvailableClubs;
        private TextBox txtLeagueName;
        private TextBox txtSeason;
        private Button btnAddLeague;
        private Button btnEditLeague;
        private Button btnDeleteLeague;
        private Button btnAddClubToLeague;
        private Button btnRemoveClubFromLeague;
        private Button btnRefresh;
        private Label lblLeagueName;
        private Label lblSeason;
    }
}