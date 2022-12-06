using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopModel.Model
{
    public class Customer
    {

        public Customer() { }
        public Customer(string? firstName, string? lastName, string? phoneNumber, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
           

        }
        public Customer(int id, string? firstName, string? lastName, string? phoneNu, string? email) :
            this(firstName, lastName, phoneNu, email)
        {
            Id = id;
        }



        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
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