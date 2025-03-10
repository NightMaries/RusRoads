using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RusRoads.API.DTO;
using RusRoads.API.Entity;

namespace RusRoads.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventController (RusRoadsContext db, IMapper mapper): ControllerBase
    {
        [HttpGet ("{employeeId}")]
        
        public ActionResult<IEnumerable<EventDto>> getEmpEvent (int employeeId, bool oldEvents = false, bool currentEvents = true, bool futureEvents = true)
        {

            IEnumerable<Event> r = new List<Event>();

            IQueryable<Event> events = db.Event.Where(e => e.EmployeeId == employeeId).OrderByDescending(e => e.DateStart);

            IQueryable<Event> eventsOld = events.Where(e => e.DateEnd <= DateTime.Now.Date);
            IQueryable<Event> eventsCurrent = events.Where(e => e.DateStart <= DateTime.Now.Date && e.DateEnd > DateTime.Now.Date);
            IQueryable<Event> eventsFutures = events.Where(e => e.DateStart > DateTime.Now.Date);
            
            if(oldEvents && currentEvents && futureEvents) r = events.ToList();
            if(oldEvents && currentEvents && !futureEvents) r = eventsOld.Union(eventsCurrent).ToList();
            if(oldEvents && !currentEvents && futureEvents) r = eventsOld.Union(eventsFutures).ToList();
            if(!oldEvents && currentEvents && futureEvents) r = eventsCurrent.Union(eventsFutures).ToList();
            if(oldEvents && !currentEvents && !futureEvents) r = eventsOld.ToList();
            if(!oldEvents && currentEvents && !futureEvents) r = eventsCurrent.ToList();
            if(!oldEvents && !currentEvents && futureEvents) r = eventsFutures.ToList();
            
            
            var eventsDto = mapper.Map<IEnumerable<EventDto>>(r);
           
            return Ok(eventsDto);
        }
        [HttpPost]
        public ActionResult<EventDto> create(EventDto eventDto)
        {
            var events = mapper.Map<Event>(eventDto);

            try{
                db.Add(events);
                db.SaveChanges();
            }
            catch(Exception ex){
                return BadRequest($"{ex.InnerException?.Message}");
            }
            return Ok(eventDto);
        }
        [HttpDelete ("{eventId}")]
        public ActionResult<EventDto> Delete(int eventId)
        {
            var e = db.Event.Find(eventId);
            try{
                db.Remove(e);
                db.SaveChanges();
            }
            catch(Exception ex){
                return BadRequest($"{ex.InnerException?.Message}");
            }
            return Ok(e);
        }
            [HttpGet ("")]
        
        public ActionResult<IEnumerable<EventDto>> getAllEvents ()
        {

            var events = db.Event.ToList();   
            var eventsDto = mapper.Map<IEnumerable<EventDto>>(events);
           
            return Ok(eventsDto);
        }
    
    }
}