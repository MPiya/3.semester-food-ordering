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


        public Customer(string? firstName, string? lastName, string? phoneNu)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNu = phoneNu;
        }


        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]

        public string? LastName { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string? PhoneNu { get; set; }
        public string? Email { get; set; }

        public string? Address { get; set; }


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