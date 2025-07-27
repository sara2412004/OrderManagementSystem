using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using ServiceAbstractions;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService(IUnitOfWork _unitOfWork,IMapper _mapper ) : IOrderService
    {
        public async Task CreateOrderAsync(CreateOrderDto createOrder)
        {
            var order = new Order
            {
                CustomerId = createOrder.CustomerId,
                OrderDate = DateTime.Now,
                PaymentMethod = createOrder.PaymentMethod,
                Status = "Pending",
                OrderItems = new List<OrderItem>()
            };

            decimal total = 0;

            foreach (var item in createOrder.Items)
            {
                var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(item.ProductId);
                //Validate the order to ensure product stock is sufficient for the requested quantity.
                if (product == null || product.Stock < item.Quantity)
                    throw new Exception($"out of stock for product ID {item.ProductId}");


                var price = product.Price;
                var itemTotal = price * item.Quantity;

                product.Stock -= item.Quantity;
                _unitOfWork.GetRepository<Product>().Update(product);

                
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = price,
                    Discount = 0
                });

                total += itemTotal;
            }

            // Apply tiered discounts based on order total (e.g., 5% off for orders over $100, 10 % off for orders over $200).
            if (total > 200) total *= 0.90m;
            else if (total > 100) total *= 0.95m;

            order.TotalAmount = total;

            await _unitOfWork.GetRepository<Order>().AddAsync(order);

            // Generate an invoice when an order is placed.
            var invoice = new Invoice
            {
                Order = order,
                InvoiceDate = DateTime.UtcNow,
                TotalAmount = total
            };

            await _unitOfWork.GetRepository<Invoice>().AddAsync(invoice);

            await _unitOfWork.SaveChangesAsync();

            
        }


        public async Task<IEnumerable<OrderDto>> GetAllOrdersAysnc()
        {
            var Repo = _unitOfWork.GetRepository<Order>();
            var orders=await Repo.GetAllAsync();
            var ordersDto=_mapper.Map<IEnumerable<Order>,IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int orderid)
        {
            var Repo= _unitOfWork.GetRepository<Order>();   
            var order= await Repo.GetByIdAsync(orderid);
            var ordersDto = _mapper.Map<Order, OrderDto>(order);
            return ordersDto;

        }

        public async Task UpdateOrderStatusAsync(int orderId, string newStatus)
        {
            var repo = _unitOfWork.GetRepository<Order>();
            var order = await repo.GetByIdAsync(orderId);

            if (order == null)
                throw new Exception("Order not found");

            order.Status = newStatus;
            repo.Update(order);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
