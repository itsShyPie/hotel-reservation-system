using Group71.Business;
using Group71.Data;
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
    public partial class NewGuest : Form
    {
        private GuestController guestController;
        public NewGuest()
        {
            InitializeComponent();
            guestController = new GuestController();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            DateTime dob = dtpGuestDob.Value;
            //txtID.Text = Guest.GenerateGuestId();
            //string guestId = txtID.Text;
            // Call the AddGuest method in the controller
           guestController.AddGuest(

                
                txtName.Text.Trim(),
                txtLName.Text.Trim(),
                 txtAddress.Text.Trim(),
                 txtCity.Text.Trim(),
                txtPostalCode.Text.Trim(),
                txtPhone.Text.Trim(),

                txtEmail.Text.Trim(),
                dob               

                //txtID.Text.Trim()
                
            );;
            // Check if guestId is not null or empty
            //if (!string.IsNullOrEmpty(GuestController.guestId))
            //{
            //    txtID.Text = guestId; // Set the TextBox to show the generated guest ID
            //}
            //else
            //{
            //    MessageBox.Show("Error: Guest ID could not be generated.");
            //}
        }

        private void manageBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingList bookinglistForm = new BookingList();
            bookinglistForm.Show();
            this.Hide();
        }

        private void manageGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guestlist guestlistForm = new Guestlist();
            guestlistForm.Show();
            this.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            txtCity.Clear();
            txtPostalCode.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtLName.Clear();
            
            dtpGuestDob.Format = DateTimePickerFormat.Custom;
            dtpGuestDob.CustomFormat = " ";
        }

        private void financialReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialReport financialReport= new FinancialReport();
            financialReport.Show();
            this.Hide();
        }

        private void occupancyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupanyReport occupancyReport = new OccupanyReport();
            occupancyReport.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void NewGuest_Load(object sender, EventArgs e)
        {

        }
    }
}
