using Event.Models;
using Event.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Repositories.Repository
{
    public class UserParticipantsEventRepository :  Repository<UserParticipantsEvent> , IUserParticipantsEventRepository
    {

        private ApplicationDbContext db { get { return (ApplicationDbContext)this.Context; } }

        public UserParticipantsEventRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}