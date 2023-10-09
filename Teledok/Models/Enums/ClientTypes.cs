using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Teledok.Models.Enums;

public enum ClientTypes
{
    [Display(Name = "ЮЛ")]
    JuridicalPerson,
    [Display(Name = "ИП")]
    IndividualEntrepreneur
    
}