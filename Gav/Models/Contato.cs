using System.ComponentModel.DataAnnotations;

namespace Gav.Models;

public class Contato
{
    [Key] public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }

    public void SetNome(string nome) => Nome = nome;
    public void SetEmail(string email) => Email = email;
    public void SetTelefone(string telefone) => Telefone = telefone;
}