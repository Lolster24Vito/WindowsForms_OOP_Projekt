using DAL.Models;
using DAL.REPO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_OOP_Projekt.Forms
{
    public partial class FootballPlayerUserControl : UserControl
    {
        private Player footballPlayer;
        public Player FootballPlayer
        {
            get
            {
                return footballPlayer;
            }
            set
            {
                footballPlayer = value;
                // InitButton();
                UpdateLabels();
                InitLoadImage();
                InitControlEvents();
            }
        }

        private void InitControlEvents()
        {
            foreach (Control item in this.Controls)
            {
                //item.do
                item.MouseDown += FootballPlayer_MouseDown;
                item.DragEnter += FootballPlayer_DragEnter;
                item.DragLeave += FootballPlayer_DragLeave;

            }
        }

        private Color  defaultBackgroundColor= Color.FromArgb(171,176,175);
        private Color selectedBackgroundColor = Color.FromArgb(134, 191, 180);

        private bool favorite;

        private const string USER_PICTURES_PATH = DAL.Constants.ApiConstants.USER_PICTURES_PATH;

        private OpenFileDialog ofd = new OpenFileDialog();

        private Image defaultImage = ImagesResources.profile_icon;

        public bool Favorite { 
            get => favorite;
            set {
                favorite = value;
                if (favorite)
                {
                    pictureBox1.Image = WindowsForms_OOP_Projekt.ImagesResources.star_filled;
                }
                else
                {
                    pictureBox1.Image = WindowsForms_OOP_Projekt.ImagesResources.star_unfilled;
                }
            }
        }

        public FootballPlayerUserControl()
        {
            InitializeComponent();
            this.ContextMenuStrip = cms;
            InitOpenFileDialog();
            InitControlEvents();

        }
        public FootballPlayerUserControl(Player player)
        {
            InitializeComponent();
            this.ContextMenuStrip = cms;
            FootballPlayer = player;
            InitOpenFileDialog();
             InitLoadImage();
            InitControlEvents();

        }

        public void InitLoadImage()
        {
            if(FootballPlayer!=null&& FootballPlayer.PicturePath!=null&&FootballPlayer.PicturePath!=""&& File.Exists(FootballPlayer.PicturePath))
            pictureBox2.ImageLocation = FootballPlayer.PicturePath;
            else
            {
                pictureBox2.Image = ImagesResources.profile_icon;
                
            }
        }

        private void UpdateLabels()
        {
            if (FootballPlayer != null)
            {

            lbIme.Text = FootballPlayer.Name;
            lbBroj.Text = FootballPlayer.ShirtNumber.ToString();
            lbPozicija.Text = FootballPlayer.Position.ToString();
                lbCountry.Text = FootballPlayer.CountryName;
            if (footballPlayer.Captain)
            {
                lbKapetan.Show();
            }
            else
            {
                lbKapetan.Hide();

            }
            }


        }



        private void FootballPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            //btnDragInvisible.Show();
            //StartDnD(sender as Button);
            //  sender


            FootballPlayerUserControl fb = sender as FootballPlayerUserControl;
            if (fb == null)
                fb = (sender as Control).Parent as FootballPlayerUserControl;

            MouseEventArgs me = (MouseEventArgs)e;
            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                SelectMultipleItems(fb);
            }
            else
            {

                if (me.Button == MouseButtons.Left)
                {
                    fb.DoDragDrop(fb, DragDropEffects.Copy);


                    DeselectFootballPlayers();
                }
            }
            if (me.Button == MouseButtons.Right)
            {

                //Point loc = (sender as Control).Location;
                //this.ContextMenuStrip.Show(new Point(loc.X- e.X , loc.Y - e.Y));  //.Show(this.ContextMenuStrip, new Point(me.X, me.Y));
                this.ContextMenuStrip.Show(fb, e.Location);
                if (Favorite)
                {
                    this.ContextMenuStrip.Items[0].Enabled = false;
                    this.ContextMenuStrip.Items[1].Enabled = true;
                    this.ContextMenuStrip.Items[2].Enabled = true;
                }
                else
                {
                    this.ContextMenuStrip.Items[0].Enabled = true;
                    this.ContextMenuStrip.Items[1].Enabled = false;
                    this.ContextMenuStrip.Items[2].Enabled = true;
                }


            }

            fb.DoDragDrop(this, DragDropEffects.Copy);


        }

        private void DeselectFootballPlayers()
        {
            MainForm main = this.ParentForm as MainForm;
            if (main != null)
            {
                main.DeselectMultipleFootballPlayers();
            }
        }

        private void SelectMultipleItems(FootballPlayerUserControl fb)
        {
            MainForm main = this.ParentForm as MainForm;
            if (main != null)
            {
                this.BorderStyle = BorderStyle.Fixed3D;
                main.SelectedMultipleFootballPlayerUserControl(fb);
            }
        }



        private void FootballPlayer_DragEnter(object sender, DragEventArgs e)
        {
          
           e.Effect = DragDropEffects.Move;
        }

        private void FootballPlayer_DragLeave(object sender, EventArgs e)
        {
            label4.Text = "Drop not allowed";

        }

        private void btnDragInvisible_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (me.Button == MouseButtons.Left)
            {

            // StartDnD(sender as Button);
            FootballPlayerUserControl fb = sender as FootballPlayerUserControl;
         //   fb.ContextMenuStrip = cms;
         //fb.ContextMenuStrip;


            fb.DoDragDrop(fb, DragDropEffects.Copy);
            }
            else if(me.Button == MouseButtons.Right)
            {
                
                this.ContextMenu.Show(this,new Point(me.X, me.Y));
            }

        }

        private void favoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm main = this.ParentForm as MainForm;
            if(main != null)
            {
                main.FavoriteFootballPlayer(this);
            }
        }

        private void unfavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Favorite = false;
            MainForm main = this.ParentForm as MainForm;
            if (main != null)
            {
                main.UnfavoriteFootballPlayer(this);
            }
        }
        public void RemoveFavoriteStar()
        {
            pictureBox1.Image = WindowsForms_OOP_Projekt.ImagesResources.star_unfilled;
        }

        private  void LoadImageToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //string fileLines = await FileRepo.ReadFromFile(USER_PICTURES_PATH);
            //settings = UserSettings.ParseFromString(fileLines);

            //LOAD PICTURE IF IT IS IN FILE

            //LOAD File 
            LoadPicturesFromFileDialogue();

        }
        private void LoadPicturesFromFileDialogue()
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {


                //ShowThumbnail(file);
                pictureBox2.ImageLocation = ofd.FileName;
                this.FootballPlayer.PicturePath = ofd.FileName;
                MainForm main = this.ParentForm as MainForm;
                if (main != null)
                {
                try
                {
                        main.SavePictureOfPlayer(this.FootballPlayer);
                }
                catch (Exception)
                {

                    throw;
                }
                    
                }
            }
            else
            {
                pictureBox2.Image = defaultImage;
                this.FootballPlayer.PicturePath = "";
                MainForm main = this.ParentForm as MainForm;
                if (main != null)
                {
                    main.RemoveImagesFrom(FootballPlayer);
                }
            }
        }

        private void InitOpenFileDialog()
        {
            ofd.Filter = "Pictures|*.jpeg;*.jpg;*.png;|All files|*.*";
            ofd.Multiselect = false;
            ofd.Title = "Load pictures...";
            ofd.InitialDirectory = Application.StartupPath;
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMultipleItems(this);
        }

        internal void ChangePicture(string picturePath)
        {
            pictureBox2.ImageLocation = picturePath;
            this.FootballPlayer.PicturePath = picturePath;
        }
    }
}
