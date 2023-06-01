using PreorderPlatform.Service.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.ProductServices
{
    public interface IProductService
    {
        Task<ProductViewModel> CreateProductAsync(ProductCreateViewModel model);
        Task DeleteProductAsync(int id);
        Task<ProductViewModel> GetProductByIdAsync(int id);
        Task<List<ProductViewModel>> GetProductsAsync();
        Task UpdateProductAsync(ProductUpdateViewModel model);
    }
}
