namespace RestAPI.Dtos
{
    public class CustomerDto
    {
        public CustomerDto(string? firstName, string? lastName, string? phoneNu, string? email)
        {
            this.FirstName = firstName; 
            this.LastName = lastName;
            this.PhoneNu = phoneNu;
            this.Email = email;
         


        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNu { get; set; }
        public string Email { get; set; }
       
    }

}
