using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teletime.Models;

namespace Teletime.Pages.Funcionarios
{
    public class EditModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public EditModel(Teletime.Models.TeletimeContext context)
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
           ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "NomeCargo");
           ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomeDepartamento");
           ViewData["CPFResponsavel"] = new SelectList(_context.Funcionarios, "CPF", "Nome");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("./Index");
        }
    }
}
