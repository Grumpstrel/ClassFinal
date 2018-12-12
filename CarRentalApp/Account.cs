using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarRentalApp
{

    public class CustomerAccounts
    {
        public static RentalModel db = new RentalModel();

        #region Customer Properties
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerDriversLicenseNumber { get; set; }
        public string CustomerCreditCardNumber { get; set; }
        public int CustomerAccountNumber { get; set; }
        // need a reference to the class for insurance information  
        public DateTime CustomerAccountCreationDate { get; set; }
        #endregion

        public virtual ICollection<RentalAgreement> RentalAgreement { get; set; }

        #region Customer Account Management

        //Account Creation

        public static CustomerAccounts CreateAccount(string customerName, string customerAddress, string customerPhoneNumber, string customerEmailAddress, string customerDriverLicenseNumber, string customerCreditCardNumber)
        {
            var account = new CustomerAccounts
            {
                CustomerName = customerName,
                CustomerAddress = customerAddress,
                CustomerPhoneNumber = customerPhoneNumber,
                CustomerEmailAddress = customerEmailAddress,
                CustomerDriversLicenseNumber = customerDriverLicenseNumber,
                CustomerCreditCardNumber = customerCreditCardNumber,
            };


            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public CustomerAccounts()
        {

            CustomerAccountCreationDate = DateTime.Now;
        }

        public static IEnumerable<CustomerAccounts> GetAllAccounts(string customerEmailAddress)
        {
            return db.Accounts.Where(a => a.CustomerEmailAddress == customerEmailAddress);
        }

        public static IEnumerable<CustomerAccounts> GetCustomerName(string customerEmailAddress)
        {
            return db.Accounts.Where(a => a.CustomerEmailAddress == customerEmailAddress);
        }

        #endregion

    }
}


