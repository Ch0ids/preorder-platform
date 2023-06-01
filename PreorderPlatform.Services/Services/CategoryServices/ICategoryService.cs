using PreorderPlatform.Service.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<BusinessViewModel> CreateCategoryAsync(BusinessCreateViewModel model);
        Task DeleteCategoryAsync(int id);
        Task<List<BusinessViewModel>> GetCategoriesAsync();
        Task<BusinessViewModel> GetCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(BusinessUpdateViewModel model);
    }
}
