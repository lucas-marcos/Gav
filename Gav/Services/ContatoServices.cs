using Gav.Models;
using Gav.Repositories.Interfaces;
using Gav.Services.Interfaces;

namespace Gav.Services;

public class ContatoServices : IContatoServices
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoServices(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    public Contato CadastrarContato(Contato contato)
    {
        _contatoRepository.AdicionarAtualizarSalvar(contato);

        return contato;
    }

    public List<Contato> BuscarTodos()
    {
        return _contatoRepository.BuscarTodos().ToList();
    }
}