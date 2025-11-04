using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using LionPetManagement.Hubs;

namespace LionPetManagement.Pages.LionProfile
{
    public class IndexModel : PageModel
    {
        private readonly LionProfileService _services;
        private readonly IHubContext<LionHub> _hubContext;

        public IndexModel(LionProfileService services, IHubContext<LionHub> hubContext)
        {
            _services = services;
            _hubContext = hubContext;
        }

        public LionProfileListResponse LionProfileData { get; set; } = new();
        [BindProperty(SupportsGet = true)] public int PageIndex { get; set; } = 1;
        [BindProperty(SupportsGet = true)] public double? Weight { get; set; }
        [BindProperty(SupportsGet = true)] public string? LionTypeName { get; set; }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            PageIndex = pageIndex;
            if (Weight.HasValue || !string.IsNullOrWhiteSpace(LionTypeName))
            {
                LionProfileData = await _services.SearchPagingAsync(PageIndex, 3, Weight, LionTypeName);
            }
            else
            {
                LionProfileData = await _services.GetAllWithSupplierPagingAsync(PageIndex, 3);
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _services.DeleteAsync(id);
            await _hubContext.Clients.All.SendAsync("Deleted");
            return RedirectToPage("/LionProfile/Index", new { pageIndex = 1 });
        }
    }
}
