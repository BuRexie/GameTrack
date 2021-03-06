using System.ComponentModel.DataAnnotations;

namespace GameTrack.Dtos
{
  public class PlayerReadDto
  {
    public string PlayerId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
  }
}
