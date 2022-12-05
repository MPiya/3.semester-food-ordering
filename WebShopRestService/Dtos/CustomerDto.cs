namespace WebShopService.Dtos
{
    public class CustomerDto
    {
        public CustomerDto(string? firstName, string? lastName, string? phoneNu)
        {
            this.FirstName = firstName; 
            this.LastName = lastName;
            this.PhoneNu = phoneNu;
        


        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    
        public string? PhoneNu { get; set; }
       

    }

}
