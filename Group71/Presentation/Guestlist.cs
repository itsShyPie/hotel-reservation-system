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
    public partial class Guestlist : Form
    {
        private GuestController guestController;
        public Guestlist()
        {
            InitializeComponent();
            guestController = new GuestController();
            LoadGuestList();
            guestListView.SelectionChanged += guestListView_SelectionChanged;
        }
        private void LoadGuestList()
        {
            // Retrieve the guest data from the database
            DataTable guests = guestController.GetAllGuests();

            // Bind the data to the DataGridView
            guestListView.DataSource = guests;
        }
        private void guestListView_SelectionChanged(object sender, EventArgs e)
        {
            if (guestListView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = guestListView.SelectedRows[0];

                // Populate text boxes with the selected guest's details
                txtGuestID.Text = selectedRow.Cells["guest_id"].Value.ToString();
                txtName.Text = selectedRow.Cells["first_name"].Value.ToString();
                txtLName.Text = selectedRow.Cells["last_name"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["address"].Value.ToString();
                txtCity.Text = selectedRow.Cells["city"].Value.ToString();
                txtPostalCode.Text = selectedRow.Cells["postal_code"].Value.ToString();
                txtPhone.Text = selectedRow.Cells["phone_number"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["email"].Value.ToString();

                // Set the date of birth in the DateTimePicker
                dtpDOB.Value = Convert.ToDateTime(selectedRow.Cells["date_of_birth"].Value);
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (guestListView.SelectedRows.Count > 0)
            {
                // Get the selected guest ID from the first cell of the selected row
                string selectedGuestId = guestListView.SelectedRows[0].Cells[0].Value.ToString(); // Adjust the index based on your DataGridView structure

                // Call the GuestController to delete the guest
                guestController.DeleteGuest(selectedGuestId);
            }
            else
            {
                // Optionally, show a message that no guest is selected
                MessageBox.Show("Please select a guest to delete.");
            }
            

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            //    // Get the updated values from the text boxes and DateTimePicker
            //    string guestId = txtGuestID.Text;
            //    string firstName = txtName.Text;
            //    string lastName = txtName.Text;
            //    string address = txtAddress.Text;
            //    string city = txtCity.Text;
            //    string postalCode = txtPostalCode.Text;
            //    string phone = txtPhone.Text;
            //    string email = txtEmail.Text;
            //    DateTime dob = dtpDOB.Value;  // Get date from DateTimePicker

            //    // Ensure no field is left blank (optional validation)
            //    if (string.IsNullOrEmpty(guestId) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            //    {
            //        MessageBox.Show("Please fill out all fields.");
            //        return;
            //    }

            //    guestController.UpdateGuest(
            //    guestId,
            //    txtCity.Text.Trim(),
            //    txtPostalCode.Text.Trim(),
            //    dob,
            //    txtName.Text.Trim(),
            //    txtLName.Text.Trim(),
            //    txtPhone.Text.Trim(),
            //    txtAddress.Text.Trim(),
            //    txtEmail.Text.Trim()

            //);
            DateTime dob = dtpDOB.Value;
            string guestId = txtGuestID.Text.Trim(); // Guest ID is needed for the update

            if (!string.IsNullOrEmpty(guestId)) // Ensure the Guest ID is filled
            {
                // Update the guest using the GuestController
                guestController.UpdateGuest(
                    guestId,
                    txtCity.Text.Trim(),
                    txtPostalCode.Text.Trim(),
                    dob,
                    txtName.Text.Trim(),
                    txtLName.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim(),
                    txtEmail.Text.Trim()
                );
            }
            else
            {
                MessageBox.Show("Guest ID is required for updating a guest.");
            }
        }

        private void guestListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void manageBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingList bookinglistForm = new BookingList();
            bookinglistForm.Show();
            this.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void createBookingToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void occupancyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupanyReport occupancyReport = new OccupanyReport();
            occupancyReport.Show();
            this.Hide();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialReport financialReport = new FinancialReport();
            financialReport.Show();
            this.Hide();

        }
    }
}
