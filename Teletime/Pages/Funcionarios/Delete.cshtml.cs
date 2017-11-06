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
    public class DeleteModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public DeleteModel(Teletime.Models.TeletimeContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario = await _context.Funcionarios.FindAsync(id);

            if (Funcionario != null)
            {
                _context.Funcionarios.Remove(Funcionario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
