using CustomerService.Domain.Common;


namespace CustomerService.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
