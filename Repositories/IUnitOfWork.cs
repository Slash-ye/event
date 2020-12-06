using Event.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        IEventCategoryRepository EventCategory { get; }
        IEvaluationRepository Evaluation { get; }
        IUserInterestCateogryRepository UserInterestCateogry { get; }
        IUserParticipantsEventRepository UserParticipantsEventCateogry { get; }
        IEventRepository Event{ get; }

        int Complete();


    }
}