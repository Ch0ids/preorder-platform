using PreorderPlatform.Service.ViewModels.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Services.CampaignServices
{
    public interface ICampaignService
    {
        Task<CampaignViewModel> CreateCampaignAsync(CampaignCreateViewModel model);
        Task DeleteCampaignAsync(int id);
        Task<CampaignViewModel> GetCampaignByIdAsync(int id);
        Task<List<CampaignViewModel>> GetCampaignsAsync();
        Task UpdateCampaignAsync(CampaignUpdateViewModel model);
    }
}
