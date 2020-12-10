using Event.Models;
using Event.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Services
{
    public class EventServices
    {
        ApplicationDbContext _db;

        public EventServices()
        {
            _db = new ApplicationDbContext();
        }

        // adding new event 
        public Models.Event CreateNewEvent( Models.Event @event)
        {
            using ( UnitOfWork unitOfWork = new UnitOfWork(_db))
            {
                unitOfWork.Event.Add(@event);
                unitOfWork.Complete();
                return @event;
            }
            
        }
    }
}