using Event.Models;
using Event.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Event.Controllers
{
    public class EventController : ApiController
    {
         ApplicationDbContext db;
        public EventController()
        {
            db = new ApplicationDbContext();
        }

        public IEnumerable<Models.Event> Get()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(db)) { return unitOfWork.Event.GetAll(); }
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

        public Models.Event Get(long id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(db)) { return unitOfWork.Event.Get(id); }
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
        public Models.Event Add(Models.Event model)
        {
            try
            {
                if (!ModelState.IsValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState));
                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    unitOfWork.Event.Add(model);
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
        public Models.Event Update(Models.Event model)
        {
            try
            {
                if (!ModelState.IsValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState));
                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    var @event = unitOfWork.Event.Get(model.id);
                    if (@event == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event Not Found"));

                    //TODO: Update Here 

                    unitOfWork.Complete();
                    return @event;

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
        public Models.Event Delete(long id)
        {
            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    var @event = unitOfWork.Event.Get(id);
                    if (@event == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event Not Found"));

                    //TODO: Delete  Here 
                    unitOfWork.Event.Remove(@event);
                    unitOfWork.Complete();

                    return @event;
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
        public Models.Event Close(long id)
        {
            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    var @event = unitOfWork.Event.Get(id);
                    if (@event == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event Not Found"));

                    //TODO: update  Here 
                    @event.closedAt = DateTime.Now;
                    unitOfWork.Complete();
                    return @event;
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
        public Models.Event Cancel(long id)
        {
            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    var @event = unitOfWork.Event.Get(id);
                    if (@event == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event Not Found"));

                    //TODO: update  Here 
                    @event.cancelAt = DateTime.Now;
                    unitOfWork.Complete();
                    return @event;
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
        [Route("event/:id/participate")]
        public Models.Event RegistarNewParticipant(long id,UserParticipantsEvent userParticipant)
        {
            try
            {
                if (!ModelState.IsValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState));

                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    var @event = unitOfWork.Event.Get(id);
                    if (@event == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event Not Found"));

                    unitOfWork.UserParticipantsEvent.Add(userParticipant);
                    unitOfWork.Complete();
                    return @event;
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
        [Route("event/:id/unparticipate")]
        public Models.UserParticipantsEvent Unparticipant(long id,string userId)
        {
            try
            {
 
                using (UnitOfWork unitOfWork = new UnitOfWork(db))
                {
                    var userParticipant = unitOfWork.UserParticipantsEvent.Find(e => e.eventId == id && e.userId == userId).FirstOrDefault();
                    if (userParticipant == null)
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Register before"));

                    unitOfWork.UserParticipantsEvent.Remove(userParticipant);
                    unitOfWork.Complete();
                    return userParticipant;
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
