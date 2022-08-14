using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Features.AddCustomer.Commands
{
    public class AddCustomerCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
