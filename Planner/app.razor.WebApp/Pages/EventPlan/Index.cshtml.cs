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
using lib.DAL.Data.Model;

namespace app.razor.WebApp.Pages.EventPlan
{
    public class IndexModel : PageModel
    {
        private readonly  EventPlanService _eventPlanService;

        public IndexModel()
        {
            _eventPlanService = new EventPlanService();
        }

        public List<EventPlanSummary> EventPlanSummary { get;set; }

        public void OnGet()
        {
            EventPlanSummary =  _eventPlanService.GetEventPlanSummary().ToList();
            
        }
    }
}
