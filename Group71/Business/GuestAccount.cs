using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    internal class GuestAccount : Guest
    {
        #region Data Members
        private string accountId;
        #endregion
        #region Property Methods
        public string AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        #endregion
        #region Constructor
        public GuestAccount(string accountId, string guestId) : base(guestId)
        {
            this.accountId = accountId;
        }
        #endregion
        
    }
}
