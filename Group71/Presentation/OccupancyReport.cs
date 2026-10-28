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
    public partial class OccupanyReport : Form
    {
        private ReservationController reservationController;
        private GuestController guestController;

        public OccupanyReport()
        {
            InitializeComponent();
            reservationController = new ReservationController();  // Initialize ReservationController
            guestController = new GuestController();  // Initialize GuestController
        }

        // Event handler for the "Generate" button
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Generate the occupancy report for the selected date range
            GenerateOccupancyReport(occupancy_start_datetimepicker.Value, occupancy_end_datetimepicker.Value);
        }

        private string GetRoomNumberByReservationId(string reservationId)
        {
            try
            {
                // Get the reservation details
                DataRow reservationRow = reservationController.GetReservationById(reservationId);

                if (reservationRow != null)
                {
                    // Check if room_id exists in the reservation data
                    if (reservationRow.Table.Columns.Contains("room_id"))
                    {
                        string roomId = reservationRow["room_id"].ToString();

                        // Get room details using RoomController
                        RoomController roomController = new RoomController();
                        DataTable roomData = roomController.GetRoomById(roomId);

                        if (roomData.Rows.Count > 0)
                        {
                            // Assuming room_number is a column in the Room table
                            return roomData.Rows[0]["room_number"].ToString();
                        }
                        else
                        {
                            return "Unknown Room";
                        }
                    }
                    else
                    {
                        return "Room ID not found in reservation.";
                    }
                }
                else
                {
                    return "Reservation not found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving room number: " + ex.Message);
                return "Error";
            }
        }


        public void GenerateOccupancyReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                txtOccupancyRpt.Clear();
                txtOccupancyRpt.AppendText($"Date Range: {startDate.ToShortDateString()} - {endDate.ToShortDateString()}");
                txtOccupancyRpt.AppendText(Environment.NewLine + "--------------------------------------------------------------");
                txtOccupancyRpt.AppendText(Environment.NewLine + "Room Number\tGuest Name\t\tBooking Period");

                // Fetch reservations
                DataTable reservations = reservationController.GetAllReservations();

                // Check for reservations
                if (reservations == null || reservations.Rows.Count == 0)
                {
                    throw new InvalidOperationException("No reservations found for the given date range.");
                }

                foreach (DataRow reservationRow in reservations.Rows)
                {
                    DateTime checkInDate = DateTime.Parse(reservationRow["check_in_date"].ToString());
                    DateTime checkOutDate = DateTime.Parse(reservationRow["check_out_date"].ToString());

                    // Check if the reservation falls within the specified date range
                    if (checkInDate <= endDate && checkOutDate >= startDate)
                    {
                        // Retrieve guest details using GuestController
                        string guestId = reservationRow["guest_id"].ToString();
                        DataRow guestRow = guestController.SearchGuestById(guestId);

                        if (guestRow != null)
                        {
                            string guestName = $"{guestRow["first_name"]} {guestRow["last_name"]}";
                            string bookingPeriod = $"{checkInDate.ToShortDateString()} - {checkOutDate.ToShortDateString()}";
                            string reservationId = reservationRow["reservation_id"].ToString();

                            // Get room number
                            string roomNumber = GetRoomNumberByReservationId(reservationId);

                            // Append details to the report textbox
                            txtOccupancyRpt.AppendText(Environment.NewLine + $"{roomNumber}\t\t{guestName}\t\t{bookingPeriod}");
                        }
                        else
                        {
                            txtOccupancyRpt.AppendText(Environment.NewLine + "Guest details not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
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

        private void financialReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinancialReport financialReport = new FinancialReport();
            financialReport.Show();
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
