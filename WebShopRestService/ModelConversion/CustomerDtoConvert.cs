using WebShopModel.Model;
using WebShopService.Dtos;

namespace WebShopService.ModelConversion
{
    public class CustomerDtoConvert
    {
        public static List<CustomerDto>? FromCustomerCollection(List<Customer> inCustomers)
        {
            List<CustomerDto>? aCustomerReadDtoList = null;
            if (inCustomers != null)
            {
                aCustomerReadDtoList = new List<CustomerDto>();
                CustomerDto tempDto;
                foreach (Customer aCustomer in inCustomers)
                {
                    if (aCustomer != null)
                    {
                        tempDto = FromCustomer(aCustomer);
                        aCustomerReadDtoList.Add(tempDto);
                    }
                }
            }
            return aCustomerReadDtoList;
        }
        public static CustomerDto? FromCustomer(Customer inCustomer)
        {
            CustomerDto? aCustomerReadDto = null;
            if (inCustomer != null)
            {
                aCustomerReadDto = new CustomerDto(inCustomer.FirstName, inCustomer.LastName,
                    inCustomer.PhoneNu, inCustomer.Email, inCustomer.Address);
                aCustomerReadDto.FullName = $"{inCustomer.FirstName}" +
                $" {inCustomer.LastName}";
            }
            return aCustomerReadDto;
        }
        public static Customer? ToCustomer(CustomerDto inDto)
        {
            Customer? aCustomer = null;
            if (inDto != null)
            {
                aCustomer = new Customer(inDto.FirstName, inDto.LastName, inDto.PhoneNu, inDto.Email);
            }
            return aCustomer;
        }
    }
}