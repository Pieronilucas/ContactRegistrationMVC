using System.ComponentModel.DataAnnotations;

namespace ContactRegistration.Enums;

public enum PerfilEnum
{
    [Display(Name = "Administrador")]
    ADMIN = 1,
    
    [Display(Name = "Padrão")]
    DEFAULT = 2
}