using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teletime.Models;

namespace Teletime.Pages.Funcionarios
{
    public class DetailsModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public DetailsModel(Teletime.Models.TeletimeContext context)
        {
            _context = context;
        }

        public Funcionario Funcionario { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario = await _context.Funcionarios
                .Include(f => f.Cargo)
                .Include(f => f.Departamento)
                .Include(f => f.Responsavel).SingleOrDefaultAsync(m => m.CPF == id);

            if (Funcionario == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
