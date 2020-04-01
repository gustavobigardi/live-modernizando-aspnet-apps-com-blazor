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

namespace Modernizing.Pages.Pages.Meetups
{
    public class EditModel : PageModel
    {
        private readonly Modernizing.Infrastructure.Persistence.ModernizingDbContext _context;

        public EditModel(Modernizing.Infrastructure.Persistence.ModernizingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Meetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetupExists(Meetup.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MeetupExists(int id)
        {
            return _context.Meetups.Any(e => e.Id == id);
        }
    }
}
