using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebShopModel.Model
{
    public class Customer
    {

        public Customer() { }
        public Customer(string? firstName, string? lastName, string? phoneNu, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNu = phoneNu;
            Email = email;
           

        }
        public Customer(int id, string? firstName, string? lastName, string? phoneNu, string? email) :
            this(firstName, lastName, phoneNu, email)
        {
            Id = id;
        }



        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Profile pic is required")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Profile pic is required")]
        public string? LastName { get; set; }

        [Display(Name = "Phone")]
        public string? PhoneNu { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }



        public bool IsCustomerEmpty
        {
            get
            {
                if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))
                { return true; }
                else
                {
                    return false;
                }
            }

        }

    }
}