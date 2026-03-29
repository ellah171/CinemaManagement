using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace CinemaManagement.Forms
{
    public partial class Check : Form
    {
       
        private Guna2Panel successPanel;
        private List<string> selectedAddons;

        public Check(List<string> addons = null)
        {
            InitializeComponent();
            selectedAddons = addons;

            CreateSuccessPanel();
            LoadAddonsToFlowPanel();

            exitTimer.Interval = 5000;
            exitTimer.Tick += ExitTimer_Tick;
        }

        private void CreateSuccessPanel()
        {
            successPanel = new Guna2Panel();
            successPanel.Size = new Size(350, 180);
            successPanel.FillColor = Color.FromArgb(30, 30, 30);
            successPanel.BorderRadius = 20;
            successPanel.Visible = false;

            Label lblStatus = new Label();
            lblStatus.Text = "PAYMENT SUCCESSFUL!\n\nReturning to Home in 5 seconds...";
            lblStatus.ForeColor = Color.LimeGreen;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            successPanel.Controls.Add(lblStatus);
            this.Controls.Add(successPanel);
            successPanel.BringToFront();

            successPanel.Location = new Point(
                (this.ClientSize.Width - successPanel.Width) / 2,
                (this.ClientSize.Height - successPanel.Height) / 2
            );
        }

        private void LoadAddonsToFlowPanel()
        {
            
            if (flowLayoutPanel2 == null) return;

            flowLayoutPanel2.Controls.Clear();

            if (selectedAddons != null && selectedAddons.Count > 0)
            {
                foreach (var item in selectedAddons)
                {
                    Label itemLabel = new Label();
                    itemLabel.Text = "• " + item;
                    itemLabel.AutoSize = true;
                    itemLabel.ForeColor = Color.White; // Set color so it's visible
                    itemLabel.Font = new Font("Segoe UI", 10);
                    itemLabel.Margin = new Padding(3);
                    flowLayoutPanel2.Controls.Add(itemLabel);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            successPanel.Visible = true;
            exitTimer.Start();
        }

        private void ExitTimer_Tick(object sender, EventArgs e)
        {
            exitTimer.Stop();
            // Ensure you have a form named 'Home'
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Add addons = new Add();
            addons.Show();
            this.Hide();
        }

        // Handlers left empty as requested
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel5_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel5_Paint_1(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e) { }
    }
}