using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group71.Business
{
    internal class Room
    {
        #region Data Members
        private string room_id;
        private string room_number;
        private string status;
        #endregion
        #region Property Methods
        public string Room_id 
        {
            get {return room_id;}
            set {room_id = value;}
        }
        public string Room_number
        {
            get {return room_number;}
            set {room_number = value;}
        }
        public string Status
        {
            get {return status;}
            set {status = value;}
        }

        #endregion
        #region Constructor
        public Room (string roomID,string roomNumber,string roomStatus)
        {
          room_id = roomID;
          room_number = roomNumber;
          status = roomStatus;
        }
        #endregion
       
    }
}
