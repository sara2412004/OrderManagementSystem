using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface ICustomerService
    {
        public Task CreateCustomerAsync(CreateCustomerDto createCustomer);
        public Task<IEnumerable<OrderDto>> GetAllOrdersForCustomerAsync(int customerid);
    }
}
