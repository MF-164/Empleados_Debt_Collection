using Debt_Collection_DATA.IRepositories;
using Debt_Collection_DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Collection_DATA.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly ApplicationDbContext _context;

        // Dependency Injection
        public SiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Site newSite)
        {
            try
            {
                await _context.Sites.AddAsync(newSite);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateAsync method, Class: SiteRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task<Site> GetByIdAsync(int siteId)
        {
            try
            {
                var site = await _context.Sites.FindAsync(siteId);
                if (site == null)
                {
                    throw new KeyNotFoundException("Site not found.");
                }
                return site;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdAsync method, Class: SiteRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Site>> GetByClientIdAsync(int clientId)
        {
            try
            {
                return await _context.Sites
                    .Where(s => s.ClientId == clientId && s.IsActive == true)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByClientIdAsync method, Class: SiteRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Site>> GetAllActiveAsync()
        {
            try
            {
                return await _context.Sites
                    .Where(s => (bool)s.IsActive) // סינון אתרים פעילים
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllActiveAsync method, Class: SiteRepository. Original error: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Site updatedSite)
        {
            try
            {
                var site = await _context.Sites.FindAsync(updatedSite.Id);
                if (site == null)
                {
                    throw new KeyNotFoundException("Site not found.");
                }

                // עדכון פרטי האתר
                site.Name = updatedSite.Name;
                site.WorkHoursContact = updatedSite.WorkHoursContact;
                site.Phone = updatedSite.Phone;
                site.Email = updatedSite.Email;
                site.IsActive = updatedSite.IsActive;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateAsync method, Class: SiteRepository. Original error: {ex.Message}", ex);
            }
        }
    }
}
