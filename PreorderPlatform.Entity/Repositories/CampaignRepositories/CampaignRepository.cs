using PreorderPlatform.Entity.Entities;

namespace PreorderPlatform.Entity.Repositories.CampaignRepositories
{
    public class CampaignRepository : RepositoryBase<Campaign>, ICampaignRepository
    {
        public CampaignRepository(PreOrderSystemContext context) : base(context)
        {

        }

        // Add any additional methods specific to CampaignRepository here...
    }
}