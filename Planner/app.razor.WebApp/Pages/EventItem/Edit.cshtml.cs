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

namespace app.razor.WebApp.Pages.EventItem
{
    public class EditModel : PageModel
    {
        private readonly EventPlanService _eventPlanService;

        public EditModel()
        {
            _eventPlanService = new EventPlanService();
        }

        [BindProperty]
        public int EventPlanID { get; set; }
        [BindProperty]
        public DAL.EventPlanItem  CurrentEventItem { get; set; }
        [BindProperty]
        public TimeSpan StartEventTime { get; set; }
        [BindProperty]
        public DateTime StartEventDate { get; set; }
        [BindProperty]
        public TimeSpan EndEventTime { get; set; }
        [BindProperty]
        public DateTime EndEventDate { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentEventItem = _eventPlanService.GetEventItem(id.Value);
            StartEventDate = DateTime.Now.AddMonths(2); //Default for date picker
            EndEventDate = DateTime.Now.AddMonths(2); //Default for date picker

            if (CurrentEventItem == null)
            {
                return NotFound();
            }
                       

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DateTime StartTime = new DateTime(StartEventDate.Year, StartEventDate.Month, StartEventDate.Day, StartEventTime.Hours, StartEventTime.Minutes, StartEventTime.Seconds);
            CurrentEventItem.StartDateTime = StartTime;
            DateTime EndTime = new DateTime(EndEventDate.Year, EndEventDate.Month, EndEventDate.Day, EndEventTime.Hours, EndEventTime.Minutes, EndEventTime.Seconds);
            CurrentEventItem.EndDateTime = EndTime;
            _eventPlanService.UpdateEventItem(CurrentEventItem);

            return RedirectToPage("/EventPlan/Details", new { id = CurrentEventItem.EventPlanID });

        }

    }
}
