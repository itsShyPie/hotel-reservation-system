using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    internal class Reservation : Guest
    {
        #region Data Members
        private string reservation_id;
        private DateTime reservation_date;
        private DateTime check_in_date;
        private DateTime check_out_date;


        private int numberOfGuests;
        private bool resStatus;
        private decimal deposit;
        private decimal totalAmount;
        private string res_Ref;
        #endregion
        #region Property Methods
        public int NumberOfGuests
        {
            get { return numberOfGuests; }
            set { numberOfGuests = value; }
        }
        public bool Res_Status
        {
            get { return resStatus; }
            set { resStatus = value; }
        }
        public decimal Deposit
        {
            get { return deposit; }
            set { deposit = value; }
        }
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        public string Res_Reference
        {
            get { return res_Ref; }
            set { res_Ref = value; }
        }
        public string Reservation_id 
        {
            get{return reservation_id;}
            set {reservation_id = value;}
        }
        
        public DateTime Reservation_date  
        {
            get{return reservation_date;}
            set {reservation_date = value;}
        }
        public DateTime Check_in_dates  
        {
            get{return check_in_date;}
            set {check_in_date = value;}
        }
         public DateTime Check_out_dates  
        {
            get{return check_out_date;}
            set {check_out_date = value;}
        }


        #endregion
        #region Constructor
        public Reservation(string reservationID, string guestId, DateTime reservationDate, DateTime checkInDate, DateTime checkOutDate, int numGuests, bool resStatus, decimal deposit, decimal totalAmount, string reference) : base(guestId)
        {
            this.reservation_id = reservationID;
            this.reservation_date = reservationDate;
            this.check_in_date = checkInDate;
            this.check_out_date = checkOutDate;
            this.NumberOfGuests = numGuests;
            this.resStatus = resStatus;
            this.deposit = deposit;
            this.totalAmount = totalAmount;
            this.res_Ref = reference;
        }
        #endregion

    }
}
