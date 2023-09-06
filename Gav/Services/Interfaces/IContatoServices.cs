using Gav.Models;

namespace Gav.Services.Interfaces;

public interface IContatoServices : IScoped
{
    Contato CadastrarContato(Contato contato);
    List<Contato> BuscarTodos();
    int RemoverContato(int id);
    Contato BuscarPorId(int id);
}