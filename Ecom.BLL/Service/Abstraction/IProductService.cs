using Ecom.BLL.ModelVM.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.BLL.Service.Abstraction
{

    /// <summary>
    /// Defines the business operations available for the Product entity.
    /// The service layer orchestrates data access (via repos), validation, and business rules.
    /// </summary>
    public interface IProductService
    {
        Task<ResponseResult<IEnumerable<GetProductVM>>> GetAllForAdminAsync();

        Task<ResponseResult<IEnumerable<GetProductVM>>> GetAllByBrandIdAsync(int brandId);

        Task<ResponseResult<IEnumerable<GetProductVM>>> GetAllByCategoryIdAsync(int categoryId);



        Task<ResponseResult<GetProductVM>> GetByIdAsync(int id);

      
        Task<ResponseResult<bool>> CreateAsync(CreateProductVM model);

        
        Task<ResponseResult<bool>> UpdateAsync(UpdateProductVM model);

        Task<ResponseResult<bool>> DeleteAsync(DeleteProductVM model);

        Task<ResponseResult<bool>> DecreaseStockAsync(int productId, int quantity);



    }
}
