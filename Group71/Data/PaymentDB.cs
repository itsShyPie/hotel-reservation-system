using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group71.Data
{
    public class PaymentDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\HotelReservationsDB.mdf;Integrated Security=True";

        // Retrieve all payments
        public DataTable GetAllPayments()
        {
            DataTable paymentsTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Payment";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(paymentsTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving payments: " + ex.Message);
            }

            return paymentsTable;
        }

        // Retrieve payments within a date range
        public DataTable GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            DataTable paymentsTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Payment WHERE payment_date BETWEEN @StartDate AND @EndDate";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(paymentsTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving payments by date range: " + ex.Message);
            }

            return paymentsTable;
        }
    }
}
