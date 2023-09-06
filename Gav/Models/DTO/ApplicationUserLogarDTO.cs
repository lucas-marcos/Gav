using System.ComponentModel.DataAnnotations;

namespace Gav.Models.DTO;

public class ApplicationUserLogarDTO
{
    [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo 'Email' não é um endereço de email válido.")]
    public string Email { get; set; }
}