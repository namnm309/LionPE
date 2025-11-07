using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class LionProfileDTO
    {
        public int LionProfileId { get; set; }

        public int LionTypeId { get; set; }

        public string LionName { get; set; } 

        public double Weight { get; set; }

        public string Characteristics { get; set; }

        public string Warning { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual LionType LionType { get; set; } 
    }

}
