using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modernizing.Core.Entities;
using Modernizing.Infrastructure.Persistence;

namespace Modernizing.Pages.Pages.Meetups
{
    public class DetailsModel : PageModel
    {
        private readonly Modernizing.Infrastructure.Persistence.ModernizingDbContext _context;

        public DetailsModel(Modernizing.Infrastructure.Persistence.ModernizingDbContext context)
        {
            _context = context;
        }

        public Meetup Meetup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meetup = await _context.Meetups.FirstOrDefaultAsync(m => m.Id == id);

            if (Meetup == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
