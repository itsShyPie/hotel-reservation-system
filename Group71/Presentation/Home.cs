using Group71.Business;
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
    public partial class Home : Form
    {
        private GuestController guestController;
        public Home()
        {
            InitializeComponent();
            guestController = new GuestController(); // Initialize GuestController
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {

        }

        private void addNewGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guestlist guestlistForm = new Guestlist();
            guestlistForm.Show();

            this.Hide();
        }

        private void manageBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingList bookinglistForm = new BookingList();
            bookinglistForm.Show();
            this.Hide();
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            NewGuest newGuestForm = new NewGuest();
            newGuestForm.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //GuestInfo guestInfo = new GuestInfo();
            //try
            //{
            //    string id = txtGuestID.Text.Trim(); // Get the Guest ID from the text box

            //    if (string.IsNullOrEmpty(id))
            //    {
            //        MessageBox.Show("Please enter a GuestID to search", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }

            //    DataRow personRow = guestController.SearchGuestById(id); // Call the SearchGuestById method

            //    if (personRow == null)
            //    {
            //        MessageBox.Show("Guest doesn't exist within our system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        // Populate the guest info form with data from the DataRow
            //        guestInfo.txtGuestID.Text = personRow["guest_id"].ToString();
            //        guestInfo.txtEmail.Text = personRow["email"].ToString();
            //        guestInfo.txtName.Text = personRow["first_name"].ToString() + " " + personRow["last_name"].ToString();
            //        guestInfo.txtTelephone.Text = personRow["phone"].ToString();
            //        guestInfo.txtAddress.Text = personRow["address"].ToString();

            //        // Hide current form and show GuestInfo form
            //        this.Hide();
            //        guestInfo.ShowDialog();
            //    }
            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show("Please make sure all fields are correctly filled in before continuing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            string guestId = txtGuestID.Text.Trim(); // Get the guest ID from the search textbox
            GuestController guestController = new GuestController();

            DataRow guest = guestController.SearchGuestById(guestId); // Search for the guest by ID

            if (guest != null)
            {
                // Guest found, open the guest info form and populate details
                GuestInfo guestInfoForm = new GuestInfo();

                // Set the guest info into the textboxes on the GuestInfoForm
                guestInfoForm.txtGuestID.Text = guest["guest_id"].ToString();
                guestInfoForm.txtName.Text = guest["first_name"].ToString();
                guestInfoForm.txtLname.Text = guest["last_name"].ToString();
                guestInfoForm.txtAddress.Text = guest["address"].ToString();
                guestInfoForm.txtTelephone.Text = guest["phone_number"].ToString();
                guestInfoForm.txtEmail.Text = guest["email"].ToString();

                // Set all textboxes to read-only
                //guestInfoForm.txtGuestID.ReadOnly = true;
                //guestInfoForm.txtName.ReadOnly = true;
                //guestInfoForm.txtLname.ReadOnly = true;
                //guestInfoForm.txtAddress.ReadOnly = true;
                //guestInfoForm.txtTelephone.ReadOnly = true;

                // Show the GuestInfoForm
                guestInfoForm.Show();
                this.Hide();
            }
            else
            {
                // Guest not found, show a message box
                MessageBox.Show("Guest not found. Please check the Guest ID and try again.", "Guest Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void financialReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialReport financialReport = new FinancialReport();
            financialReport.Show();
            this.Hide();
        }

        private void occupancyReportsToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
