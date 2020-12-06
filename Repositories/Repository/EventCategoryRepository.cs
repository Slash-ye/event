using Event.Models;
using Event.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Repositories.Repository
{
    public class EventCategoryRepository : Repository<EventCategory>, IEventCategoryRepository
    {
        private   ApplicationDbContext db { get { return (ApplicationDbContext)this.Context; } }
        public EventCategoryRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}