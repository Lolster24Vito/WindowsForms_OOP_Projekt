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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbKapetan = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbIme = new System.Windows.Forms.Label();
            this.lbBroj = new System.Windows.Forms.Label();
            this.lbPozicija = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDragInvisible = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.favoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unfavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Broj:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pozicija:";
            // 
            // lbKapetan
            // 
            this.lbKapetan.AutoSize = true;
            this.lbKapetan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKapetan.Location = new System.Drawing.Point(74, 236);
            this.lbKapetan.Name = "lbKapetan";
            this.lbKapetan.Size = new System.Drawing.Size(62, 18);
            this.lbKapetan.TabIndex = 6;
            this.lbKapetan.Text = "Kapetan";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsForms_OOP_Projekt.ImagesResources.profile_icon;
            this.pictureBox2.Location = new System.Drawing.Point(77, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 89);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsForms_OOP_Projekt.ImagesResources.star_unfilled;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lbIme
            // 
            this.lbIme.AutoSize = true;
            this.lbIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIme.Location = new System.Drawing.Point(74, 109);
            this.lbIme.Name = "lbIme";
            this.lbIme.Size = new System.Drawing.Size(32, 18);
            this.lbIme.TabIndex = 7;
            this.lbIme.Text = "Ime";
            // 
            // lbBroj
            // 
            this.lbBroj.AutoSize = true;
            this.lbBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBroj.Location = new System.Drawing.Point(74, 141);
            this.lbBroj.Name = "lbBroj";
            this.lbBroj.Size = new System.Drawing.Size(16, 18);
            this.lbBroj.TabIndex = 8;
            this.lbBroj.Text = "1";
            // 
            // lbPozicija
            // 
            this.lbPozicija.AutoSize = true;
            this.lbPozicija.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPozicija.Location = new System.Drawing.Point(74, 173);
            this.lbPozicija.Name = "lbPozicija";
            this.lbPozicija.Size = new System.Drawing.Size(60, 18);
            this.lbPozicija.TabIndex = 9;
            this.lbPozicija.Text = "Pozicija";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "label4";
            // 
            // btnDragInvisible
            // 
            this.btnDragInvisible.BackColor = System.Drawing.Color.White;
            this.btnDragInvisible.Enabled = false;
            this.btnDragInvisible.Location = new System.Drawing.Point(0, 0);
            this.btnDragInvisible.Name = "btnDragInvisible";
            this.btnDragInvisible.Size = new System.Drawing.Size(239, 270);
            this.btnDragInvisible.TabIndex = 11;
            this.btnDragInvisible.UseVisualStyleBackColor = false;
            this.btnDragInvisible.Visible = false;
            this.btnDragInvisible.Click += new System.EventHandler(this.btnDragInvisible_Click);
            this.btnDragInvisible.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnDragInvisible_DragDrop);
            this.btnDragInvisible.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnDragInvisible_DragEnter);
            this.btnDragInvisible.DragLeave += new System.EventHandler(this.btnDragInvisible_DragLeave);
            this.btnDragInvisible.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDragInvisible_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Država:";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountry.Location = new System.Drawing.Point(74, 205);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(55, 18);
            this.lbCountry.TabIndex = 13;
            this.lbCountry.Text = "Država";
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoriteToolStripMenuItem,
            this.unfavoriteToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(148, 76);
            // 
            // favoriteToolStripMenuItem
            // 
            this.favoriteToolStripMenuItem.Name = "favoriteToolStripMenuItem";
            this.favoriteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.favoriteToolStripMenuItem.Text = "Favorite";
            this.favoriteToolStripMenuItem.Click += new System.EventHandler(this.favoriteToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.EditToolStripMenuItem.Text = "Edit";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // unfavoriteToolStripMenuItem
            // 
            this.unfavoriteToolStripMenuItem.Enabled = false;
            this.unfavoriteToolStripMenuItem.Name = "unfavoriteToolStripMenuItem";
            this.unfavoriteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.unfavoriteToolStripMenuItem.Text = "Unfavorite";
            this.unfavoriteToolStripMenuItem.Click += new System.EventHandler(this.unfavoriteToolStripMenuItem_Click);
            // 
            // FootballPlayerUserControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.lbCountry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbPozicija);
            this.Controls.Add(this.lbBroj);
            this.Controls.Add(this.lbIme);
            this.Controls.Add(this.lbKapetan);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDragInvisible);
            this.Name = "FootballPlayerUserControl";
            this.Size = new System.Drawing.Size(239, 270);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.btnDragInvisible_DragDrop);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cms.ResumeLayout(false);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDragInvisible;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem favoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unfavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
    }
}
