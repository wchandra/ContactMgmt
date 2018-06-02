using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.CMS.Areas.Contact.Models
{
    /// <summary>
    /// Class Contact represents an entity that the organisation is associated with
    /// </summary>
    public class Contact
    {
        /// <summary>
        ///  Get or set Id of the record
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Get or set first name of contact
        /// </summary>
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set last name of contact
        /// </summary>
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        /// <summary>
        /// Get or set email address of contact
        /// </summary>
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage ="Please enter email address in valid format")]
        public string Email { get; set; }

        /// <summary>
        /// Get or set email address of PhoneNumber
        /// </summary>
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression("[0-9]{10}", ErrorMessage ="10 digit phone number is required")]
        public long PhoneNumber { get; set; }

        /// <summary>
        /// Get or set status of contact
        /// </summary>
       
        public List<String> Status { get; set; }

        /// <summary>
        /// Get or set selected status
        /// </summary>
        [Required(ErrorMessage = "Status is required")]
        public string SelectedStatus { get; set; }
    }
}
