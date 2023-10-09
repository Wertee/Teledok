using System.ComponentModel.DataAnnotations;
using Teledok.Models.Enums;

namespace Teledok.Models;

public class Client
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string INN { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public ClientTypes ClientType { get; set; }
    [Required]
    public DateTime CreationDate { get; set; }
    [Required]
    public DateTime LastEditDate { get; set; }
    [Required]
    public HashSet<Founder> Founders { get; set; }
}