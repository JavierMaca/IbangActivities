using creation_activities_ibang.Contexts;
using creation_activities_ibang.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creation_activities_ibang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly AppDbContext context;

        public ActivityController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return context.Activity.ToList();
        }


        // GET user/IdUser
        [HttpGet("user/{IdUser}")]
        public IEnumerable<Activity> GetActivitiesUser(int IdUser)
        {
            List<Activity> activityUser = (from x in context.Activity where x.IdUser == IdUser select x).ToList();
            return activityUser;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            Activity activity = context.Activity.FirstOrDefault(a => a.Id == id);
            return activity;
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Activity activity)
        {
            try
            {
                context.Activity.Add(activity);
                context.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest("");
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Activity activity)
        {
            try
            {
                if (activity.Id == id)
                {
                    context.Entry(activity).State = EntityState.Modified;
                    context.SaveChanges();

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Activity activity = context.Activity.FirstOrDefault(a => a.Id == id);

            if (activity != null)
            {
                context.Activity.Remove(activity);
                context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
