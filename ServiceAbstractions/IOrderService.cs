using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface IOrderService
    {
        public Task CreateOrderAsync(CreateOrderDto createOrder);
        public Task<OrderDto?> GetOrderByIdAsync(int orderid);
        public Task<IEnumerable<OrderDto>> GetAllOrdersAysnc();
        public Task UpdateOrderStatusAsync(int orderId, string newStatus);

    }
}
