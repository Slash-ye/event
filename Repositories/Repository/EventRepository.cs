using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Event.Models;
 
using Event.Repositories.IRepository;

namespace Event.Repositories.Repository
{
    public class EventRepository: Repository<Event.Models.Event>, IEventRepository
    {
        private ApplicationDbContext db { get { return (ApplicationDbContext)this.Context; } }
        public EventRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}