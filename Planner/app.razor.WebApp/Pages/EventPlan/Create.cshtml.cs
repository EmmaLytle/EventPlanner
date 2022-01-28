using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using app.razor.WebApp.Data;
using DAL = lib.DAL.Data.Model;
using lib.DAL.Data.Model;
using lib.DAL.Data.Services;

namespace app.razor.WebApp.Pages.EventPlan
{
    public class CreateModel : PageModel
    {
        private readonly EventPlanService _eventPlanService;


        public CreateModel()
        {
            _eventPlanService = new EventPlanService();
        }
        [BindProperty]
        public DAL.EventPlan EventPlan { get; set; }

        public IActionResult OnGet()
        {
            //fill the Event type dropdown
            var eventTypes = _eventPlanService.GetEventPlanTypes(); //.Select(p=> new { p.ID,p.DisplayName  }) );
            ViewData["EventTypeID"] = new SelectList(eventTypes, "ID", "DisplayName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                       
            _eventPlanService.InsertEventPlan(EventPlan);

            return RedirectToPage("./Index");
        }
    }
}
