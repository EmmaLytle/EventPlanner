using lib.DAL.Data.Model;
using lib.DAL.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.razor.WebApp.Pages
{
    public class AddEventModel : PageModel
    {
        private readonly ILogger<AddEventModel> _logger;
        private EventPlanService _eventPlanService;

        public int ID { get; set; }
        public List<EventPlanSummary> EventPlanSummaries { get; set; }


        public AddEventModel(ILogger<AddEventModel> logger)
        {
            _logger = logger;
            _eventPlanService = new EventPlanService();
        }

        public void OnGet()
        {
            EventPlanSummaries = _eventPlanService.GetEventPlanSummary().ToList();
        }

        public void Create( )
        {
        
            //Want to insert into the EventPlan table the information from the input feilds


        }
    }
}
