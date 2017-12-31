using MyParking.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyParking.ViewModels
{
    
    public class CustomerVM 
    {
        public CustomerVM()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        public virtual ICollection<Reservation> Reservations { get; set; }

        [Key]
        public int CustomerID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required!")]
        [StringLength(50, MinimumLength = 4)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required!")]
        [StringLength(50, MinimumLength = 4)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [RegularExpression("^[0-9\\-\\+]{9,15}$", ErrorMessage = "Invalid Phone Number!")]
        [Required(ErrorMessage = "Phone Number Required!")]
        public string Phone { get; set; }

        public static CustomerVM MapTo(Customer customer)
        {

            return new CustomerVM
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone

            };
        }

        public static Customer MapTo(CustomerVM customerVM)
        {
            return new Customer
            {
                CustomerID = customerVM.CustomerID,
                FirstName = customerVM.FirstName,
                LastName = customerVM.LastName,
                Phone = customerVM.Phone
            };
        }
        
    }
}