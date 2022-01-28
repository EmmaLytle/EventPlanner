using DAL = lib.DAL.Data.Model;
using lib.DAL.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lib.DAL.Data.Model;

namespace app.razor.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private EventPlanService _eventPlanService;

        // [FromQuery(Name = "id")]
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public DAL.EventPlan CurrentItem { get; set; }
        public List<EventPlanSummary> EventPlanSummaries { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _eventPlanService = new EventPlanService();
        }

        public void OnGet()
        {
            var temp = _eventPlanService.GetEventPlan(ID);
            CurrentItem = temp;

            EventPlanSummaries = _eventPlanService.GetEventPlanSummary().ToList();

        }
    }
}
