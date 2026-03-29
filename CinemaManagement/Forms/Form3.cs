using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CinemaManagement.Forms
{
    public partial class Form3 : Form
    {
        private string selectedMoviePath;
        private string selectedVideoPath;
        private string selectedTime = "";
        private bool isTimeSelected = false;

        public Form3(string imagePath = "", string videoPath = "")
        {
            InitializeComponent();
            this.selectedMoviePath = imagePath;
            this.selectedVideoPath = videoPath;


            guna2Button1.Click += Showtime_Click;
            guna2Button2.Click += Showtime_Click;
            guna2Button3.Click += Showtime_Click;
            guna2Button4.Click += Showtime_Click;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedMoviePath) && File.Exists(selectedMoviePath))
            {
                Image movieImage = Image.FromFile(selectedMoviePath);
                guna2PictureBox2.Image = movieImage;
                guna2PictureBox3.Image = movieImage;

                guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                guna2PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            guna2Panel8.Visible = false;

            ToolTip toolTipTrailer = new ToolTip();
            toolTipTrailer.SetToolTip(btnPlay, "Preview Trailer");
        }


        private void Showtime_Click(object sender, EventArgs e)
        {
            Guna2Button clicked = (Guna2Button)sender;


            guna2Button1.FillColor = Color.FromArgb(30, 30, 30);
            guna2Button2.FillColor = Color.FromArgb(30, 30, 30);
            guna2Button3.FillColor = Color.FromArgb(30, 30, 30);
            guna2Button4.FillColor = Color.FromArgb(30, 30, 30);


            clicked.FillColor = Color.FromArgb(229, 9, 20);

            selectedTime = clicked.Text;
            isTimeSelected = true;
        }


        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (isTimeSelected)
            {
                Seat seat = new Seat();
                seat.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Please select a showtime before proceeding.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            F2 f2 = new F2();
            f2.Show();
            this.Hide();
        }


        private void btnPlay_Click_1(object sender, EventArgs e)
        {
            guna2Panel8.Visible = true;
            guna2Panel8.BringToFront();
            axWindowsMediaPlayer1.BringToFront();

            if (!string.IsNullOrEmpty(selectedVideoPath))
            {
                axWindowsMediaPlayer1.URL = selectedVideoPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            guna2Panel8.Visible = false;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none";
        }


        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }
        private void btnPlay_Click(object sender, EventArgs e) { }
        private void guna2PictureBox3_Click(object sender, EventArgs e) { }
        private void guna2PictureBox2_Click(object sender, EventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


    
