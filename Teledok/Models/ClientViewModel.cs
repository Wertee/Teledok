using System.ComponentModel.DataAnnotations;

namespace Teledok.Models;


public class ClientViewModel
{
    [Required(ErrorMessage = "ИНН обязателен к заполнению")]
    public string INN { get; set; }
    [MinLength(5)]
    [Required(ErrorMessage = "Наименование обязательно к заполнению")]
    public string Name { get; set; }
    [Required]
    public string CreationDate { get; set; }
    [Required]
    public string LastEditDate { get; set; }
    [Required]
    public int ClientType { get; set; }
    [Required(ErrorMessage = "Учредитель обязателен к заполнению")]
    public int[]? Founders { get; set; }
}

//