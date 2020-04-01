using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modernizing.Core.Entities;
using Modernizing.Infrastructure.Persistence;

namespace Modernizing.Pages.Pages.Participants
{
    public class CreateModel : PageModel
    {
        private readonly Modernizing.Infrastructure.Persistence.ModernizingDbContext _context;

        public CreateModel(Modernizing.Infrastructure.Persistence.ModernizingDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Participant Participant { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Participant.Meetup = _context.Meetups.FirstOrDefault();

            _context.Participants.Add(Participant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
