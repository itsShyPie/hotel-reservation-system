using Group71.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    internal class ReservationController
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HotelReservationsDB.mdf;Integrated Security=True;Connect Timeout=30";
        private BookingsDB bookingsDB;

        #region Constructor
        public ReservationController()
        {
            bookingsDB = new BookingsDB();
        }

        #endregion
        #region Methods
        public DataRow GetReservationById(string reservationId)
        {
            DataTable reservationTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reservation WHERE reservation_id = @ReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", reservationId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(reservationTable);
            }

            if (reservationTable.Rows.Count > 0)
            {
                return reservationTable.Rows[0];
            }
            else
            {
                return null;
            }
        }
        //  gets all reservations
        public DataTable GetAllReservations()
        {
            return bookingsDB.GetAllBookings();
        }
        // creates a new reservation
        public void CreateReservation(string reservationID, string guestId, DateTime reservationDate, DateTime checkInDate, DateTime checkOutDate, int numGuests, bool resStatus, decimal deposit, decimal totalAmount, string reference)
        {
            try
            {
                // Create a new Reservation object
                Reservation newReservation = new Reservation(
                    reservationID,
                    guestId,
                    reservationDate,
                    checkInDate,
                    checkOutDate,
                    numGuests,
                    resStatus,
                    deposit,
                    totalAmount,
                    reference
                );

                // Add reservation to the database
                bookingsDB.AddBooking(
                    reservationID,
                    guestId,
                    reservationDate,
                    checkInDate,
                    checkOutDate,
                    numGuests,
                    resStatus,
                    deposit,
                    totalAmount,
                    reference
                );
            }
            catch (Exception ex)
            {
                // Handle errors
                Console.WriteLine("Error creating reservation: " + ex.Message);
                throw; // Re-throw the exception to be handled by the calling method
            }
        }
        //  updates an existing reservation
        public void UpdateReservation(string reservationID, string guestId, DateTime reservationDate, DateTime checkInDate, DateTime checkOutDate, int numGuests, decimal deposit, decimal totalAmount, string reference)
        {
            try
            {
                // Calculate deposit and total based on the check-in and check-out dates
                Rate rate = new Rate(550, 750, 995);
                decimal totalCost = 0;

                for (DateTime date = checkInDate; date <= checkOutDate; date = date.AddDays(1))
                {
                    totalCost += rate.GetRateForDate(date);
                }

                decimal depositAmount = totalCost * 0.5M; // Assume deposit is 50% of the total

                // Call the updated method with deposit and total passed as arguments
                bookingsDB.UpdateBooking(reservationID, guestId, reservationDate, checkInDate, checkOutDate, numGuests, depositAmount, totalAmount, reference);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating reservation: " + ex.Message);
            }
        }
        // deletes a reservation
        public bool DeleteReservation(string reservationID)
        {

            return bookingsDB.DeleteBooking(reservationID);
        }






        #endregion
    }
}
