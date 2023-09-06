using System.ComponentModel.DataAnnotations;

namespace Gav.Models;

public class Contato
{
    [Key] public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
}