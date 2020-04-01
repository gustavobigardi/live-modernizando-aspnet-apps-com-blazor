using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modernizing.Core.Entities;
using Modernizing.Infrastructure.Persistence;

namespace Modernizing.Pages.Pages.Participants
{
    public class DetailsModel : PageModel
    {
        private readonly Modernizing.Infrastructure.Persistence.ModernizingDbContext _context;

        public DetailsModel(Modernizing.Infrastructure.Persistence.ModernizingDbContext context)
        {
            _context = context;
        }

        public Participant Participant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await _context.Participants.FirstOrDefaultAsync(m => m.Id == id);

            if (Participant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
