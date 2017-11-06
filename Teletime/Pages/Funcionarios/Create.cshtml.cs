using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teletime.Models;

namespace Teletime.Pages.Funcionarios
{
    public class CreateModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public CreateModel(Teletime.Models.TeletimeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "NomeCargo");
        ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NomeDepartamento");
        ViewData["CPFResponsavel"] = new SelectList(_context.Funcionarios, "CPF", "Nome");
            return Page();
        }

        [BindProperty]
        public Funcionario Funcionario { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Funcionarios.Add(Funcionario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}