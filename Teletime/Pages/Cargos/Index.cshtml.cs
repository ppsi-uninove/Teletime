using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teletime.Models;

namespace Teletime.Pages.Cargos
{
    public class IndexModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public IndexModel(Teletime.Models.TeletimeContext context)
        {
            _context = context;
        }

        public IList<Cargo> Cargo { get;set; }

        public async Task OnGetAsync()
        {
            Cargo = await _context.Cargos.ToListAsync();
        }
    }
}
