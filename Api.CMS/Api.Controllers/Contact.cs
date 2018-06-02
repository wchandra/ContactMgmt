using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class Contact
    {
        /// <summary>
        ///  Get or set Id of the record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Get or set first name of contact
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set last name of contact
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Get or set email address of contact
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Get or set email address of PhoneNumber
        /// </summary>
        public long PhoneNumber { get; set; }

        /// <summary>
        /// Get or set selected status
        /// </summary>
        public int Status { get; set; }

    }
}
