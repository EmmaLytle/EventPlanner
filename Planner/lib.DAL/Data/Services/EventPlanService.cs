using lib.DAL.Data.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.DAL.Data.Services
{
    public class EventPlanService
    {
        private Entities _ent;

        public EventPlanService()
        {
            _ent = new Entities();

        }

        public EventPlan GetEventPlan(int id)
        {
            //_ent is hooked up to DB 
            var item = _ent.EventPlans.FirstOrDefault(p => p.ID == id);
           

            return item;
        }

        public IQueryable<EventPlanSummary> GetEventPlanSummary()
        {
            var items = _ent.EventPlanSummaries;
            return items;
        }

        public void Update(EventPlan eventPlan)
        {

            var item = _ent.EventPlans.FirstOrDefault(p => p.ID == eventPlan.ID);
            item.Title = eventPlan.Title;
            item.ModifiedDate = DateTime.UtcNow;
            item.Description = eventPlan.Description;
            item.EventTypeID = eventPlan.EventTypeID;

            _ent.SaveChanges();

        }

        public int Insert(EventPlan eventPlan)
        {
            
            EventPlan ep = new EventPlan();
            ep.Title = eventPlan.Title;
            ep.Description = eventPlan.Description;
            ep.EventTypeID = eventPlan.EventTypeID;

            eventPlan.ModifiedDate = DateTime.UtcNow;
            eventPlan.CreatedDate = DateTime.UtcNow;
            _ent.EventPlans.Add(eventPlan);
                       
            _ent.SaveChanges();

            return eventPlan.ID;
        }

        public void Delete(int id)
        {

            var item = _ent.EventPlans.FirstOrDefault(p => p.ID == id);

            _ent.EventPlans.Remove(item);
            
            
            _ent.SaveChanges();

           
        }


        public List<EventType> GetEventPlanTypes()
        {
            var items = _ent.EventTypes.Where(p => p.IsEnabled == true).OrderBy(p => p.SortOrder).ToList();
            return items;
        }
    }
}
