using CinemaManagement.Forms; 
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CinemaManagement
{
    public partial class F2 : Form
    {
        private string selectedAge;

        private List<string> testPhotos = new List<string>
        {
            @"C:\Users\ella joy bodonia\OneDrive\Attachments\Pic\p1.jpg",
            @"C:\Users\ella joy bodonia\OneDrive\Attachments\Pic\p2.jpg",
            @"C:\Users\ella joy bodonia\OneDrive\Attachments\Pic\p1.jpg",
            @"C:\Users\ella joy bodonia\OneDrive\Attachments\Pic\p2.jpg",
        };

        public F2(string ageCategory = "")
        {
            InitializeComponent();
            this.selectedAge = ageCategory;
        }

        private void F2_Load(object sender, EventArgs e)
        {
            // --- SCROLLING CONFIGURATION ---
            Mcon.AutoScroll = true;
            Mcon.FlowDirection = FlowDirection.LeftToRight;
            Mcon.WrapContents = true;

            Mcon.HorizontalScroll.Maximum = 0;
            Mcon.HorizontalScroll.Enabled = false;
            Mcon.HorizontalScroll.Visible = false;

            Mcon.Visible = true;
            Mcon.BringToFront();

            DisplayMovies("");
        }

        private void DisplayMovies(string filterText)
        {
            Mcon.Controls.Clear();
            filterText = filterText.ToLower().Trim();

            foreach (string photoPath in testPhotos)
            {
                string fileName = Path.GetFileName(photoPath).ToLower();

                if (string.IsNullOrEmpty(filterText) || fileName.Contains(filterText))
                {
                    Guna.UI2.WinForms.Guna2PictureBox pic = new Guna.UI2.WinForms.Guna2PictureBox();

                    pic.Size = new Size(500, 370);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.BorderRadius = 15;
                    pic.Cursor = Cursors.Hand;
                    pic.Margin = new Padding(20);
                    pic.BackColor = Color.FromArgb(45, 45, 45);

                    if (File.Exists(photoPath))
                    {
                        using (FileStream fs = new FileStream(photoPath, FileMode.Open, FileAccess.Read))
                        {
                            pic.Image = Image.FromStream(fs);
                        }
                    }

                    // --- ADDED: Store the FULL PATH so Form3 can find the image ---
                    pic.Tag = photoPath;

                    pic.Click += MoviePoster_Click;

                    Mcon.Controls.Add(pic);
                }
            }
        }

        private void MoviePoster_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2PictureBox clickedPic = (Guna.UI2.WinForms.Guna2PictureBox)sender;
            string fullImagePath = clickedPic.Tag.ToString();

         
            string trailerPath = @"C:\Users\ella joy bodonia\OneDrive\Attachments\Videos for EP\KALINAW.mp4";

    
            if (!System.IO.File.Exists(trailerPath))
            {
                MessageBox.Show("ERROR: System cannot find the video file at:\n" + trailerPath);
            }

         
            CinemaManagement.Forms.Form3 details = new CinemaManagement.Forms.Form3(fullImagePath, trailerPath);
            details.Show();
            this.Hide();
        }

           
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayMovies(txtSearch.Text);
        }

        // --- KEYBOARD & NAVIGATION HANDLERS (ALL PRESERVED) ---

        private void Alphabet_C(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = (Guna.UI2.WinForms.Guna2Button)sender;
            txtSearch.Text += btn.Text;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            Mcon.Visible = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void guna2Button37_Click(object sender, EventArgs e)
        {
            txtSearch.Text += " ";
        }

        private void guna2Button35_Click(object sender, EventArgs e)
        {
            Keyboard.Visible = false;
        }

        private void guna2Button34_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                txtSearch.Text = txtSearch.Text.Substring(0, txtSearch.Text.Length - 1);
            }
        }

        private void guna2Button36_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Keyboard.Visible = true;
            txtSearch.Visible = true;
            Keyboard.BringToFront();
            txtSearch.Focus();
        }

        
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Button3_Click(object sender, EventArgs e) { }
        private void guna2Button3_Click_1(object sender, EventArgs e) { }
        private void Mcon_Paint(object sender, PaintEventArgs e) { }
    }
}