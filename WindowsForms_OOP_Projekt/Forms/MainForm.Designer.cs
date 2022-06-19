namespace WindowsForms_OOP_Projekt
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
            this.components = new System.ComponentModel.Container();
            this.tabControlPlayers = new System.Windows.Forms.TabControl();
            this.tabPageTeams = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.cbTeams = new System.Windows.Forms.ComboBox();
            this.tabPagePlayers = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllTeamPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.favoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageRankPlayers = new System.Windows.Forms.TabPage();
            this.tabPageRankTournament = new System.Windows.Forms.TabPage();
            this.flpPlayerRank = new System.Windows.Forms.FlowLayoutPanel();
            this.listBoxPlayerRank = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControlPlayers.SuspendLayout();
            this.tabPageTeams.SuspendLayout();
            this.tabPagePlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.tabPageRankPlayers.SuspendLayout();
            this.flpPlayerRank.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPlayers
            // 
            this.tabControlPlayers.Controls.Add(this.tabPageTeams);
            this.tabControlPlayers.Controls.Add(this.tabPagePlayers);
            this.tabControlPlayers.Controls.Add(this.tabPageRankPlayers);
            this.tabControlPlayers.Controls.Add(this.tabPageRankTournament);
            this.tabControlPlayers.Location = new System.Drawing.Point(3, 6);
            this.tabControlPlayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlPlayers.Name = "tabControlPlayers";
            this.tabControlPlayers.SelectedIndex = 0;
            this.tabControlPlayers.Size = new System.Drawing.Size(947, 692);
            this.tabControlPlayers.TabIndex = 0;
            // 
            // tabPageTeams
            // 
            this.tabPageTeams.Controls.Add(this.label2);
            this.tabPageTeams.Controls.Add(this.label1);
            this.tabPageTeams.Controls.Add(this.btnSettings);
            this.tabPageTeams.Controls.Add(this.cbTeams);
            this.tabPageTeams.Location = new System.Drawing.Point(4, 25);
            this.tabPageTeams.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTeams.Name = "tabPageTeams";
            this.tabPageTeams.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTeams.Size = new System.Drawing.Size(939, 663);
            this.tabPageTeams.TabIndex = 0;
            this.tabPageTeams.Text = "Teams";
            this.tabPageTeams.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(173, 338);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(285, 95);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "Lokalizacija i  tip utakmica";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // cbTeams
            // 
            this.cbTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTeams.FormattingEnabled = true;
            this.cbTeams.Location = new System.Drawing.Point(135, 112);
            this.cbTeams.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTeams.Name = "cbTeams";
            this.cbTeams.Size = new System.Drawing.Size(323, 30);
            this.cbTeams.TabIndex = 0;
            this.cbTeams.Text = "---Select---";
            this.cbTeams.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPagePlayers
            // 
            this.tabPagePlayers.Controls.Add(this.splitContainer1);
            this.tabPagePlayers.Location = new System.Drawing.Point(4, 25);
            this.tabPagePlayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePlayers.Name = "tabPagePlayers";
            this.tabPagePlayers.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePlayers.Size = new System.Drawing.Size(939, 663);
            this.tabPagePlayers.TabIndex = 1;
            this.tabPagePlayers.Text = "Players";
            this.tabPagePlayers.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flpFavoritePlayers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flpAllTeamPlayers);
            this.splitContainer1.Size = new System.Drawing.Size(933, 659);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 0;
            // 
            // flpFavoritePlayers
            // 
            this.flpFavoritePlayers.AllowDrop = true;
            this.flpFavoritePlayers.AutoScroll = true;
            this.flpFavoritePlayers.AutoSize = true;
            this.flpFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpFavoritePlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFavoritePlayers.Location = new System.Drawing.Point(0, 0);
            this.flpFavoritePlayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            this.flpFavoritePlayers.Size = new System.Drawing.Size(933, 230);
            this.flpFavoritePlayers.TabIndex = 1;
            this.flpFavoritePlayers.WrapContents = false;
            this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
            this.flpFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragEnter);
            // 
            // flpAllTeamPlayers
            // 
            this.flpAllTeamPlayers.AutoScroll = true;
            this.flpAllTeamPlayers.AutoSize = true;
            this.flpAllTeamPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpAllTeamPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAllTeamPlayers.Location = new System.Drawing.Point(0, 0);
            this.flpAllTeamPlayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpAllTeamPlayers.Name = "flpAllTeamPlayers";
            this.flpAllTeamPlayers.Size = new System.Drawing.Size(933, 425);
            this.flpAllTeamPlayers.TabIndex = 0;
            this.flpAllTeamPlayers.WrapContents = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoriteToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeFavoriteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(188, 76);
            // 
            // favoriteToolStripMenuItem
            // 
            this.favoriteToolStripMenuItem.Name = "favoriteToolStripMenuItem";
            this.favoriteToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.favoriteToolStripMenuItem.Text = "Favorite";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // removeFavoriteToolStripMenuItem
            // 
            this.removeFavoriteToolStripMenuItem.Name = "removeFavoriteToolStripMenuItem";
            this.removeFavoriteToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.removeFavoriteToolStripMenuItem.Text = "Remove favorite";
            // 
            // tabPageRankPlayers
            // 
            this.tabPageRankPlayers.Controls.Add(this.button2);
            this.tabPageRankPlayers.Controls.Add(this.button1);
            this.tabPageRankPlayers.Controls.Add(this.flpPlayerRank);
            this.tabPageRankPlayers.Location = new System.Drawing.Point(4, 25);
            this.tabPageRankPlayers.Name = "tabPageRankPlayers";
            this.tabPageRankPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRankPlayers.Size = new System.Drawing.Size(939, 663);
            this.tabPageRankPlayers.TabIndex = 2;
            this.tabPageRankPlayers.Text = "Players rank";
            this.tabPageRankPlayers.UseVisualStyleBackColor = true;
            // 
            // tabPageRankTournament
            // 
            this.tabPageRankTournament.Location = new System.Drawing.Point(4, 25);
            this.tabPageRankTournament.Name = "tabPageRankTournament";
            this.tabPageRankTournament.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRankTournament.Size = new System.Drawing.Size(939, 663);
            this.tabPageRankTournament.TabIndex = 3;
            this.tabPageRankTournament.Text = "Tournament rank";
            this.tabPageRankTournament.UseVisualStyleBackColor = true;
            // 
            // flpPlayerRank
            // 
            this.flpPlayerRank.Controls.Add(this.listBoxPlayerRank);
            this.flpPlayerRank.Location = new System.Drawing.Point(0, 91);
            this.flpPlayerRank.Name = "flpPlayerRank";
            this.flpPlayerRank.Size = new System.Drawing.Size(939, 569);
            this.flpPlayerRank.TabIndex = 0;
            // 
            // listBoxPlayerRank
            // 
            this.listBoxPlayerRank.FormattingEnabled = true;
            this.listBoxPlayerRank.ItemHeight = 16;
            this.listBoxPlayerRank.Location = new System.Drawing.Point(3, 3);
            this.listBoxPlayerRank.Name = "listBoxPlayerRank";
            this.listBoxPlayerRank.Size = new System.Drawing.Size(927, 564);
            this.listBoxPlayerRank.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(258, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 65);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 710);
            this.Controls.Add(this.tabControlPlayers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabControlPlayers.ResumeLayout(false);
            this.tabPageTeams.ResumeLayout(false);
            this.tabPageTeams.PerformLayout();
            this.tabPagePlayers.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.tabPageRankPlayers.ResumeLayout(false);
            this.flpPlayerRank.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPlayers;
        private System.Windows.Forms.TabPage tabPageTeams;
        private System.Windows.Forms.ComboBox cbTeams;
        private System.Windows.Forms.TabPage tabPagePlayers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flpAllTeamPlayers;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem favoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFavoriteToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageRankPlayers;
        private System.Windows.Forms.TabPage tabPageRankTournament;
        private System.Windows.Forms.FlowLayoutPanel flpPlayerRank;
        private System.Windows.Forms.ListBox listBoxPlayerRank;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

