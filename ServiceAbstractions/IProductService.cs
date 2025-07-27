using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        public Task<ProductDTO> GetProductByIdAsync(int productid);
        Task AddProductAsync(CreateProductDTO createProduct);
        Task UpdateProductAsync(int productId, UpdateProductDto updateProduct);

    }
}
