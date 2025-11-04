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

    public class LionProfileListResponse
    {
        public List<LionProfileDTO> LionProfileList { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
    }
}
