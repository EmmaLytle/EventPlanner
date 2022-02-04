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

namespace app.razor.WebApp.Pages.Invite
{
    public class CreateModel : PageModel
    {
        private readonly EventPlanService _eventPlanService;


        public CreateModel()
        {
            _eventPlanService = new EventPlanService();
        }
          [BindProperty]
          public DAL.Invite Invite { get; set; }
          public DAL.EventPlan CurrentEventPlan { get; set; }

        public IActionResult OnGet(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            CurrentEventPlan = _eventPlanService.GetEventPlan(id.Value);
            Invite = new DAL.Invite();
            Invite.EventPlanID = id.Value;

            if (CurrentEventPlan == null)
            {
                return NotFound();
            }

            //fill the Relationship type dropdown
            var relationshipTypes = _eventPlanService.GetRelationshipType(); 
            ViewData["RelationshipTypeID"] = new SelectList(relationshipTypes, "ID", "DisplayName");
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
            
            _eventPlanService.InsertInvite(Invite);


            //  new{ id = Invite.EventPlanID} Is an annoyms object 
            return RedirectToPage("/EventPlan/Details", new{ id = Invite.EventPlanID});
        }
    }
}
