using PreorderPlatform.Service.ViewModels.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.BusinessServices
{
    public interface IBusinessService
    {
        Task<BusinessViewModel> CreateBusinessAsync(BusinessCreateViewModel model);
        Task DeleteBusinessAsync(int id);
        Task<BusinessViewModel> GetBusinessByIdAsync(int id);
        Task<List<BusinessViewModel>> GetBusinessesAsync();
        Task UpdateBusinessAsync(BusinessUpdateViewModel model);
    }
}
