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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpAllTeamPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControlPlayers = new System.Windows.Forms.TabControl();
            this.tabPageTeams = new System.Windows.Forms.TabPage();
            this.btnSettings = new System.Windows.Forms.Button();
            this.cbTeams = new System.Windows.Forms.ComboBox();
            this.tabPagePlayers = new System.Windows.Forms.TabPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlPlayers.SuspendLayout();
            this.tabPageTeams.SuspendLayout();
            this.tabPagePlayers.SuspendLayout();
            this.tabPageRankPlayers.SuspendLayout();
            this.flpPlayerRank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            this.tabPageRankTournament.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.flpFavoritePlayers);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.flpAllTeamPlayers);
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(this.flpFavoritePlayers, "flpFavoritePlayers");
            this.flpFavoritePlayers.AllowDrop = true;
            this.flpFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            this.flpFavoritePlayers.Click += new System.EventHandler(this.flpFavoritePlayers_Click);
            this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
            this.flpFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragEnter);
            // 
            // flpAllTeamPlayers
            // 
            resources.ApplyResources(this.flpAllTeamPlayers, "flpAllTeamPlayers");
            this.flpAllTeamPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpAllTeamPlayers.Name = "flpAllTeamPlayers";
            this.flpAllTeamPlayers.Click += new System.EventHandler(this.flpFavoritePlayers_Click);
            // 
            // tabControlPlayers
            // 
            resources.ApplyResources(this.tabControlPlayers, "tabControlPlayers");
            this.tabControlPlayers.Controls.Add(this.tabPageTeams);
            this.tabControlPlayers.Controls.Add(this.tabPagePlayers);
            this.tabControlPlayers.Controls.Add(this.tabPageRankPlayers);
            this.tabControlPlayers.Controls.Add(this.tabPageRankTournament);
            this.tabControlPlayers.Name = "tabControlPlayers";
            this.tabControlPlayers.SelectedIndex = 0;
            // 
            // tabPageTeams
            // 
            resources.ApplyResources(this.tabPageTeams, "tabPageTeams");
            this.tabPageTeams.Controls.Add(this.btnSettings);
            this.tabPageTeams.Controls.Add(this.cbTeams);
            this.tabPageTeams.Name = "tabPageTeams";
            this.tabPageTeams.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // cbTeams
            // 
            resources.ApplyResources(this.cbTeams, "cbTeams");
            this.cbTeams.FormattingEnabled = true;
            this.cbTeams.Name = "cbTeams";
            this.cbTeams.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPagePlayers
            // 
            resources.ApplyResources(this.tabPagePlayers, "tabPagePlayers");
            this.tabPagePlayers.Controls.Add(this.splitContainer1);
            this.tabPagePlayers.Name = "tabPagePlayers";
            this.tabPagePlayers.UseVisualStyleBackColor = true;
            // 
            // tabPageRankPlayers
            // 
            resources.ApplyResources(this.tabPageRankPlayers, "tabPageRankPlayers");
            this.tabPageRankPlayers.Controls.Add(this.flpPlayerRank);
            this.tabPageRankPlayers.Name = "tabPageRankPlayers";
            this.tabPageRankPlayers.UseVisualStyleBackColor = true;
            // 
            // flpPlayerRank
            // 
            resources.ApplyResources(this.flpPlayerRank, "flpPlayerRank");
            this.flpPlayerRank.Controls.Add(this.btnPrintPlayers);
            this.flpPlayerRank.Controls.Add(this.btnPreviewPlayers);
            this.flpPlayerRank.Controls.Add(this.playersDataGridView);
            this.flpPlayerRank.Name = "flpPlayerRank";
            // 
            // btnPrintPlayers
            // 
            resources.ApplyResources(this.btnPrintPlayers, "btnPrintPlayers");
            this.btnPrintPlayers.Name = "btnPrintPlayers";
            this.btnPrintPlayers.UseVisualStyleBackColor = true;
            this.btnPrintPlayers.Click += new System.EventHandler(this.btnPrintPlayers_Click);
            // 
            // btnPreviewPlayers
            // 
            resources.ApplyResources(this.btnPreviewPlayers, "btnPreviewPlayers");
            this.btnPreviewPlayers.Name = "btnPreviewPlayers";
            this.btnPreviewPlayers.UseVisualStyleBackColor = true;
            this.btnPreviewPlayers.Click += new System.EventHandler(this.btnPreviewPlayers_Click);
            // 
            // playersDataGridView
            // 
            resources.ApplyResources(this.playersDataGridView, "playersDataGridView");
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
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.ReadOnly = true;
            this.playersDataGridView.RowTemplate.Height = 24;
            // 
            // PlayerPicture
            // 
            this.PlayerPicture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.PlayerPicture, "PlayerPicture");
            this.PlayerPicture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.PlayerPicture.Name = "PlayerPicture";
            this.PlayerPicture.ReadOnly = true;
            // 
            // PlayerName
            // 
            this.PlayerName.DataPropertyName = "Name";
            resources.ApplyResources(this.PlayerName, "PlayerName");
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // NumberOfGoals
            // 
            this.NumberOfGoals.DataPropertyName = "NumberOfGoals";
            resources.ApplyResources(this.NumberOfGoals, "NumberOfGoals");
            this.NumberOfGoals.Name = "NumberOfGoals";
            this.NumberOfGoals.ReadOnly = true;
            // 
            // NumberOfYellowCards
            // 
            this.NumberOfYellowCards.DataPropertyName = "NumberOfYellowCards";
            resources.ApplyResources(this.NumberOfYellowCards, "NumberOfYellowCards");
            this.NumberOfYellowCards.Name = "NumberOfYellowCards";
            this.NumberOfYellowCards.ReadOnly = true;
            // 
            // NumberOfRedCards
            // 
            this.NumberOfRedCards.DataPropertyName = "NumberOfRedCards";
            resources.ApplyResources(this.NumberOfRedCards, "NumberOfRedCards");
            this.NumberOfRedCards.Name = "NumberOfRedCards";
            this.NumberOfRedCards.ReadOnly = true;
            // 
            // tabPageRankTournament
            // 
            resources.ApplyResources(this.tabPageRankTournament, "tabPageRankTournament");
            this.tabPageRankTournament.Controls.Add(this.flowLayoutPanel1);
            this.tabPageRankTournament.Name = "tabPageRankTournament";
            this.tabPageRankTournament.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.btnPrintMatches);
            this.flowLayoutPanel1.Controls.Add(this.btnPreviewMatches);
            this.flowLayoutPanel1.Controls.Add(this.MatchesDataGridView);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // btnPrintMatches
            // 
            resources.ApplyResources(this.btnPrintMatches, "btnPrintMatches");
            this.btnPrintMatches.Name = "btnPrintMatches";
            this.btnPrintMatches.UseVisualStyleBackColor = true;
            this.btnPrintMatches.Click += new System.EventHandler(this.btnPrintMatches_Click);
            // 
            // btnPreviewMatches
            // 
            resources.ApplyResources(this.btnPreviewMatches, "btnPreviewMatches");
            this.btnPreviewMatches.Name = "btnPreviewMatches";
            this.btnPreviewMatches.UseVisualStyleBackColor = true;
            this.btnPreviewMatches.Click += new System.EventHandler(this.btnPreviewMatches_Click);
            // 
            // MatchesDataGridView
            // 
            resources.ApplyResources(this.MatchesDataGridView, "MatchesDataGridView");
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
            this.MatchesDataGridView.Name = "MatchesDataGridView";
            this.MatchesDataGridView.RowTemplate.Height = 24;
            // 
            // Location
            // 
            resources.ApplyResources(this.Location, "Location");
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // home_teamColumn
            // 
            resources.ApplyResources(this.home_teamColumn, "home_teamColumn");
            this.home_teamColumn.Name = "home_teamColumn";
            this.home_teamColumn.ReadOnly = true;
            // 
            // away_teamColumn
            // 
            resources.ApplyResources(this.away_teamColumn, "away_teamColumn");
            this.away_teamColumn.Name = "away_teamColumn";
            this.away_teamColumn.ReadOnly = true;
            // 
            // numberOfVisitors
            // 
            resources.ApplyResources(this.numberOfVisitors, "numberOfVisitors");
            this.numberOfVisitors.Name = "numberOfVisitors";
            this.numberOfVisitors.ReadOnly = true;
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
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlPlayers);
            this.Name = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Click += new System.EventHandler(this.flpFavoritePlayers_Click);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlPlayers.ResumeLayout(false);
            this.tabPageTeams.ResumeLayout(false);
            this.tabPagePlayers.ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
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

