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
    public class UserController : Controller
    {
        private readonly AppDbContext context;

        public UserController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return context.User.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            User user = context.User.FirstOrDefault(u => u.Id == id);
            return user;
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                context.User.Add(user);
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
        public ActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                if (user.Id == id)
                {
                    context.Entry(user).State = EntityState.Modified;
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
            User user = context.User.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                context.User.Remove(user);
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
