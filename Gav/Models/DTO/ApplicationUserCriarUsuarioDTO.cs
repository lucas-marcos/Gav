using System.ComponentModel.DataAnnotations;
using Gav.Enums;

namespace Gav.Models.DTO;

public class ApplicationUserCriarUsuarioDTO
{
    [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo 'Email' não é um endereço de email válido.")]
    public string Email { get; set; }

    [StringLength(50, ErrorMessage = "O campo 'Nome' deve ter no máximo 50 caracteres.")]
    public string? Nome { get; set; }

    [StringLength(50, ErrorMessage = "O campo 'Sobrenome' deve ter no máximo 50 caracteres.")]
    public string? Sobrenome { get; set; }

    [EnumDataType(typeof(TipoRoles), ErrorMessage = "'Role' inválida.")]
    public string? Role { get; set; }
}