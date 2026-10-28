using Group71.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    public class PaymentController
    {
        private PaymentDB paymentDB;

       

        public PaymentController()
        {
            paymentDB = new PaymentDB();
        }

        // Retrieve all payments
        public DataTable GetAllPayments()
        {
            return paymentDB.GetAllPayments();
        }

        // Retrieve payments within a specific date range
        public DataTable GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            return paymentDB.GetPaymentsByDateRange(startDate, endDate);
        }

        // Calculate total revenue from payments
        public decimal CalculateTotalRevenue(DataTable payments)
        {
            decimal total = 0;
            foreach (DataRow row in payments.Rows)
            {
                total += row.Field<decimal>("amount");
            }
            return total;
        }
    }
}
