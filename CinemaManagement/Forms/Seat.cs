using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace CinemaManagement.Forms
{
    public partial class Seat : Form
    {
        
        public static List<string> SelectedSeats { get; private set; } = new List<string>();

     
        private Color colorAvailable;
        private Color colorOccupied;
        private Color colorReserved;

        public Seat()
        {
            InitializeComponent();
            this.Load += Seat_Load;
            SelectedSeats.Clear(); 
        }

        private void Seat_Load(object sender, EventArgs e)
        {
           
            colorAvailable = guna2Button43.FillColor;
            colorOccupied = guna2Button44.FillColor;
            colorReserved = guna2Button45.FillColor;

            
            for (int i = 2; i <= 42; i++)
            {
             
                Control[] found = guna2Panel3.Controls.Find("guna2Button" + i, true);

                if (found.Length > 0 && found[0] is Guna2Button btn)
                {
                  
                    btn.HoverState.FillColor = Color.Empty;
                    btn.Click += SeatButton_Click;
                }
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn)
            {
               
                if (SelectedSeats.Contains(btn.Text))
                {
                    SelectedSeats.Remove(btn.Text);
                    btn.FillColor = colorAvailable; // Back to Grey
                }
                else if (btn.FillColor == colorOccupied)
                {
                    MessageBox.Show("This seat is already occupied!", "Occupied");
                }
                else
                {
                    SelectedSeats.Add(btn.Text);
                    btn.FillColor = colorReserved; 
                }
            }
        }

      

        private void guna2Button51_Click(object sender, EventArgs e) 
        {
            if (SelectedSeats.Count == 0)
            {
                MessageBox.Show("Please select at least one seat before proceeding.");
                return;
            }

            Add addons = new Add();
            addons.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e) 
        {
            
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

      
        private void guna2PictureBox1_Click(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2HtmlLabel8_Click(object sender, EventArgs e) { }
        private void guna2HtmlLabel3_Click(object sender, EventArgs e) { }
        private void guna2Panel7_Paint(object sender, PaintEventArgs e) { }
    }
}