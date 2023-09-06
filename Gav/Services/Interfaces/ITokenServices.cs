using Gav.Models;

namespace Gav.Services.Interfaces;

public interface ITokenServices : IScoped
{
    string GerarToken(ApplicationUser usuario);
}