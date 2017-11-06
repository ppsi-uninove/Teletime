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
    public class DeleteModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public DeleteModel(Teletime.Models.TeletimeContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cargo = await _context.Cargos.FindAsync(id);

            if (Cargo != null)
            {
                _context.Cargos.Remove(Cargo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
