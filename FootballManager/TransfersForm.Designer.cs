namespace FootballManager
{
    partial class TransfersForm : Form
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
            dgvTransfers = new DataGridView();
            cboPlayer = new ComboBox();
            cboToClub = new ComboBox();
            txtFromClub = new TextBox();
            dtpTransferDate = new DateTimePicker();
            numFee = new NumericUpDown();
            txtNote = new TextBox();
            btnTransfer = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            cboPlayerFilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvTransfers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFee).BeginInit();
            SuspendLayout();
            // 
            // dgvTransfers
            // 
            dgvTransfers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransfers.Location = new Point(370, 20);
            dgvTransfers.Name = "dgvTransfers";
            dgvTransfers.Size = new Size(400, 380);
            dgvTransfers.TabIndex = 0;
            // 
            // cboPlayer
            // 
            cboPlayer.FormattingEnabled = true;
            cboPlayer.Location = new Point(30, 30);
            cboPlayer.Name = "cboPlayer";
            cboPlayer.Size = new Size(150, 23);
            cboPlayer.TabIndex = 1;
            cboPlayer.Click += cboPlayer_SelectedIndexChanged;
            // 
            // cboToClub
            // 
            cboToClub.FormattingEnabled = true;
            cboToClub.Location = new Point(200, 80);
            cboToClub.Name = "cboToClub";
            cboToClub.Size = new Size(150, 23);
            cboToClub.TabIndex = 4;
            // 
            // txtFromClub
            // 
            txtFromClub.Location = new Point(30, 80);
            txtFromClub.Name = "txtFromClub";
            txtFromClub.ReadOnly = true;
            txtFromClub.Size = new Size(150, 23);
            txtFromClub.TabIndex = 3;
            // 
            // dtpTransferDate
            // 
            dtpTransferDate.Location = new Point(30, 130);
            dtpTransferDate.Name = "dtpTransferDate";
            dtpTransferDate.Size = new Size(200, 23);
            dtpTransferDate.TabIndex = 5;
            // 
            // numFee
            // 
            numFee.Location = new Point(30, 180);
            numFee.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numFee.Name = "numFee";
            numFee.Size = new Size(120, 23);
            numFee.TabIndex = 6;
            // 
            // txtNote
            // 
            txtNote.Location = new Point(30, 230);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(320, 23);
            txtNote.TabIndex = 7;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(30, 280);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(100, 35);
            btnTransfer.TabIndex = 8;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(140, 280);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(250, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 35);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // cboPlayerFilter
            // 
            cboPlayerFilter.FormattingEnabled = true;
            cboPlayerFilter.Location = new Point(200, 30);
            cboPlayerFilter.Name = "cboPlayerFilter";
            cboPlayerFilter.Size = new Size(150, 23);
            cboPlayerFilter.TabIndex = 2;
            cboPlayerFilter.Click += cboPlayerFilter_SelectedIndexChanged;
            // 
            // TransfersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 430);
            Controls.Add(dgvTransfers);
            Controls.Add(cboPlayer);
            Controls.Add(cboPlayerFilter);
            Controls.Add(txtFromClub);
            Controls.Add(cboToClub);
            Controls.Add(dtpTransferDate);
            Controls.Add(numFee);
            Controls.Add(txtNote);
            Controls.Add(btnTransfer);
            Controls.Add(btnRefresh);
            Controls.Add(btnClear);
            Name = "TransfersForm";
            Text = "TransfersForm";
            ((System.ComponentModel.ISupportInitialize)dgvTransfers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTransfers;
        private ComboBox cboPlayer;
        private ComboBox cboToClub;
        private TextBox txtFromClub;
        private DateTimePicker dtpTransferDate;
        private NumericUpDown numFee;
        private TextBox txtNote;
        private Button btnTransfer;
        private Button btnRefresh;
        private Button btnClear;
        private ComboBox cboPlayerFilter;
    }
}