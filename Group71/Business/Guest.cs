using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    public class Guest:Person
    {
        #region Data Members
        private string guestId;
        #endregion
        #region Property Methods
        public string GuestId
        {
            get { return guestId; }
            set { guestId = value; }
        }
        #endregion
        #region Methods
        public static string GenerateGuestId()
        {
            Random random = new Random();
            return "GUEST" + random.Next(1000, 9999).ToString();
        }
        #endregion
        #region Constructor
        public Guest(string guestId) :base()
        {
            this.guestId = GenerateGuestId(); // Automatically generate guestId
        }
        #endregion
        
    }
}
