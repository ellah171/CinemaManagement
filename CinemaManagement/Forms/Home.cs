using CinemaManagement.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CinemaManagement
{
    public partial class Home : Form
    {
        private List<string> localPhotoPaths = new List<string>
        {
            @"C:\Users\ella joy bodonia\OneDrive\Attachments\Pic\p1.jpg",
            @"C:\Users\ella joy bodonia\OneDrive\Attachments\Pic\p2.jpg",
            @"C:\Users\ella joy bodonia\OneDrive\Attachments\Pic\p1.jpg",
        };

        private int currentPosterIndex = 0;
        private string connString = "server=localhost;database=cinema_cms_db;user=root;password=;";

        public class MovieData
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string PosterPath { get; set; }
            public string Synopsis { get; set; }
        }

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadMoviesFromCMS();

            // Set to 10 Seconds (10000ms)
            timer1.Stop();
            timer1.Interval = 10000;
            timer1.Enabled = true;
            timer1.Start();

            // Force the picture to the background immediately
            guna2PictureBox2.SendToBack();

            ShowCurrentSlide();
        }

        private void LoadMoviesFromCMS()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try { conn.Open(); } catch {  }
            }
        }

        private void ShowCurrentSlide()
        {
            if (localPhotoPaths.Count > 0)
            {
                string currentPath = localPhotoPaths[currentPosterIndex];
                try
                {
                    if (guna2PictureBox2.Image != null) guna2PictureBox2.Image.Dispose();
                    if (File.Exists(currentPath))
                    {
                        guna2PictureBox2.Image = Image.FromFile(currentPath);
                    }

                    guna2PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                   
                    guna2PictureBox2.SendToBack();

                  
                    if (guna2GradientPanel2.Visible) guna2GradientPanel2.BringToFront();
                    if (guna2GradientPanel3.Visible) guna2GradientPanel3.BringToFront();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (timer1.Interval != 10000) timer1.Interval = 10000;

            if (localPhotoPaths.Count > 0)
            {
                currentPosterIndex = (currentPosterIndex + 1) % localPhotoPaths.Count;
                ShowCurrentSlide();
            }
        }

 

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            guna2GradientPanel2.Visible = true;
            guna2GradientPanel3.Visible = false;
            guna2GradientPanel2.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
            guna2GradientPanel2.Visible = false;
            guna2GradientPanel3.Visible = true;
            guna2GradientPanel3.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e) { F2 f2 = new F2("G"); f2.Show(); this.Hide(); }
        private void guna2Button3_Click(object sender, EventArgs e) { F2 f2 = new F2("PG"); f2.Show(); this.Hide(); }
        private void guna2Button4_Click(object sender, EventArgs e) { F2 f2 = new F2("PG-13"); f2.Show(); this.Hide(); }

      
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e) { }
        private void guna2HtmlLabel5_Click(object sender, EventArgs e) { }
        private void guna2Button5_Click(object sender, EventArgs e) { }
        private void guna2Button6_Click(object sender, EventArgs e) { guna2GradientPanel3.Visible = false; }
        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void guna2PictureBox2_Click_1(object sender, EventArgs e) { guna2PictureBox2_Click(sender, e); }
        private void txtSearch_TextChanged(object sender, EventArgs e) { }
        private void guna2Button3_Click_1(object sender, EventArgs e) { }
        private void guna2PictureBox2_Click_2(object sender, EventArgs e) { guna2PictureBox2_Click(sender, e); }
    }
}