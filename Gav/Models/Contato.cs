using System.ComponentModel.DataAnnotations;

namespace Gav.Models;

public class Contato
{
    [Key] public int Id { get; set; }
    public string Nome { get; set; }
}