using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                InitButton();
                UpdateLabels();
            }
        }

        private void InitButton()
        {
            btnDragInvisible.FlatStyle = FlatStyle.Flat;
            btnDragInvisible.FlatAppearance.BorderColor = BackColor;
            btnDragInvisible.FlatAppearance.MouseOverBackColor = BackColor;
            btnDragInvisible.FlatAppearance.MouseDownBackColor = BackColor;
        }

        private Color  BackgroundColor= Color.Gray;
        private Color ForeColor = Color.Gold;
        private bool dropSuccess;
        public Control controlThatStartedDnD;
        public Color InitColor = Color.Red;


        public FootballPlayerUserControl()
        {
            InitializeComponent();
            this.ContextMenuStrip = cms;
        }
        public FootballPlayerUserControl(Player player)
        {
            InitializeComponent();
            FootballPlayer = player;
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

       

        private void btnDragInvisible_MouseDown(object sender, MouseEventArgs e)
        {
            //btnDragInvisible.Show();
            //StartDnD(sender as Button);
          //  sender
            (sender as Button).DoDragDrop(this, DragDropEffects.Copy);


        }


        private void btnDragInvisible_DragDrop(object sender, DragEventArgs e)
        {
            
            Button btn = sender as Button;
            // // btn.BackColor = BackgroundColor;
            // btn.ForeColor = ForeColor;
            if(btn != null)
            btn.BackColor = Color.Purple;
           // button.ForeColor = Color.Black;

            dropSuccess = true;
        }

        private void btnDragInvisible_DragEnter(object sender, DragEventArgs e)
        {
           /* Button btn = sender as Button;
            btn.BackColor = Color.Green;

            if (btn == controlThatStartedDnD)
                return;


            e.Effect = DragDropEffects.Move;
            label4.Text = "Drop allowed";*/
           e.Effect = DragDropEffects.Move;
        }

        private void btnDragInvisible_DragLeave(object sender, EventArgs e)
        {
            label4.Text = "Drop not allowed";

        }

        private void btnDragInvisible_Click(object sender, EventArgs e)
        {
            // StartDnD(sender as Button);
            FootballPlayerUserControl fb = sender as FootballPlayerUserControl;
            fb.ContextMenuStrip = cms;
            fb.ContextMenuStrip.GetItemAt(0, 0).Enabled = false;
            fb.ContextMenuStrip.GetItemAt(2, 0).Enabled = false;
            fb.ContextMenuStrip.GetItemAt(1, 0).Enabled = true;

            fb.DoDragDrop(fb, DragDropEffects.Copy);

        }

        private void favoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unfavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
