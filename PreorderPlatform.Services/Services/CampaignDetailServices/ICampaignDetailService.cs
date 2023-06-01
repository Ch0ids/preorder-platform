using PreorderPlatform.Service.ViewModels.CampaignDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.CampaignDetailServices
{
    public interface ICampaignDetailService
    {
        Task<CampaignDetailViewModel> CreateCampaignDetailAsync(CampaignDetailCreateViewModel model);
        Task DeleteCampaignDetailAsync(int id);
        Task<CampaignDetailViewModel> GetCampaignDetailByIdAsync(int id);
        Task<List<CampaignDetailViewModel>> GetCampaignDetailsAsync();
        Task UpdateCampaignDetailAsync(CampaignDetailUpdateViewModel model);
    }
}
