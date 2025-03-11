using System.ComponentModel.DataAnnotations;
using WebStoryFroEveryting.SchoolAttributes.ValidationAttributes.AuthValidationAttributes;

namespace WebStoryFroEveryting.Models.SchoolAuth;

public class SchoolAuthViewModel
{
    [UniqueUsername]
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}