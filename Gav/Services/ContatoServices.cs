using Gav.Framework;
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

    public int RemoverContato(int id)
    {
        _contatoRepository.Remover(id);
        return _contatoRepository.Salvar();
    }

    public Contato BuscarPorId(int id)
    {
        return _contatoRepository.BuscarPorId(id);
    }

    public Contato EditarContato(Contato contatoParaEditar, int id)
    {
        var contato = _contatoRepository.BuscarPorId(id) ?? throw new GavException("Não foi possível encontrar o contato");

        contato.SetNome(contatoParaEditar.Nome);
        contato.SetEmail(contatoParaEditar.Email);
        contato.SetTelefone(contatoParaEditar.Telefone);

        _contatoRepository.AdicionarAtualizarSalvar(contato);

        return contato;
    }
}