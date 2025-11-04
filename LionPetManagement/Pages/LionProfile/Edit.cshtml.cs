using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LionPetManagement.Pages.LionProfile
{
    public class EditModel : PageModel
    {
        private readonly LionProfileService _service;

        public EditModel(LionProfileService service)
        {
            _service = service;
        }

        [BindProperty]
        public LionProfileDTO Form { get; set; } = new();

        public List<SelectListItem> LionTypeOptions { get; set; } = new();
        public string? Error { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return RedirectToPage("/LionProfile/Index");
            Form = item;
            await LoadOptionsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _service.UpdateAsync(Form);
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
