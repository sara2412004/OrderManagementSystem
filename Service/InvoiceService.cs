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
    public class InvoiceService(IUnitOfWork _unitOfWork, IMapper _mapper) : IInvoiceService
    {
        public async Task<List<InvoiceDto>> GetAllInvoicesAsync()
        {
            var Repo=_unitOfWork.GetRepository<Invoice>();
            var invoice=await Repo.GetAllAsync();
            var invoiceDto=  _mapper.Map<IEnumerable<Invoice>,List<InvoiceDto>>(invoice);
            return invoiceDto;
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(int invoiceId)
        {
            if(invoiceId >= 0)
            {
                var Repo=_unitOfWork.GetRepository<Invoice>();
                var invoice=await Repo.GetByIdAsync(invoiceId);
                if (invoice != null)
                {
                    var invoiceDto = _mapper.Map<Invoice, InvoiceDto>(invoice);
                    return invoiceDto;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
