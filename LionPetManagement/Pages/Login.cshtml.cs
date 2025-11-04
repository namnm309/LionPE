using BusinessLayer.DTOs;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LionPetManagement.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AuthService _services;
        private string userrole;

        public LoginModel(AuthService services)
        {
            _services = services;
        }

        //Map data từ form vào 
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        //Error nếu có 
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //check user có nhập ko nếu ko thì báo lỗi 
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Vui lòng nhập đầy đủ email và password!!!";
                return Page();
            }

            try
            {
                var loginRequest = new LoginRequest
                {
                    Email = Email,
                    Password = Password
                };

                LoginResponse account = await _services.LoginAsync(loginRequest);

                if (account != null)
                {
                    if (account.RoleId != 2 && account.RoleId != 3)
                    {
                        ErrorMessage = "Bạn ko có quìn truy cập @@@";
                        return Page();
                    }

                    //Nạp session
                    HttpContext.Session.SetString("UserId", account.RoleId.ToString());
                    HttpContext.Session.SetString("Email", account.Email.ToString());


                    if (account.RoleId == 2)
                    {
                        userrole = "Manager";

                    }
                    else if (account.RoleId == 3)
                    {
                        userrole = "Staff";

                    }
                    HttpContext.Session.SetString("UserRole", userrole);

                    return RedirectToPage("/LionProfile/Index");

                }
                else
                {
                    ErrorMessage = "Email or mk not right";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}
