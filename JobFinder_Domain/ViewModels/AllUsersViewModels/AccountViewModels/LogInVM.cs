using System.ComponentModel.DataAnnotations;

namespace JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.AccountViewModels
{
    public class LogInVM
    {
        [Required]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
