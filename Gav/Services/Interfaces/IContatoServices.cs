using Gav.Models;

namespace Gav.Services.Interfaces;

public interface IContatoServices : IScoped
{
    Contato CadastrarContato(Contato contato);
    List<Contato> BuscarTodos();
}