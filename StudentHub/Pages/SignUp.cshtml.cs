using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentHub.Models;
using StudentHub.Services;

namespace StudentHub.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        private readonly ILogger<SignUpModel> _logger;

        public SignUpModel(ILogger<SignUpModel> logger)
        {
            _logger = logger;
        }

        public async void OnPostAsync()
        {
            var result = await SignUpAsync(User);
        }

        private async Task<bool> SignUpAsync(User user)
        {
            try
            {
                User.Password = Crypto.GetHash(User.Password);

                var isUserExists = await UserActions.IsUserExistsAsync(User);

                if (!isUserExists)
                {
                    await UserActions.AddUserAsync(User);
                    _logger.LogInformation("Successfull");

                    return true;
                }

                _logger.LogInformation("User already exists");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return false;
        }
    }
}
