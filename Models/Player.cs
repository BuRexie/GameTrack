
using System;
using System.ComponentModel.DataAnnotations;

namespace GameTrack.Models
{
  public class Player
  {
    [Key]
    public int Id { get; set; }
    public string PlayerId { get; set; } = Guid.NewGuid().ToString();
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
  }
}
