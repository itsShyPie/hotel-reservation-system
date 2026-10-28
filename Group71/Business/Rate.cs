using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    internal class Rate
    { // Attributes to store room rates for different seasons
        #region Data Members
        private decimal low =550;
        private decimal mid =750;
        private decimal high =995;

        // Start and end dates for each season
        private DateTime lowStart;
        private DateTime lowEnd;
        private DateTime midStart;
        private DateTime midEnd;
        private DateTime highStart;
        private DateTime highEnd;
        #endregion
        #region Property Methods
        public decimal Low
        {
            get { return low; }
            set { low = value; }
        }
        public decimal High
        {
            get { return high; }
            set { high = value; }
        }
        public decimal Mid
        {
            get { return mid; }
            set { mid = value; }
        }
        #endregion
        #region Constructor
        public Rate (decimal lowRate, decimal midRate, decimal highRate)
        {
            low = lowRate;
            mid = midRate;
            high = highRate;

            // start and end dates for each season
            lowStart = new DateTime(2024, 12, 1);
            lowEnd = new DateTime(2024, 12, 7);
            midStart = new DateTime(2024, 12, 8);
            midEnd = new DateTime(2024, 12, 15);
            highStart = new DateTime(2024, 12, 16);
            highEnd = new DateTime(2024, 12, 31);
        }
        #endregion
        #region Methods
        //  determines the season and return the corresponding rate
        public decimal GetRateForDate(DateTime date)
        {
            if (date >= lowStart && date <= lowEnd)
            {
                return low;
            }
            else if (date >= midStart && date <= midEnd)
            {
                return mid;
            }
            else if (date >= highStart && date <= highEnd)
            {
                return high;
            }
            else
            {
                throw new Exception("Date is outside the defined seasonal ranges.");
            }
        }
        
        
        #endregion
    }
}
