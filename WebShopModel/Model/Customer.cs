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
        public Customer(string? firstName, string? lastName, string? phoneNu, string? email, string? address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNu = phoneNu;
            Email = email;
            Address = address;

        }
        public Customer(int id, string? firstName, string? lastName, string? phoneNu, string? email, string? address) :
            this(firstName, lastName, phoneNu, email, address)
        {
            Id = id;
        }



        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
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