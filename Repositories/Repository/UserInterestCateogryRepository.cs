using Event.Models;
using Event.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Repositories.Repository
{
    public class UserInterestCateogryRepository:Repository<UserInterestCateogry>, IUserInterestCateogryRepository
    {
        private ApplicationDbContext db { get { return (ApplicationDbContext)this.Context; } }

        public UserInterestCateogryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}