using AutoMapper;
using Gav.Models;
using Gav.Models.DTO;
using Gav.Models.TO;
using Gav.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gav.Controllers;

[ApiController, Route("api/contato")]
public class ContatoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IContatoServices _contatoServices;

    public ContatoController(IMapper mapper, IContatoServices contatoServices)
    {
        _mapper = mapper;
        _contatoServices = contatoServices;
    }

    [HttpPost]
    public ActionResult<ContatoTO> CriarContato(ContatoDTO contato)
    {
        var contatoCadastrado = _contatoServices.CadastrarContato(_mapper.Map<Contato>(contato));

        return Created(nameof(CriarContato), contatoCadastrado);
    }

    [HttpGet]
    public ActionResult<List<ContatoTO>> BuscarTodos()
    {
        var contatos = _contatoServices.BuscarTodos();

        return Ok(_mapper.Map<List<ContatoTO>>(contatos));
    }
}