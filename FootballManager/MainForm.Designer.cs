namespace FootballManager
{
    partial class MainForm
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
            btnClubs = new Button();
            btnPlayers = new Button();
            btnTransfers = new Button();
            btnLeagues = new Button();
            SuspendLayout();
            // 
            // btnClubs
            // 
            btnClubs.Location = new Point(12, 11);
            btnClubs.Name = "btnClubs";
            btnClubs.Size = new Size(247, 91);
            btnClubs.TabIndex = 0;
            btnClubs.Text = "Clubs";
            btnClubs.UseVisualStyleBackColor = true;
            // 
            // btnPlayers
            // 
            btnPlayers.Location = new Point(12, 108);
            btnPlayers.Name = "btnPlayers";
            btnPlayers.Size = new Size(247, 98);
            btnPlayers.TabIndex = 1;
            btnPlayers.Text = "Players";
            btnPlayers.UseVisualStyleBackColor = true;
            // 
            // btnTransfers
            // 
            btnTransfers.Location = new Point(12, 212);
            btnTransfers.Name = "btnTransfers";
            btnTransfers.Size = new Size(247, 99);
            btnTransfers.TabIndex = 2;
            btnTransfers.Text = "Transfers";
            btnTransfers.UseVisualStyleBackColor = true;
            // 
            // btnLeagues
            // 
            btnLeagues.Location = new Point(12, 317);
            btnLeagues.Name = "btnLeagues";
            btnLeagues.Size = new Size(247, 96);
            btnLeagues.TabIndex = 3;
            btnLeagues.Text = "Leagues";
            btnLeagues.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 426);
            Controls.Add(btnLeagues);
            Controls.Add(btnTransfers);
            Controls.Add(btnPlayers);
            Controls.Add(btnClubs);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnClubs;
        private Button btnPlayers;
        private Button btnTransfers;
        private Button btnLeagues;
    }
}