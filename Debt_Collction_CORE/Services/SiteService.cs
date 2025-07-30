using AutoMapper;
using Debt_Collection_CORE.IServices;
using Debt_Collection_CORE.ViewModels;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debt_Collection_CORE.Services
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;

        public SiteService(ISiteRepository siteRepository, IMapper mapper)
        {
            this._siteRepository = siteRepository;
            this._mapper = mapper;
        }

        public async Task CreateAsync(SiteVM newSite)
        {
            try
            {
                ValidateSite(newSite);
                await _siteRepository.CreateAsync(ConvertToSite(newSite));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync method, Class: SiteService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task<Site> GetByIdAsync(int siteId)
        {
            try
            {
                if (siteId <= 0)
                {
                    throw new ArgumentException("Invalid site ID");
                }
                return await _siteRepository.GetByIdAsync(siteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync method, Class: SiteService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<SiteVM>> GetByClientIdAsync(int clientId)
        {
            try
            {
                if (clientId <= 0)
                {
                    throw new ArgumentException("Invalid client ID");
                }

                var sites = await _siteRepository.GetByClientIdAsync(clientId);
                return sites.Select(s => ConvertToSiteVM(s)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByClientIdAsync method, Class: SiteService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<SiteVM>> GetAllActiveAsync()
        {
            try
            {
                var sites = await _siteRepository.GetAllActiveAsync();
                return sites.Select(s => ConvertToSiteVM(s)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllActiveAsync method, Class: SiteService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(SiteVM updatedSite)
        {
            try
            {
                ValidateSite(updatedSite);
                await _siteRepository.UpdateAsync(ConvertToSite(updatedSite));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAsync method, Class: SiteService, Project: Debt_Collection_CORE. Original error: {ex.Message}", ex);
            }
        }

        private void ValidateSite(SiteVM site)
        {
            if (site == null)
            {
                throw new ArgumentNullException(nameof(site));
            }

            // Implement additional validations as necessary
            if (string.IsNullOrWhiteSpace(site.Name))
            {
                throw new ArgumentException("Site name cannot be empty");
            }

            // Add other validations as needed
        }

        private Site ConvertToSite(SiteVM siteVM) => _mapper.Map<Site>(siteVM);
        private SiteVM ConvertToSiteVM(Site site) => _mapper.Map<SiteVM>(site);
    }
}
