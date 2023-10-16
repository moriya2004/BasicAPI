using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
         private static List<Event> events = new List<Event> { 
            new Event { Id = 1, title = "default event1", start = DateTime.Now },
            new Event { Id = 2, title = "default event2", start = DateTime.Now }
        };
        static int cnt = 3;


        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events; ;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
        {
            //TODO add event

            Event newEvent = new Event { Id = cnt, title = eve.title , start=eve.start};
            events.Add(newEvent);
            cnt++;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event ev)
        {
            var eve = events.Find(e => e.Id == id);
            if (eve != null)
            {
                eve.title = ev.title;
                
            }
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
            public void Delete(int id)
            {
                var eve = events.Find(e => e.Id == id);
                if (eve != null) { 
                    events.Remove(eve);
                    cnt--;
                }
            }
        }
}
