using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app.razor.WebApp.Data;
using DAL = lib.DAL.Data.Model;
using lib.DAL.Data.Model;
using lib.DAL.Data.Services;

namespace app.razor.WebApp.Pages.EventPlan
{
    public class EditModel : PageModel
    {
        private readonly EventPlanService _eventPlanService;

        public EditModel()
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _eventPlanService.Update(CurrentEventPlan);
            return RedirectToPage("./Index");
        }

    }
}
