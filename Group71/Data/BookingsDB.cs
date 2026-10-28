using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Group71.Business;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace Group71.Data
{
    internal class BookingsDB
    {
        // Connection string for the database
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HotelReservationsDB.mdf;Integrated Security=True";

        // retrieves all bookings
        public DataTable GetAllBookings()
        {
            DataTable bookingsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reservation"; 
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(bookingsTable); // Fills the DataTable with results
            }

            return bookingsTable; // Return the DataTable containing booking records
        }

        
        //  adds a new booking
        public void AddBooking(string reservationID, string guestId, DateTime reservationDate, DateTime checkInDate, DateTime checkOutDate, int numGuest, bool resStatus, decimal guestDeposit, decimal guestTotal, string reference)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                string query = "INSERT INTO Reservation (reservation_id, guest_id, reservation_date, check_in_date, check_out_date, number_of_guests, status, deposit_amoun, total_amount, reservation_reference_number) " +
                                "VALUES (@Res_id, @Guest_id, @ResDate, @CheckIn,@CheckOut, @NumGuests,@Status, @Deposit, @Total, @Ref)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Res_id", guestId);
                command.Parameters.AddWithValue("@Guest_id", reservationID);
                command.Parameters.AddWithValue("@CheckIn", checkInDate);
                command.Parameters.AddWithValue("@CheckOut", checkOutDate);
                command.Parameters.AddWithValue("@NumGuests", numGuest);
                command.Parameters.AddWithValue("@Status", resStatus);
                command.Parameters.AddWithValue("@Deposit", guestDeposit);
                command.Parameters.AddWithValue("@Total", guestTotal);
                command.Parameters.AddWithValue("@Ref", reference);


                command.ExecuteNonQuery(); 
            }
        }
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

        //  updates an existing booking
        public bool UpdateBooking(string reservationID, string guestId, DateTime reservationDate, DateTime checkInDate, DateTime checkOutDate, int numGuest, decimal guestDeposit, decimal guestTotal, string reference)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Reservation SET guest_id = @GuestId, reservation_date = @ReservationDate, check_in_date = @CheckInDate, check_out_date = @CheckOutDate, number_of_guests = @NumGuests,  deposit_amount = @DepositAmount, total_amount = @TotalAmount, reservation_reference_number = @Reference WHERE reservation_id = @ReservationID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@ReservationID", reservationID);
                        command.Parameters.AddWithValue("@GuestId", guestId);
                        command.Parameters.AddWithValue("@ReservationDate", reservationDate);
                        command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                        command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                        command.Parameters.AddWithValue("@NumGuests", numGuest);

                        command.Parameters.AddWithValue("@DepositAmount", guestDeposit);
                        command.Parameters.AddWithValue("@TotalAmount", guestTotal);
                        command.Parameters.AddWithValue("@Reference", reference);

                        // Execute the query and check the number of affected rows
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reservation updated successfully.");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Please check if the Reservation ID is correct.");
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }


        public bool DeleteBooking(string reservationID)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Begin a transaction to ensure all deletions occur successfully
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // First, delete from the Payment table (if a foreign key exists)
                            string deleteFromPaymentQuery = "DELETE FROM Payment WHERE reservation_id = @reservationID";
                            using (SqlCommand cmd = new SqlCommand(deleteFromPaymentQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                                cmd.ExecuteNonQuery();
                            }

                            // Then, delete from the Reservation_Room table
                            string deleteFromReservationRoomQuery = "DELETE FROM Reservation_Room WHERE reservation_id = @reservationID";
                            using (SqlCommand cmd = new SqlCommand(deleteFromReservationRoomQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                                cmd.ExecuteNonQuery();
                            }

                            // Then, delete from the Reservation table
                            string deleteFromReservationQuery = "DELETE FROM Reservation WHERE reservation_id = @reservationID";
                            using (SqlCommand cmd = new SqlCommand(deleteFromReservationQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@reservationID", reservationID);
                                cmd.ExecuteNonQuery();
                            }

                            // Commit the transaction if all deletions are successful
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if something goes wrong
                            transaction.Rollback();
                            throw new Exception("Transaction failed: " + ex.Message);
                        }
                    }
                }
                return true; // Return true if the deletion is successful
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error deleting reservation: " + ex.Message);
                return false;
            }
        }
    }
}
