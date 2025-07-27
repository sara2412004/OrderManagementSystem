using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractions;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto dto)
        {
            await _customerService.CreateCustomerAsync(dto);
            return Ok();
        }

        [Authorize]
        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetOrdersForCustomer(int customerId)
        {
            var orders = await _customerService.GetAllOrdersForCustomerAsync(customerId);
            return Ok(orders);
        }
    }
}
