using AutoMapper;
using Gav.Controllers.Filters;
using Gav.Enums;
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
    [CustomAuthorizationFilter(TipoRoles.Usuario)]
    public ActionResult<ContatoTO> CriarContato(ContatoDTO contato)
    {
        var contatoCadastrado = _contatoServices.CadastrarContato(_mapper.Map<Contato>(contato));

        return Created(nameof(CriarContato), contatoCadastrado);
    }

    [HttpGet]
    [CustomAuthorizationFilter(TipoRoles.Usuario)]
    public ActionResult<List<ContatoTO>> BuscarTodos()
    {
        var contatos = _contatoServices.BuscarTodos();

        return Ok(_mapper.Map<List<ContatoTO>>(contatos));
    }


    [HttpGet, Route("{id}")]
    [CustomAuthorizationFilter(TipoRoles.Usuario)]
    public ActionResult<Contato> BuscarPorId(int id)
    {
        var contato = _contatoServices.BuscarPorId(id);

        return Ok(_mapper.Map<ContatoTO>(contato));
    }

    [HttpDelete, Route("{id}")]
    [CustomAuthorizationFilter(TipoRoles.Administrador)]
    public ActionResult RemoverContato(int id)
    {
        var removido = _contatoServices.RemoverContato(id);

        return removido > 0 ? NoContent() : NotFound();
    }

    [HttpPut, Route("{id}")]
    [CustomAuthorizationFilter(TipoRoles.Usuario)]
    public ActionResult<ContatoTO> EditarContato(ContatoDTO contatoParaEditar, int id)
    {
        var contato = _contatoServices.EditarContato(_mapper.Map<Contato>(contatoParaEditar), id);

        return Ok(_mapper.Map<ContatoTO>(contato));
    }
}