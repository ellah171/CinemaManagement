using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CinemaManagement.Forms
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
            LoadCards();
        }

        private void LoadCards()
        {
            flowLayoutPanel1.Controls.Clear();

            var items = new[]
            {
                new { Name = "Popcorn", Price = 5.00 },
                new { Name = "Soda", Price = 3.00 },
                new { Name = "Nachos", Price = 6.50 },
                new { Name = "Candy", Price = 2.50 }
            };

            foreach (var item in items)
            {
                
            }
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Seat seat = new Seat();
            seat.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Check checkout = new Check();
            checkout.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}