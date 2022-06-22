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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.tabPageRankPlayers = new System.Windows.Forms.TabPage();
            this.flpPlayerRank = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrintPlayers = new System.Windows.Forms.Button();
            this.btnPreviewPlayers = new System.Windows.Forms.Button();
            this.playersDataGridView = new System.Windows.Forms.DataGridView();
            this.PlayerPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfGoals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfYellowCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfRedCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageRankTournament = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrintMatches = new System.Windows.Forms.Button();
            this.btnPreviewMatches = new System.Windows.Forms.Button();
            this.MatchesDataGridView = new System.Windows.Forms.DataGridView();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.home_teamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.away_teamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfVisitors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.tabControlPlayers.SuspendLayout();
            this.tabPageTeams.SuspendLayout();
            this.tabPagePlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPageRankPlayers.SuspendLayout();
            this.flpPlayerRank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            this.tabPageRankTournament.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchesDataGridView)).BeginInit();
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
            this.flpFavoritePlayers.Click += new System.EventHandler(this.flpFavoritePlayers_Click);
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
            this.flpAllTeamPlayers.Click += new System.EventHandler(this.flpFavoritePlayers_Click);
            // 
            // tabPageRankPlayers
            // 
            this.tabPageRankPlayers.Controls.Add(this.flpPlayerRank);
            this.tabPageRankPlayers.Location = new System.Drawing.Point(4, 25);
            this.tabPageRankPlayers.Name = "tabPageRankPlayers";
            this.tabPageRankPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRankPlayers.Size = new System.Drawing.Size(939, 663);
            this.tabPageRankPlayers.TabIndex = 2;
            this.tabPageRankPlayers.Text = "Players rank";
            this.tabPageRankPlayers.UseVisualStyleBackColor = true;
            // 
            // flpPlayerRank
            // 
            this.flpPlayerRank.Controls.Add(this.btnPrintPlayers);
            this.flpPlayerRank.Controls.Add(this.btnPreviewPlayers);
            this.flpPlayerRank.Controls.Add(this.playersDataGridView);
            this.flpPlayerRank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPlayerRank.Location = new System.Drawing.Point(3, 3);
            this.flpPlayerRank.Name = "flpPlayerRank";
            this.flpPlayerRank.Size = new System.Drawing.Size(933, 657);
            this.flpPlayerRank.TabIndex = 0;
            // 
            // btnPrintPlayers
            // 
            this.btnPrintPlayers.Location = new System.Drawing.Point(3, 3);
            this.btnPrintPlayers.Name = "btnPrintPlayers";
            this.btnPrintPlayers.Size = new System.Drawing.Size(201, 67);
            this.btnPrintPlayers.TabIndex = 2;
            this.btnPrintPlayers.Text = "Print";
            this.btnPrintPlayers.UseVisualStyleBackColor = true;
            this.btnPrintPlayers.Click += new System.EventHandler(this.btnPrintPlayers_Click);
            // 
            // btnPreviewPlayers
            // 
            this.btnPreviewPlayers.Location = new System.Drawing.Point(210, 3);
            this.btnPreviewPlayers.Name = "btnPreviewPlayers";
            this.btnPreviewPlayers.Size = new System.Drawing.Size(185, 67);
            this.btnPreviewPlayers.TabIndex = 3;
            this.btnPreviewPlayers.Text = "Preview";
            this.btnPreviewPlayers.UseVisualStyleBackColor = true;
            this.btnPreviewPlayers.Click += new System.EventHandler(this.btnPreviewPlayers_Click);
            // 
            // playersDataGridView
            // 
            this.playersDataGridView.AllowUserToAddRows = false;
            this.playersDataGridView.AllowUserToDeleteRows = false;
            this.playersDataGridView.AllowUserToOrderColumns = true;
            this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerPicture,
            this.PlayerName,
            this.NumberOfGoals,
            this.NumberOfYellowCards,
            this.NumberOfRedCards});
            this.playersDataGridView.Location = new System.Drawing.Point(3, 76);
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.ReadOnly = true;
            this.playersDataGridView.RowHeadersWidth = 51;
            this.playersDataGridView.RowTemplate.Height = 24;
            this.playersDataGridView.Size = new System.Drawing.Size(927, 584);
            this.playersDataGridView.TabIndex = 1;
            // 
            // PlayerPicture
            // 
            this.PlayerPicture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PlayerPicture.HeaderText = "Image";
            this.PlayerPicture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.PlayerPicture.MinimumWidth = 6;
            this.PlayerPicture.Name = "PlayerPicture";
            this.PlayerPicture.ReadOnly = true;
            // 
            // PlayerName
            // 
            this.PlayerName.DataPropertyName = "Name";
            this.PlayerName.HeaderText = "Name";
            this.PlayerName.MinimumWidth = 6;
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            this.PlayerName.Width = 125;
            // 
            // NumberOfGoals
            // 
            this.NumberOfGoals.DataPropertyName = "NumberOfGoals";
            this.NumberOfGoals.HeaderText = "NumberOfGoals";
            this.NumberOfGoals.MinimumWidth = 6;
            this.NumberOfGoals.Name = "NumberOfGoals";
            this.NumberOfGoals.ReadOnly = true;
            this.NumberOfGoals.Width = 125;
            // 
            // NumberOfYellowCards
            // 
            this.NumberOfYellowCards.DataPropertyName = "NumberOfYellowCards";
            this.NumberOfYellowCards.HeaderText = "NumberOfYellowCards";
            this.NumberOfYellowCards.MinimumWidth = 6;
            this.NumberOfYellowCards.Name = "NumberOfYellowCards";
            this.NumberOfYellowCards.ReadOnly = true;
            this.NumberOfYellowCards.Width = 125;
            // 
            // NumberOfRedCards
            // 
            this.NumberOfRedCards.DataPropertyName = "NumberOfRedCards";
            this.NumberOfRedCards.HeaderText = "NumberOfRedCards";
            this.NumberOfRedCards.MinimumWidth = 6;
            this.NumberOfRedCards.Name = "NumberOfRedCards";
            this.NumberOfRedCards.ReadOnly = true;
            this.NumberOfRedCards.Width = 125;
            // 
            // tabPageRankTournament
            // 
            this.tabPageRankTournament.Controls.Add(this.flowLayoutPanel1);
            this.tabPageRankTournament.Location = new System.Drawing.Point(4, 25);
            this.tabPageRankTournament.Name = "tabPageRankTournament";
            this.tabPageRankTournament.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRankTournament.Size = new System.Drawing.Size(939, 663);
            this.tabPageRankTournament.TabIndex = 3;
            this.tabPageRankTournament.Text = "Tournament rank";
            this.tabPageRankTournament.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPrintMatches);
            this.flowLayoutPanel1.Controls.Add(this.btnPreviewMatches);
            this.flowLayoutPanel1.Controls.Add(this.MatchesDataGridView);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(933, 657);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnPrintMatches
            // 
            this.btnPrintMatches.Location = new System.Drawing.Point(3, 3);
            this.btnPrintMatches.Name = "btnPrintMatches";
            this.btnPrintMatches.Size = new System.Drawing.Size(175, 68);
            this.btnPrintMatches.TabIndex = 1;
            this.btnPrintMatches.Text = "Print";
            this.btnPrintMatches.UseVisualStyleBackColor = true;
            this.btnPrintMatches.Click += new System.EventHandler(this.btnPrintMatches_Click);
            // 
            // btnPreviewMatches
            // 
            this.btnPreviewMatches.Location = new System.Drawing.Point(184, 3);
            this.btnPreviewMatches.Name = "btnPreviewMatches";
            this.btnPreviewMatches.Size = new System.Drawing.Size(175, 68);
            this.btnPreviewMatches.TabIndex = 2;
            this.btnPreviewMatches.Text = "Preview";
            this.btnPreviewMatches.UseVisualStyleBackColor = true;
            this.btnPreviewMatches.Click += new System.EventHandler(this.btnPreviewMatches_Click);
            // 
            // MatchesDataGridView
            // 
            this.MatchesDataGridView.AllowUserToAddRows = false;
            this.MatchesDataGridView.AllowUserToDeleteRows = false;
            this.MatchesDataGridView.AllowUserToOrderColumns = true;
            this.MatchesDataGridView.AllowUserToResizeColumns = false;
            this.MatchesDataGridView.AllowUserToResizeRows = false;
            this.MatchesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatchesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Location,
            this.home_teamColumn,
            this.away_teamColumn,
            this.numberOfVisitors});
            this.MatchesDataGridView.Location = new System.Drawing.Point(3, 77);
            this.MatchesDataGridView.Name = "MatchesDataGridView";
            this.MatchesDataGridView.RowHeadersWidth = 51;
            this.MatchesDataGridView.RowTemplate.Height = 24;
            this.MatchesDataGridView.Size = new System.Drawing.Size(930, 583);
            this.MatchesDataGridView.TabIndex = 0;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 125;
            // 
            // home_teamColumn
            // 
            this.home_teamColumn.HeaderText = "Home team";
            this.home_teamColumn.MinimumWidth = 6;
            this.home_teamColumn.Name = "home_teamColumn";
            this.home_teamColumn.ReadOnly = true;
            this.home_teamColumn.Width = 125;
            // 
            // away_teamColumn
            // 
            this.away_teamColumn.HeaderText = "Away team";
            this.away_teamColumn.MinimumWidth = 6;
            this.away_teamColumn.Name = "away_teamColumn";
            this.away_teamColumn.ReadOnly = true;
            this.away_teamColumn.Width = 125;
            // 
            // numberOfVisitors
            // 
            this.numberOfVisitors.HeaderText = "Number of visitors";
            this.numberOfVisitors.MinimumWidth = 6;
            this.numberOfVisitors.Name = "numberOfVisitors";
            this.numberOfVisitors.ReadOnly = true;
            this.numberOfVisitors.Width = 125;
            // 
            // printDocument
            // 
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
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
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Click += new System.EventHandler(this.flpFavoritePlayers_Click);
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
            this.tabPageRankPlayers.ResumeLayout(false);
            this.flpPlayerRank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
            this.tabPageRankTournament.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MatchesDataGridView)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageRankPlayers;
        private System.Windows.Forms.TabPage tabPageRankTournament;
        private System.Windows.Forms.FlowLayoutPanel flpPlayerRank;
        private System.Windows.Forms.DataGridView playersDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn PlayerPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfGoals;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfYellowCards;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfRedCards;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView MatchesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn home_teamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn away_teamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfVisitors;
        private System.Windows.Forms.Button btnPrintPlayers;
        private System.Windows.Forms.Button btnPreviewPlayers;
        private System.Windows.Forms.Button btnPrintMatches;
        private System.Windows.Forms.Button btnPreviewMatches;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}

