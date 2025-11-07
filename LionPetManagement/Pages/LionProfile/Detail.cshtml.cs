using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LionPetManagement.Pages.LionProfile
{
    public class DetailModel : PageModel
    {
        private readonly LionProfileService _service;

        public DetailModel(LionProfileService service)
        {
            _service = service;
        }

        public LionProfileDTO? Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Item = await _service.GetByIdAsync(id);
            if (Item == null) return RedirectToPage("/LionProfile/Index");
            return Page();
        }
    }
}


