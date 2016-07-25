using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CEN4370_week10_backend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private PhoneBookEntities dbcontext = new PhoneBookEntities();

        public string[] GetEntries(string lastName)
        {
            // query database for entries with a given last name
            // save results into string array
            var query =
                from PhoneBook in dbcontext.PhoneBooks
                where PhoneBook.LastName.Contains(lastName)
                select new { PhoneBook.FirstName, PhoneBook.LastName, PhoneBook.PhoneNumber } ;

            List<string> entries = new List<string>();

            foreach (var element in query)
            {
                string entry = element.LastName.Trim() + ", " + element.FirstName.Trim() + ", " + element.PhoneNumber.Trim();
                entries.Add(entry); 
            }


            string[] myArray = entries.ToArray();
            return myArray;
        }

        public string AddEntries(string lastName, string firstName, string phoneNumber)
        {
            PhoneBook pb = new PhoneBook()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };

            try
            {
                dbcontext.PhoneBooks.Add(pb);
                dbcontext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                return "Something went wrong while updating the database." +
                    "\n Detailed error message: \n" + e.InnerException;
            }

            return "Entry added successfully";
        }
    }
}
