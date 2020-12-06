using Event.Models;
using Event.Repositories.IRepository;
using Event.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            EventCategory = new EventCategoryRepository(context);

            Evaluation = new EvaluationRepository(context);

            UserInterestCateogry = new UserInterestCateogryRepository(context);
            UserParticipantsEventCateogry = new UserParticipantsEventRepository(context);
            Event = new EventRepository(context);

        }
        public IEventCategoryRepository EventCategory { get; private set; }

        public IEvaluationRepository Evaluation { get; private set; }

        public IUserInterestCateogryRepository UserInterestCateogry { get; private set; }
        public IUserParticipantsEventRepository UserParticipantsEventCateogry { get; private set; }

        public IEventRepository Event { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}