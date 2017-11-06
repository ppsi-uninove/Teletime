using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teletime.Models;

namespace Teletime.Pages.Departamentos
{
    public class DetailsModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public DetailsModel(Teletime.Models.TeletimeContext context)
        {
            _context = context;
        }

        public Departamento Departamento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departamento = await _context.Departamentos.SingleOrDefaultAsync(m => m.IdDepartamento == id);

            if (Departamento == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
