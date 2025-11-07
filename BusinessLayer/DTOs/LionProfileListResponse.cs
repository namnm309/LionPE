using System.Collections.Generic;

namespace BusinessLayer.DTOs
{
    public class LionProfileListResponse
    {
        public List<LionProfileDTO> LionProfileList { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
    }
}


