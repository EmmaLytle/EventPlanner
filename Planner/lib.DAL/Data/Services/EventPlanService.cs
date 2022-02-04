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

        #region EventPlan
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

        public void UpdateEventPlan(EventPlan eventPlan)
        {

            var item = _ent.EventPlans.FirstOrDefault(p => p.ID == eventPlan.ID);
            item.Title = eventPlan.Title;
            item.ModifiedDate = DateTime.UtcNow;
            item.Description = eventPlan.Description;
            item.EventTypeID = eventPlan.EventTypeID;

            _ent.SaveChanges();

        }

        public int InsertEventPlan(EventPlan eventPlan)
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

        public void DeleteEventPlan(int id)
        {
            //Calling the Stored procedure from DB Stored procedure is wrapped in transaction.
            //You could also use a transaction in entity framework
            //using (var dbContextTransaction = _ent.Database.BeginTransaction())
            //{
            //    try
            //    {
            //       //Do work here

            //        dbContextTransaction.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        dbContextTransaction.Rollback();
            //        throw;
            //    }
            //}


            _ent.EventPlan_Delete(id);

        }

        public List<EventType> GetEventPlanTypes()
        {
            var items = _ent.EventTypes.Where(p => p.IsEnabled == true).OrderBy(p => p.SortOrder).ToList();
            return items;
        }

        #endregion

        #region Invite
        public IQueryable<InviteSummary> GetInviteSummaries(int eventPlanID)
        {
            var items = _ent.InviteSummaries.Where(p => p.EventPlanID == eventPlanID);
            return items;
        }

        public int InsertInvite(Invite invite)
        {
            //If I recall we need to have an event item... or is it ok to just have an event plan..
            Invite inv = new Invite();
            inv.EventPlanID = invite.EventPlanID; //Get the current event plan we are on
            inv.Household = invite.Household; //GetName
            inv.HeadCountEstimate = invite.HeadCountEstimate;
            inv.HeadCountRSVP = invite.HeadCountRSVP;
            inv.RelationshipTypeID = invite.RelationshipTypeID;
         
            invite.ModifiedDate = DateTime.UtcNow;
            invite.CreatedDate = DateTime.UtcNow;
            _ent.Invites.Add(invite);

            _ent.SaveChanges();

            return invite.ID;


        }

        #endregion

        #region EventPlanItems
        public IQueryable<EventPlanItem> GetEventPlanItems(int eventPlanID)
        {
            var items = _ent.EventPlanItems.Where(p => p.EventPlanID == eventPlanID);
            return items;
        }

        #endregion

        #region MyRelationshipItems
      
        public List<RelationshipType> GetRelationshipType()
        {
            var items = _ent.RelationshipTypes.Where(p => p.IsEnabled == true).OrderBy(p => p.SortOrder).ToList();
            return items;
        }

        #endregion



    }
}
