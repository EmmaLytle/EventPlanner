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

namespace app.razor.WebApp.Pages.EventItem
{
    public class CreateModel : PageModel
    {
        private readonly EventPlanService _eventPlanService;


        public CreateModel()
        {
            _eventPlanService = new EventPlanService();
        }
        [BindProperty]
        public int CurrentEventPlanid { get; set; }
        [BindProperty]
        public DAL.EventPlanItem EventPlanItem { get; set; }
        [BindProperty]
        public TimeSpan StartEventTime { get; set; }
        [BindProperty]
        public DateTime StartEventDate { get; set; }
        [BindProperty]
        public TimeSpan EndEventTime { get; set; }
        [BindProperty]
        public DateTime EndEventDate { get; set; }

        public IActionResult OnGet(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            //Get the id so the new event plan item will know what event plan its attached to 
            CurrentEventPlanid = id.Value;
            EventPlanItem = new DAL.EventPlanItem();
            EventPlanItem.EventPlanID = id.Value;
            StartEventDate = DateTime.Now.AddMonths(2); //Default for date picker
            EndEventDate = DateTime.Now.AddMonths(2); //Default for date picker

            if (CurrentEventPlanid == null)
            {
                return NotFound();
            }

            
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
            DateTime StartTime = new DateTime(StartEventDate.Year, StartEventDate.Month, StartEventDate.Day, StartEventTime.Hours, StartEventTime.Minutes, StartEventTime.Seconds);
            EventPlanItem.StartDateTime = StartTime;
            DateTime EndTime = new DateTime(EndEventDate.Year, EndEventDate.Month, EndEventDate.Day, EndEventTime.Hours, EndEventTime.Minutes, EndEventTime.Seconds);
            EventPlanItem.EndDateTime = EndTime;
            EventPlanItem.EventPlanID = CurrentEventPlanid;

            _eventPlanService.InsertEventPlanItem(EventPlanItem);


            //  new{ id = EventPlanItem.EventPlanID} Is an annoyms object 
            return RedirectToPage("/EventPlan/Details", new{ id = EventPlanItem.EventPlanID});
        }
    }
}
