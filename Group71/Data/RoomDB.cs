using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Group71.Business;


namespace Group71.Data
{
    internal class RoomDB
    {
        // Connection string for the database
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HotelReservationsDB.mdf;Integrated Security=True";

        // Method to retrieve all rooms
        public DataTable GetAllRooms()
        {
            DataTable roomsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Room"; // Assuming the table is named 'Rooms'
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(roomsTable); // Fills the DataTable with results
            }

            return roomsTable; // Return the DataTable containing room records
        }

        public DataTable GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            DataTable availableRoomsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Room r WHERE Status = 'Available' AND NOT EXISTS " +
                                 "(   SELECT 1 FROM Reservation res " +
                                 "   WHERE res.RoomID = r.RoomID    AND ((res.StartDate <= @EndDate AND res.EndDate >= @StartDate))";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(availableRoomsTable);
            }

            return availableRoomsTable;
        }


    }
}
