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
    public class IndexModel : PageModel
    {
        private readonly Teletime.Models.TeletimeContext _context;

        public IndexModel(Teletime.Models.TeletimeContext context)
        {
            _context = context;
        }

        public IList<Departamento> Departamento { get;set; }

        public async Task OnGetAsync()
        {
            Departamento = await _context.Departamentos.ToListAsync();
        }
    }
}
