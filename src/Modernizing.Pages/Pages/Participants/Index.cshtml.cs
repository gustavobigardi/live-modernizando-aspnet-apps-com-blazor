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
    public class IndexModel : PageModel
    {
        private readonly Modernizing.Infrastructure.Persistence.ModernizingDbContext _context;

        public IndexModel(Modernizing.Infrastructure.Persistence.ModernizingDbContext context)
        {
            _context = context;
        }

        public IList<Participant> Participant { get;set; }

        public async Task OnGetAsync()
        {
            Participant = await _context.Participants.ToListAsync();
        }
    }
}
