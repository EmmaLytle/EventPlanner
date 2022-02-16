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

namespace app.razor.WebApp.Pages.Invite
{
    public class EditModel : PageModel
    {
        private readonly EventPlanService _eventPlanService;

        public EditModel()
        {
            _eventPlanService = new EventPlanService();
        }

       
        [BindProperty]
        public DAL.Invite  CurrentInvite { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentInvite = _eventPlanService.GetInvite(id.Value);
            
            if (CurrentInvite == null)
            {
                return NotFound();
            }

            //fill the Relationship type dropdown
            var relationshipTypes = _eventPlanService.GetRelationshipType();
            ViewData["RelationshipTypeID"] = new SelectList(relationshipTypes, "ID", "DisplayName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _eventPlanService.UpdateInvite(CurrentInvite);

            return RedirectToPage("/EventPlan/Details", new { id = CurrentInvite.EventPlanID });

        }

    }
}
