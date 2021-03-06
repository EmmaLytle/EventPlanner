//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lib.DAL.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EventPlan> EventPlans { get; set; }
        public virtual DbSet<EventPlanSummary> EventPlanSummaries { get; set; }
        public virtual DbSet<EventPlanItem> EventPlanItems { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Invite> Invites { get; set; }
        public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
        public virtual DbSet<InviteSummary> InviteSummaries { get; set; }
    
        public virtual int EventPlan_Delete(Nullable<int> eventPlanID)
        {
            var eventPlanIDParameter = eventPlanID.HasValue ?
                new ObjectParameter("EventPlanID", eventPlanID) :
                new ObjectParameter("EventPlanID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EventPlan_Delete", eventPlanIDParameter);
        }
    }
}
