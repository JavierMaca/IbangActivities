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
public class ReportTimeController : ControllerBase
{
        
    private readonly AppDbContext context;

    public ReportTimeController(AppDbContext context)
    {
        this.context = context;
    }

    // GET: api/values
    [HttpGet]
    public IEnumerable<ReportTime> Get()
    {
        return context.ReportTime.ToList();
    }
     
    [HttpGet("reporttime/{IdActivity}")]
    public IEnumerable<ReportTime> GetReportTimeForActivity(int IdActivity)
    {
        List<ReportTime> listReportTime = (from x in context.ReportTime where x.IdActivity == IdActivity select x).ToList();
        return listReportTime;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ReportTime Get(int id)
    {
        ReportTime reportTime = context.ReportTime.FirstOrDefault(a => a.Id == id);
        return reportTime;
    }

    // POST api/values
    [HttpPost]
    public ActionResult Post([FromBody] ReportTime reportTime)
    {
        try
        {
            context.ReportTime.Add(reportTime);
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
    public ActionResult Put(int id, [FromBody] ReportTime reportTime)
    {
        try
        {
            if (reportTime.Id == id)
            {
                context.Entry(reportTime).State = EntityState.Modified;
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
            ReportTime reportTime = context.ReportTime.FirstOrDefault(a => a.Id == id);

        if (reportTime != null)
        {
            context.ReportTime.Remove(reportTime);
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

