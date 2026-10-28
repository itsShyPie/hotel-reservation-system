using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group71.Presentation
{
    public partial class GuestInfo : Form
    {
        public GuestInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();

        }

        private void manageGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guestlist guestlistForm = new Guestlist();
            guestlistForm.Show();

            this.Hide();

        }

        private void financialReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialReport financialReport = new FinancialReport();
            financialReport.Show();
            this.Hide();
        }

        private void occupancyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupanyReport occupancyReport = new OccupanyReport();
            occupancyReport.Show();
            this.Hide();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

            // Show a confirmation dialog
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Close the application
            }
            // If No is selected, do nothing and the application stays open
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            BookingList bookinglistForm = new BookingList();
            bookinglistForm.Show();
            this.Hide();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateBooking newBookingForm = new CreateBooking();
            newBookingForm.Show();
            this.Hide();

        }
    }
}
