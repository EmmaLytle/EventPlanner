using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using app.razor.WebApp.Data;
using DAL = lib.DAL.Data.Model;

namespace app.razor.WebApp.Pages.EventPlan
{
    public class DetailsModel : PageModel
    {
        private readonly app.razor.WebApp.Data.apprazorWebAppContext _context;

        public DetailsModel(app.razor.WebApp.Data.apprazorWebAppContext context)
        {
            _context = context;
        }

        public DAL.EventPlan EventPlan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventPlan = await _context.EventPlan
                .Include(e => e.EventType).FirstOrDefaultAsync(m => m.ID == id);

            if (EventPlan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
