using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Event.Models;
using Event.Repositories.IRepository;

namespace Event.Repositories.Repository
{
    public class EvaluationRepository:Repository<Evaluation>, IEvaluationRepository
    {
        private ApplicationDbContext db { get { return (ApplicationDbContext)this.Context; } }

        public EvaluationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}