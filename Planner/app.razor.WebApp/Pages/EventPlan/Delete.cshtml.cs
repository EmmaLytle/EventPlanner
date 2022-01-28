using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using app.razor.WebApp.Data;
using DAL = lib.DAL.Data.Model;
using lib.DAL.Data.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.razor.WebApp.Pages.EventPlan
{
    public class DeleteModel : PageModel
    {
        private readonly EventPlanService _eventPlanService;

        public DeleteModel()
        {
            _eventPlanService = new EventPlanService();
        }

        [BindProperty]
        public DAL.EventPlan CurrentEventPlan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            CurrentEventPlan = _eventPlanService.GetEventPlan(id.Value);

            if (CurrentEventPlan == null)
            {
                return NotFound();
            }

            //fill the Event type dropdown
            var eventTypes = _eventPlanService.GetEventPlanTypes(); //.Select(p=> new { p.ID,p.DisplayName  }) );
            ViewData["EventTypeID"] = new SelectList(eventTypes, "ID", "DisplayName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _eventPlanService.DeleteEventPlan(id.Value);
           

            return RedirectToPage("./Index");
        }
    }
}
