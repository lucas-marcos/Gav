using Gav.Models;
using Gav.Services.Interfaces;

namespace Gav.Repositories.Interfaces;

public interface IContatoRepository : IRepository<Contato>, IScoped
{
}