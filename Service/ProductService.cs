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
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task AddProductAsync(CreateProductDTO createProduct)
        {
           
            var product = new Product
            {
                Name = createProduct.Name,
                Stock = createProduct.Stock,
                Price = createProduct.Price,
              
            };
            if (product != null) 
            {
                await _unitOfWork.GetRepository<Product>().AddAsync(product);
                await _unitOfWork.SaveChangesAsync();   
            }
           
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var Repo=_unitOfWork.GetRepository<Product>();
            var product=await Repo.GetAllAsync();
            if (product != null)
            {
                var ProductDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
                return ProductDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productid)
        {
            if (productid >= 0)
            {
                var Repo = _unitOfWork.GetRepository<Product>();
                var product = await Repo.GetByIdAsync(productid);
                if(product != null)
                {
                    var productDto=_mapper.Map<Product,ProductDTO>(product);
                    return productDto;
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

        public async Task UpdateProductAsync(int productId, UpdateProductDto updateProduct)
        {
            
         
                var Repo= _unitOfWork.GetRepository<Product>();
                var product=await Repo.GetByIdAsync(productId);
                if(product != null)
                {

                var newproduct=updateProduct;
                _mapper.Map(updateProduct, product);  
                Repo.Update(product);
                await _unitOfWork.SaveChangesAsync();

                }
           
        }
    }
}
