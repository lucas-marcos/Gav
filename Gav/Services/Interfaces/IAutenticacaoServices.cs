using Gav.Models;

namespace Gav.Services.Interfaces;

public interface IAutenticacaoServices : IScoped
{
    ApplicationUser Autenticar(ApplicationUser usuario, string usuarioSenha);
    ApplicationUser CriarUsuario(ApplicationUser usuario, string usuarioSenha);
}