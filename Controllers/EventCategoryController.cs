using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
 using Event.Models;
using Event.Repositories;

namespace Event.Controllers
{
    public class EventCategoryController : ApiController
    {
        ApplicationDbContext db;
        public EventCategoryController()
        {
            db = new ApplicationDbContext();
        }

        public IEnumerable<EventCategory> Get()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(db)) { return unitOfWork.EventCategory.GetAll(); }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                //this catch is for unexpected error  
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }

        }

        public EventCategory Get(long id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(db)) { return unitOfWork.EventCategory.Get(id); }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                //this catch is for unexpected error  
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }

        }

        [HttpPost]
        public EventCategory Add(EventCategory model)
        {
            try
            {
                if (!ModelState.IsValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState));
                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    unitOfWork.EventCategory.Add(model);
                    unitOfWork.Complete();
                    return model;

                }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                //this catch is for unexpected error  
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }

        }


        [HttpPut]
        public EventCategory Update(EventCategory model)
        {
            try
            {
                if (!ModelState.IsValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState));
                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    var eventCategory = unitOfWork.EventCategory.Get(model.id);
                    if (eventCategory == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event Category Not Found"));

                    //TODO: Update Here 

                    return eventCategory;

                }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                //this catch is for unexpected error  
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }

        }

        [HttpDelete]
        public EventCategory Delete(long id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    var eventCategory = unitOfWork.EventCategory.Get(id);
                    if (eventCategory == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event Category Not Found"));

                    //TODO: Delete  Here 
                    unitOfWork.EventCategory.Remove(eventCategory);
                    return eventCategory;
                }
            }
            catch (HttpResponseException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                //this catch is for unexpected error  
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }

        }

    }
}
