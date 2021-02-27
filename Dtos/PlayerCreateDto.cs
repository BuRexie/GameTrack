using System.ComponentModel.DataAnnotations;

namespace GameTrack.Dtos
{
  public class PlayerCreateDto
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
  }
}
