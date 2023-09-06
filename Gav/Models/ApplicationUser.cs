using System.ComponentModel.DataAnnotations.Schema;
using Gav.Enums;
using Gav.Framework;
using Microsoft.AspNetCore.Identity;

namespace Gav.Models;

public class ApplicationUser : IdentityUser
{
    public string? Nome { get; private set; }
    public string? Sobrenome { get; private set; }
    public DateTime DataDeCriacao { get; private set; }
    public string Role { get; private set; }

    [NotMapped] public string Token { get; private set; }

    public ApplicationUser()
    {
        DataDeCriacao = DateTime.Now;
    }

    public ApplicationUser(string nome, string sobrenome, string role)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Role = role;

        DataDeCriacao = DateTime.Now;
    }

    public void SetToken(string token) => Token = token;
    public bool EhAdministrador() => Role.ToEnum<TipoRoles>() == TipoRoles.Administrador;
}