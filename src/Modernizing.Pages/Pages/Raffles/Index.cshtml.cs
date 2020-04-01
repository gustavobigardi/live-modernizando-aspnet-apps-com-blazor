using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modernizing.Core.Entities;
using Modernizing.Infrastructure.Persistence;

namespace Modernizing.Pages.Pages.Raffles
{
    public class IndexModel : PageModel
    {
        private readonly Modernizing.Infrastructure.Persistence.ModernizingDbContext _context;

        public IndexModel(Modernizing.Infrastructure.Persistence.ModernizingDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            Meetups = await _context.Meetups.Where(m => m.Available).Select(m => new SelectListItem(m.Name, m.Id.ToString())).ToListAsync();
            return Page();
        }

        public Participant Participant { get; set; }

        [BindProperty]
        public int MeetupId { get; set; }

        public List<SelectListItem> Meetups { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task OnPostAsync()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var participant = await _context.Participants
                    .Include(p => p.Meetup)
                    .Where(p => p.Meetup.Id.Equals(MeetupId) && !p.Won)
                    .OrderBy(p => Guid.NewGuid())
                    .FirstOrDefaultAsync();

                if (participant != null)
                {
                    participant.Win();
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
                Meetups = await _context.Meetups.Where(m => m.Available).Select(m => new SelectListItem(m.Name, m.Id.ToString())).ToListAsync();
                Participant = participant;
            }
        }
    }
}
