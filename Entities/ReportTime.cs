using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace creation_activities_ibang.Entities
{
    public class ReportTime
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int IdActivity { get; set; }


    }
}
