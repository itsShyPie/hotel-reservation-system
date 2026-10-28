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
using System.Xml.Linq;

namespace Group71.Presentation
{
    public partial class BookingList : Form
    {
        private ReservationController reservationController;
        public BookingList()
        {
            InitializeComponent();
            reservationController = new ReservationController();
            LoadReservationList();
            bookingListView.SelectionChanged += bookingListView_SelectionChanged;
        }
        private void LoadReservationList()
        {
            // Retrieve the reservation data from the database
            DataTable reservations = reservationController.GetAllReservations();

            // Bind the data to the DataGridView
            bookingListView.DataSource = reservations;

        }
        private void bookingListView_SelectionChanged(object sender, EventArgs e)
        {
            if (bookingListView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = bookingListView.SelectedRows[0];

                // Populate text boxes with the selected guest's details
                txtGuestID.Text = selectedRow.Cells["guest_id"].Value.ToString();
                txtBookID.Text = selectedRow.Cells["reservation_id"].Value.ToString();
                
                txtNumGuest.Text = selectedRow.Cells["number_of_guests"].Value.ToString();
                txtResRef.Text = selectedRow.Cells["reservation_reference_number"].Value.ToString();
                txtDeposit.Text = selectedRow.Cells["deposit_amount"].Value.ToString();
                txtTotal.Text = selectedRow.Cells["total_amount"].Value.ToString();

                // Set the date of birth in the DateTimePicker
                dtpResDate.Value = Convert.ToDateTime(selectedRow.Cells["reservation_date"].Value);
                dtpCheckIn.Value = Convert.ToDateTime(selectedRow.Cells["check_in_date"].Value);
                dtpCheckOut.Value = Convert.ToDateTime(selectedRow.Cells["check_out_date"].Value);
            }
        }

        private void paymentLabel_Click(object sender, EventArgs e)
        {

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void BookingList_Load(object sender, EventArgs e)
        {

        }

        private void manageGuestToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void financialReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialReport financialReport = new FinancialReport();
            financialReport.Show();
            this.Hide();
        }

        private void financialOccupancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupanyReport occupancyReport = new OccupanyReport();
            occupancyReport.Show();
            this.Hide();
        }
        private void RefreshReservationList()
        {
            LoadReservationList();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBookID.Text))
            {
                string reservationID = txtBookID.Text;

                // Call the delete method from the controller
                bool isDeleted = reservationController.DeleteReservation(reservationID);

                if (isDeleted)
                {
                    MessageBox.Show("Reservation deleted successfully.");
                    RefreshReservationList();  // Refresh the list after deletion
                }
                else
                {
                    MessageBox.Show("Failed to delete the reservation. Please check the reservation ID.");
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservationList();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditReservation();
        }
        private void EditReservation()
        {
            // Gather input data
            string reservationID = txtBookID.Text.Trim(); // Reservation ID is needed for the update
            string guestId = txtGuestID.Text.Trim(); // Guest ID for the reservation

            // Ensure the reservation ID and guest ID are filled
            if (!string.IsNullOrEmpty(reservationID) && !string.IsNullOrEmpty(guestId))
            {
                DateTime reservationDate = dtpResDate.Value; // Reservation date from DateTimePicker
                DateTime checkInDate = dtpCheckIn.Value; // Check-in date from DateTimePicker
                DateTime checkOutDate = dtpCheckOut.Value; // Check-out date from DateTimePicker
                int numGuests = int.Parse(txtNumGuest.Text.Trim()); // Number of guests

                string reference = txtResRef.Text.Trim(); // Reservation reference number

                // Calculate deposit and total based on the check-in and check-out dates
                Rate rate = new Rate(550, 750, 995);
                decimal totalAmount = 0;

                // Calculate total amount based on the number of nights and the applicable rate
                for (DateTime date = checkInDate; date <= checkOutDate; date = date.AddDays(1))
                {
                    totalAmount += rate.GetRateForDate(date);
                }

                decimal depositAmount = totalAmount * 0.5M; // Assume deposit is 50% of the total

                // Update the reservation using the ReservationController without the status
                reservationController.UpdateReservation(
                    reservationID,
                    guestId,
                    reservationDate,
                    checkInDate,
                    checkOutDate,
                    numGuests,
                    depositAmount, // Include deposit amount
                    totalAmount,   // Include total amount
                    reference
                );

                // Refresh the reservation list to reflect the updated data
                LoadReservationList();
            }
            else
            {
                MessageBox.Show("Reservation ID and Guest ID are required for updating a reservation.");
            }
        }
    }
}
