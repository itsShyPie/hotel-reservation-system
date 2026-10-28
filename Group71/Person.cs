using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Group71
{
    public class Person
    {
        #region Data Members
        private string personId, fName,l_Name, phone, address, email, city,postalCode;
        private DateTime dob;
        #endregion
        #region Property Methods
        public string Id
        {
            get { return personId; }
            set { personId = value; }
        }
        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }
        public string L_Name
        {
            get { return l_Name; }
            set { L_Name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Address 
        { 
            get { return address; }
            set { address = value; }
        }
        public string Email 
        { 
            get { return email; }
            set { email = value; }
        }
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        #endregion
        #region Constructor
        public Person()
        {
            personId = "";
            fName = "";
            l_Name = "";
            phone = "";
            address = "";
            email = "";
            dob = new DateTime();
            city = "";
            postalCode = "";
        }

        public Person(string pCity,string pPostalCode, DateTime pDob,string pID, string pName,string pLName ,string pPhone,string pAddress, string pEmail)
        {
            personId = pID;
            dob = pDob;
            fName = pName;
            l_Name = pLName;
            phone = pPhone;
            address = pAddress;
            email = pEmail;
            city = pCity;
            postalCode = pPostalCode;
        }
        #endregion
        #region Methods
        //public override string ToString()
        //{
        //    return name + '\n' + Phone;
        //}
        #endregion
    }
}
