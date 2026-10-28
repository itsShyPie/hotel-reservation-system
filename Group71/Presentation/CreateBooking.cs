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
    public partial class CreateBooking : Form
    {
        private readonly RoomController roomController;
        private readonly ReservationController reservationController;
        public CreateBooking()
        {
            InitializeComponent();
            roomController = new RoomController();
            reservationController = new ReservationController();

            // Initialize the status combo box
            statusComboBox.Items.Add("Confirmed");
            statusComboBox.SelectedIndex = 0; // Default to "Confirmed"
        }
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }
        private decimal GetRoomRate(DateTime checkInDate)
        {
            decimal roomRate;

            // Determine the season based on the check-in date
            int month = checkInDate.Month;
            int day = checkInDate.Day;

            // Check for Low, Mid, and High seasons based on the defined ranges
            if (month == 12 && day >= 1 && day <= 7)
            {
                roomRate = 550; // Low Season
            }
            else if (month == 12 && day >= 8 && day <= 15)
            {
                roomRate = 750; // Mid Season
            }
            else if (month == 12 && day >= 16 && day <= 31)
            {
                roomRate = 995; // High Season
            }
            else
            {
                throw new Exception("Invalid check-in date for pricing.");
            }

            return roomRate;
        }
        private void CalculateTotalAmount()
        {
            try
            {
                // Get the input values
                DateTime checkInDate = checkInDateTimePicker.Value;
                DateTime checkOutDate = checkOutDateTimePicker.Value;
                int numberOfGuests = (int)numberOfGuestsNumericUpDown.Value;

                // Validate the dates
                if (checkInDate >= checkOutDate)
                {
                    MessageBox.Show("Check-out date must be after check-in date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate the number of nights
                int numberOfNights = (checkOutDate - checkInDate).Days;

                // Determine the season and calculate the room rate
                decimal roomRate = GetRoomRate(checkInDate);

                // Calculate total amount and deposit
                decimal totalAmount = roomRate * numberOfNights * numberOfGuests;
                decimal depositAmount = totalAmount * 0.10m; // 10% deposit

                // Display the results
                totalAmountTextBox.Text = totalAmount.ToString("F2");
                depositAmountTextBox.Text = depositAmount.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total amount: " + ex.Message);
            }
        }
        private string GenerateReservationReference()
        {
            // A simple way to generate a reservation reference using guest ID and current timestamp
            return "RES-" + guestIdTextBox.Text + "-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate the reservation reference
                string reservationReference = GenerateReservationReference();

                // Get input values
                string guestId = guestIdTextBox.Text.Trim();
                DateTime reservationDate = DateTime.Now;
                DateTime checkInDate = checkInDateTimePicker.Value.Date;
                DateTime checkOutDate = checkOutDateTimePicker.Value.Date;
                int numGuests = (int)numberOfGuestsNumericUpDown.Value;
                bool resStatus = statusComboBox.SelectedItem.ToString() == "Confirmed";
                decimal deposit = decimal.Parse(depositAmountTextBox.Text);
                decimal totalAmount = decimal.Parse(totalAmountTextBox.Text);

                // Generate a reservation ID (you may have a method for this)
                string reservationID = Guid.NewGuid().ToString();

                // Create the reservation
                reservationController.CreateReservation(
                    reservationID,
                    guestId,
                    reservationDate,
                    checkInDate,
                    checkOutDate,
                    numGuests,
                    resStatus,
                    deposit,
                    totalAmount,
                    reservationReference
                );

                reservationReferenceTextBox.Text = reservationReference;

                // Display success message
                MessageBox.Show($"Reservation created successfully! Your Reservation Reference is: {reservationReference}");

                // Optionally, clear the form fields after successful reservation
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating reservation: " + ex.Message);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            // Clear the TextBoxes
            guestIdTextBox.Clear();
            depositAmountTextBox.Clear();
            totalAmountTextBox.Clear();
            reservationReferenceTextBox.Clear();

            // Reset the DateTimePickers to today's date or their default
            checkInDateTimePicker.Value = DateTime.Now;
            checkOutDateTimePicker.Value = DateTime.Now;

            // Reset the NumericUpDown to default value (e.g., 1)
            numberOfGuestsNumericUpDown.Value = 1;

            // Reset the status ComboBox to the first item or default value
            statusComboBox.SelectedIndex = 0; // Assuming "Confirmed" is the first item
        }

        private void financialReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialReport financialReport = new FinancialReport();
            financialReport.Show();
            this.Hide();
        }

        private void occupanyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupanyReport occupancyReport = new OccupanyReport();
            occupancyReport.Show();
            this.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
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
