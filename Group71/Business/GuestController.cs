using Group71.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    internal class GuestController
    {
        private GuestDB guestDB = new GuestDB();

        #region Constructor
        public GuestController()
        {
            guestDB = new GuestDB();
        }


        #endregion

        #region Methods
        // retrieves all guests
        public DataTable GetAllGuests()
        {
            return guestDB.GetAllGuests(); // Calls the GuestDB method to retrieve guests
        }
        // adds a new guest
        public void AddGuest(/*string guestId,*/string firstName, string lastName, string address, string city, string postalCode, string phone, string email, DateTime dob  )
        {
            
            // Calls the AddGuest method from the GuestDB class
            guestDB.AddGuest(firstName, lastName, address, city, postalCode, phone, email, dob);
        }
        // updates an existing guest's information
        public void UpdateGuest(string guestId, string city, string postalCode, DateTime dob, string firstName, string lastName, string phone, string address, string email)
        {
            // Call the UpdateGuest method from the GuestDB class
            guestDB.UpdateGuest(guestId,city, postalCode, dob, firstName, lastName, phone, address, email);
        }

        // deletes a guest by guest ID
        public void DeleteGuest(string guestId)
        {
            

            // Then delete the guest
            guestDB.DeleteGuest(guestId);
        }

        // searches for a guest by their ID
        public DataRow SearchGuestById(string guestId)
        {
            return guestDB.SearchGuestById(guestId); // Call the database method
        }
    }





    #endregion
}

