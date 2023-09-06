using AutoMapper;
using Gav.Models;
using Gav.Models.DTO;
using Gav.Models.TO;
using Gav.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gav.Controllers;

[Route("api/autenticacao")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAutenticacaoServices _autenticacaoServices;

    public AutenticacaoController(IMapper mapper, IAutenticacaoServices autenticacaoServices)
    {
        _mapper = mapper;
        _autenticacaoServices = autenticacaoServices;
    }

    [HttpPost, Route("login")]
    public ActionResult<ApplicationUserTO> Login(ApplicationUserLogarDTO usuario)
    {
        var usuarioLogado = _autenticacaoServices.Autenticar(_mapper.Map<ApplicationUser>(usuario), usuario.Senha);

        Response.Cookies.Delete(".AspNetCore.Identity.Application");
        Response.Headers.Remove("Set-Cookie");

        return Ok(_mapper.Map<ApplicationUserTO>(usuarioLogado));
    }

    [HttpPost, Route("criar-usuario")]
    public ActionResult<ApplicationUserTO> CriarUsuario(ApplicationUserCriarUsuarioDTO usuario)
    {
        var usuarioCadastrado = _autenticacaoServices.CriarUsuario(_mapper.Map<ApplicationUser>(usuario), usuario.Senha);

        return Ok(_mapper.Map<ApplicationUserTO>(usuarioCadastrado));
    }
}