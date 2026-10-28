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
    public partial class FinancialReport : Form
    {
        private PaymentController paymentController;
        public FinancialReport()
        {
            InitializeComponent();
            paymentController = new PaymentController();
            LoadAllPayments();
        }
        // Load all payments on form initialization
        private void LoadAllPayments()
        {
            try
            {
                DataTable payments = paymentController.GetAllPayments();
                paymentsDataGridView.DataSource = payments;
                DisplayTotalRevenue(payments);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message);
            }
        }
        // Display total revenue based on the provided payments DataTable
        private void DisplayTotalRevenue(DataTable payments)
        {
            decimal totalRevenue = paymentController.CalculateTotalRevenue(payments);
            lblTotalRevenue.Text = $"Total Revenue: {totalRevenue:C}";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void occupancyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupanyReport occupancyReport = new OccupanyReport();
            occupancyReport.Show();
            this.Hide();
        }

        private void FinancialReport_Load(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable filteredPayments = paymentController.GetPaymentsByDateRange(startDate, endDate);
                paymentsDataGridView.DataSource = filteredPayments;
                DisplayTotalRevenue(filteredPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering payments: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (paymentsDataGridView.DataSource == null)
            {
                MessageBox.Show("No data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                Title = "Export Payments to CSV"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportDataTableToCSV((DataTable)paymentsDataGridView.DataSource, saveFileDialog.FileName);
                    MessageBox.Show("Export successful.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Method to export a DataTable to CSV
        private void ExportDataTableToCSV(DataTable table, string filePath)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            // Column headers
            string[] columnNames = Array.ConvertAll(table.Columns.Cast<DataColumn>().ToArray(), column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            // Rows
            foreach (DataRow row in table.Rows)
            {
                string[] fields = Array.ConvertAll(row.ItemArray, field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            System.IO.File.WriteAllText(filePath, sb.ToString());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllPayments();
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void manageBookingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BookingList bookinglistForm = new BookingList();
            bookinglistForm.Show();
            this.Hide();
        }

        private void manageGuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guestlist guestlistForm = new Guestlist();
            guestlistForm.Show();
            this.Hide();
        }

        private void occupanyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OccupanyReport occupancyReport = new OccupanyReport();
            occupancyReport.Show();
            this.Hide();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
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
