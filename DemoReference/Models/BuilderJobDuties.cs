using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReference.Models
{
    public class BuilderJobDuties
    {
        public int Id { get; set; }
        public int BuilderId { get; set; }
        public int JobDutiesId { get; set; }
        public int UserId { get; set; }

        public Builder Builder { get; set; }

        public JobDuties JobDuties { get; set; }

        public User User { get; set; }
    }
}
