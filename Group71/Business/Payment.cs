using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    internal class Payment
    {
        #region Data Members
        private string paymentId, reservationId, transactionId, paymentMethod;
        private decimal amount;
        private bool paymentStatus;
        private DateTime paymentDate;
        #endregion
        #region Property Methods
        public string PaymentId
        {
            get { return paymentId; }
            set { paymentId = value; }
        }
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public bool PaymentStatus
        {
            get { return paymentStatus; }
            set { paymentStatus = value; }
        }
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }
        public string  ReservationId 
        {
            get {return reservationId;}
            set {reservationId = value;}
        }
        public string  TransactionId
        {
            get {return transactionId;}
            set {transactionId = value;}
        }
        public string  PaymentMethod
        {
            get {return paymentMethod;}
            set {paymentMethod = value;}
        }


        #endregion
        #region Constructor
        public Payment(string payId, string resId, string transId,decimal payAmount,DateTime payDate,string payMethod, bool payStatus)
        {
          paymentId = payId;
          reservationId = resId;
          transactionId = transId;
           paymentMethod = payMethod;
           amount = payAmount;
           paymentStatus = payStatus;
           paymentDate = payDate;

        }
        #endregion
        #region Methods
        public bool VerifyPayment ()//waiting on interface
        {
            return true;
        }
        #endregion
    }
}
