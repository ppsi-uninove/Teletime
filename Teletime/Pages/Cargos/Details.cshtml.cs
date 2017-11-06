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
    public class DetailsModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public DetailsModel(Teletime.Models.TeletimeContext context)
        {
            _context = context;
        }

        public Cargo Cargo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cargo = await _context.Cargos.SingleOrDefaultAsync(m => m.IdCargo == id);

            if (Cargo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
