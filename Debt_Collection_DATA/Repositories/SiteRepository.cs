using Debt_Collection_DATA.Helpers;
using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly ApplicationDbContext _context;

        public SiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Site> CreateAsync(Site newSite)
        {
            try
            {
                var entry = await _context.Sites.AddAsync(newSite);
                await _context.SaveChangesAsync();

#pragma warning disable CS8603 // Possible null reference return.
                return await _context.Sites
                    .Include(s => s.Client)
                    .FirstOrDefaultAsync(s => s.Id == entry.Entity.Id);
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync (SiteRepository): {ex.Message}", ex);
            }
        }

        public async Task<Site> GetByIdAsync(int siteId)
        {
            try
            {
                var site = await _context.Sites
                    .Include(s => s.Client)
                    .FirstOrDefaultAsync(s => s.Id == siteId);

                if (site == null)
                    throw new KeyNotFoundException("Site not found.");

                return site;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync (SiteRepository): {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Site>> GetByClientIdAsync(int clientId)
        {
            try
            {
                return await _context.Sites
                    .Include(s => s.Client)
                    .Where(s => s.ClientId == clientId && s.IsActive == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByClientIdAsync (SiteRepository): {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Site>> GetAllActiveAsync()
        {
            try
            {
                return await _context.Sites
                    .Include(s => s.Client)
                    .Where(s => s.IsActive == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllActiveAsync (SiteRepository): {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Site updatedSite)
        {
            var existingSite = await _context.Sites.FindAsync(updatedSite.Id);
            if (existingSite == null)
                throw new KeyNotFoundException("Site not found.");

            PatchHelper.PatchNonNullValues(updatedSite, existingSite, _context, "Id");

            await _context.SaveChangesAsync();
        }

    }
}
