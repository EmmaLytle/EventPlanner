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
using lib.DAL.Data.Model;

namespace app.razor.WebApp.Pages.EventPlan
{
    public class DetailsModel : PageModel
    {
        private readonly EventPlanService _eventPlanService;

        public DetailsModel()
        {
            _eventPlanService = new EventPlanService();
        }

        public DAL.EventPlan CurrentEventPlan { get; set; }
        public DAL.Invite CurrentInvite { get; set; }
        public List<InviteSummary> InviteSummaryList { get; set; }
        public List<EventPlanItem> EventPlanItemList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentEventPlan = _eventPlanService.GetEventPlan(id.Value);
            InviteSummaryList = _eventPlanService.GetInviteSummaries(id.Value).ToList();
            EventPlanItemList = _eventPlanService.GetEventPlanItems(id.Value).ToList();

            if(CurrentEventPlan == null)
            {
                return NotFound();
            }

           
            return Page();
        }
    }
}
