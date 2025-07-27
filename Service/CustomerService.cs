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
    public class CustomerService(IUnitOfWork _unitOfWork, IMapper _mapper) : ICustomerService
    {
        public async Task CreateCustomerAsync(CreateCustomerDto createCustomer)
        {
            var customer = new Customer
            {
                CustomerId = createCustomer.CustomerId,
                Email = createCustomer.Email,
                Name = createCustomer.Name,
               
            };
            
            
                await _unitOfWork.GetRepository<Customer>().AddAsync(customer);
              await _unitOfWork.SaveChangesAsync();
            
            
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersForCustomerAsync(int customerid)
        {
            var Repo = _unitOfWork.GetRepository<Order>();
            var order = await Repo.GetAllAsync();
            var customerOrders = order.Where(o => o.CustomerId == customerid).ToList(); //filter

            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(customerOrders);
            return orderDtos;
        }
    }
}
