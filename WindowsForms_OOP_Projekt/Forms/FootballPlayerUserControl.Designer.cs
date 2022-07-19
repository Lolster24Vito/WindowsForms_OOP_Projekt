namespace WindowsForms_OOP_Projekt.Forms
{
    partial class FootballPlayerUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FootballPlayerUserControl));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbKapetan = new System.Windows.Forms.Label();
            this.lbIme = new System.Windows.Forms.Label();
            this.lbBroj = new System.Windows.Forms.Label();
            this.lbPozicija = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.favoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unfavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lbKapetan
            // 
            resources.ApplyResources(this.lbKapetan, "lbKapetan");
            this.lbKapetan.Name = "lbKapetan";
            // 
            // lbIme
            // 
            resources.ApplyResources(this.lbIme, "lbIme");
            this.lbIme.Name = "lbIme";
            // 
            // lbBroj
            // 
            resources.ApplyResources(this.lbBroj, "lbBroj");
            this.lbBroj.Name = "lbBroj";
            // 
            // lbPozicija
            // 
            resources.ApplyResources(this.lbPozicija, "lbPozicija");
            this.lbPozicija.Name = "lbPozicija";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lbCountry
            // 
            resources.ApplyResources(this.lbCountry, "lbCountry");
            this.lbCountry.Name = "lbCountry";
            // 
            // cms
            // 
            resources.ApplyResources(this.cms, "cms");
            this.cms.AllowDrop = true;
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoriteToolStripMenuItem,
            this.unfavoriteToolStripMenuItem,
            this.LoadImageToolStripMenuItem,
            this.selectToolStripMenuItem});
            this.cms.Name = "cms";
            // 
            // favoriteToolStripMenuItem
            // 
            resources.ApplyResources(this.favoriteToolStripMenuItem, "favoriteToolStripMenuItem");
            this.favoriteToolStripMenuItem.Name = "favoriteToolStripMenuItem";
            this.favoriteToolStripMenuItem.Click += new System.EventHandler(this.favoriteToolStripMenuItem_Click);
            // 
            // unfavoriteToolStripMenuItem
            // 
            resources.ApplyResources(this.unfavoriteToolStripMenuItem, "unfavoriteToolStripMenuItem");
            this.unfavoriteToolStripMenuItem.Name = "unfavoriteToolStripMenuItem";
            this.unfavoriteToolStripMenuItem.Click += new System.EventHandler(this.unfavoriteToolStripMenuItem_Click);
            // 
            // LoadImageToolStripMenuItem
            // 
            resources.ApplyResources(this.LoadImageToolStripMenuItem, "LoadImageToolStripMenuItem");
            this.LoadImageToolStripMenuItem.Name = "LoadImageToolStripMenuItem";
            this.LoadImageToolStripMenuItem.Click += new System.EventHandler(this.LoadImageToolStripMenuItem_ClickAsync);
            // 
            // selectToolStripMenuItem
            // 
            resources.ApplyResources(this.selectToolStripMenuItem, "selectToolStripMenuItem");
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Image = global::WindowsForms_OOP_Projekt.ImagesResources.profile_icon;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::WindowsForms_OOP_Projekt.ImagesResources.star_unfilled;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // FootballPlayerUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.lbCountry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbPozicija);
            this.Controls.Add(this.lbBroj);
            this.Controls.Add(this.lbIme);
            this.Controls.Add(this.lbKapetan);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FootballPlayerUserControl";
            this.Click += new System.EventHandler(this.btnDragInvisible_Click);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FootballPlayer_DragEnter);
            this.DragLeave += new System.EventHandler(this.FootballPlayer_DragLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FootballPlayer_MouseDown);
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbKapetan;
        private System.Windows.Forms.Label lbIme;
        private System.Windows.Forms.Label lbBroj;
        private System.Windows.Forms.Label lbPozicija;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem favoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unfavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
    }
}
