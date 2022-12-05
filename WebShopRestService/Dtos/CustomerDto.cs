namespace WebShopService.Dtos
{
    public class CustomerDto
    {
        public CustomerDto(string? firstName, string? lastName, string? phoneNu, string? email, string? address)
        {
            this.FirstName = firstName; 
            this.LastName = lastName;
            this.PhoneNu = phoneNu;
            this.Email = email;
            this.Address = address;


        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNu { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }

}
