using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Group71.Business;
using System.Windows.Forms;
using System.Diagnostics;

namespace Group71.Data
{
    public class GuestDB
    {
        
        
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HotelReservationsDB.mdf;Integrated Security=True";

        #region Utility Methods 
        // retrieves all guests
        public DataTable GetAllGuests()
        {
            DataTable guestsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Guest"; 
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(guestsTable); // Fills the DataTable with results
            }

            return guestsTable; // Returns the DataTable containing guest records
        }
        
        public void AddGuest(string firstName, string lastName, string address, string city, string postalCode, string phone, string email, DateTime dob)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL Insert query
                    string query = "INSERT INTO Guest (first_name, last_name, address, city, postal_code, phone_number, email, date_of_birth) " +
                                   "VALUES ( @FName, @LName, @Address, @City, @PostalCode, @Phone, @Email, @Dob)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL query
                        //command.Parameters.Add(new SqlParameter("@GuestId", SqlDbType.VarChar) { Value = guestId });
                        command.Parameters.Add(new SqlParameter("@FName", SqlDbType.VarChar) { Value = firstName });
                        command.Parameters.Add(new SqlParameter("@LName", SqlDbType.VarChar) { Value = lastName });
                        command.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar) { Value = address });
                        command.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar) { Value = city });
                        command.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.VarChar) { Value = postalCode });
                        command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.VarChar) { Value = phone });
                        command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar) { Value = email });
                        command.Parameters.Add(new SqlParameter("@Dob", SqlDbType.DateTime) { Value = dob });

                        // Execute the command to insert the new guest
                        int rowsAffected = command.ExecuteNonQuery();

                        // Notify the user of the result
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Guest added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Error: No rows were inserted.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void UpdateGuest(string guestId, string city, string postalCode, DateTime dob, string firstName, string lastName, string phone, string address, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Guest SET first_name = @FName, last_name = @L_Name, address = @Address, city = @City, postal_code = @PostalCode, phone_number = @Phone, email = @Email, date_of_birth = @Dob WHERE guest_id = @GuestId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@GuestId", guestId);
                        command.Parameters.AddWithValue("@FName", firstName);
                        command.Parameters.AddWithValue("@L_Name", lastName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@PostalCode", postalCode);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Dob", dob);

                        // Execute the query and check the number of affected rows
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Guest updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Please check if the Guest ID is correct.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public void DeleteGuest(string guestId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction(); // Begin transaction

                try
                {
                    int affectedRows = 0; // Track affected rows

                    // Step 1: Delete related records in Payment table
                    string deletePaymentQuery = "DELETE FROM Payment WHERE reservation_id IN (SELECT reservation_id FROM Reservation WHERE guest_id = @GuestId)";
                    using (SqlCommand command = new SqlCommand(deletePaymentQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@GuestId", guestId);
                        affectedRows += command.ExecuteNonQuery(); // Add the number of affected rows
                    }

                    // Step 2: Delete related records in Reservation_Room table
                    string deleteRoomQuery = "DELETE FROM Reservation_Room WHERE reservation_id IN (SELECT reservation_id FROM Reservation WHERE guest_id = @GuestId)";
                    using (SqlCommand command = new SqlCommand(deleteRoomQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@GuestId", guestId);
                        affectedRows += command.ExecuteNonQuery(); // Add the number of affected rows
                    }

                    // Step 3: Delete related records in Reservation table
                    string deleteReservationQuery = "DELETE FROM Reservation WHERE guest_id = @GuestId";
                    using (SqlCommand command = new SqlCommand(deleteReservationQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@GuestId", guestId);
                        affectedRows += command.ExecuteNonQuery(); // Add the number of affected rows
                    }

                    // Step 4: Finally, delete the guest
                    string deleteGuestQuery = "DELETE FROM Guest WHERE guest_id = @GuestId";
                    using (SqlCommand command = new SqlCommand(deleteGuestQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@GuestId", guestId);
                        affectedRows += command.ExecuteNonQuery(); // Add the number of affected rows
                    }

                    // Commit transaction if everything is successful
                    transaction.Commit();

                    // Check if any rows were affected
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Guest and related records successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No records were deleted. Please check if the Guest ID is correct.", "No Deletions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Rollback transaction if there's an error
                    transaction.Rollback();
                    MessageBox.Show("An error occurred while deleting the guest: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public DataRow SearchGuestById(string guestId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Guest WHERE guest_id = @GuestId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GuestId", guestId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable guestTable = new DataTable();

                connection.Open();
                adapter.Fill(guestTable);

                // If the guest is found, return the DataRow
                if (guestTable.Rows.Count > 0)
                {
                    return guestTable.Rows[0]; // return the found guest's DataRow
                }
            }
            return null; // return null if guest not found
        }

        #endregion
    }
}
