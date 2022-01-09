
using System.ComponentModel.DataAnnotations;

namespace Fiorello.ViewModel.UserProfile
{
    public class UserProfileVM
    {
        [Required, MaxLength(100)]
        public string Fullname { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, MaxLength(255), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MaxLength(255), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required , MaxLength(255), DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
