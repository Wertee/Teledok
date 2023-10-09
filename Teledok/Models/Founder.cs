using System.ComponentModel.DataAnnotations;

namespace Teledok.Models;

public class Founder
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(12,MinimumLength = 12,ErrorMessage = "ИНН физического лица должен быть строго 12 символов")]
    public string INN { get; set; }
    [Required]
    public string Fullname { get; set; }
    [Required]
    public DateTime CreationDate { get; set; }
    [Required]
    public DateTime EditDate { get; set; }
    public List<Client> Clients { get; set; }
}