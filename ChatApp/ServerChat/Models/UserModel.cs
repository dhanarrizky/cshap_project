using System.ComponentModel.DataAnnotations;

namespace ServerChat;
public class UserModel
{
    [Required]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be at least (2), and maximum (1) characters")]
    public string Name { get; set; } = null!;
}
