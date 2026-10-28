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
    internal class RoomController
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HotelReservationsDB.mdf;Integrated Security=True;Connect Timeout=30";
        private RoomDB roomDB;

        #region Constructor
        public RoomController()
        {
            roomDB = new RoomDB();
        }
        #endregion

        #region Methods
        public DataTable GetAllRooms()
        {
            return roomDB.GetAllRooms(); // Call the RoomDB to get all room data
        }
        public DataTable CheckRoomAvailability(DateTime startDate, DateTime endDate)
        {
            return roomDB.GetAvailableRooms(startDate, endDate);
        }
        public DataTable GetRoomById(string roomId)
        {
            DataTable roomTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Room WHERE room_id = @RoomID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(roomTable);
            }

            return roomTable;
        }

        #endregion
    }
}
