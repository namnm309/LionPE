using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LionPetManagement.Pages.LionProfile
{
    public class CreateModel : PageModel
    {
        private readonly LionProfileService _service;

        public CreateModel(LionProfileService service)
        {
            _service = service;
        }

        [BindProperty]
        public LionProfileDTO Form { get; set; } = new();

        public List<SelectListItem> LionTypeOptions { get; set; } = new();
        public string? Error { get; set; }

        public async Task OnGetAsync()
        {
            await LoadOptionsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _service.CreateAsync(Form);
                return RedirectToPage("/LionProfile/Index");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                await LoadOptionsAsync();
                return Page();
            }
        }

        private async Task LoadOptionsAsync()
        {
            var types = await _service.GetLionTypesAsync();
            LionTypeOptions = types.Select(t => new SelectListItem
            {
                Value = t.LionTypeId.ToString(),
                Text = t.LionTypeName
            }).ToList();
        }
    }
}
