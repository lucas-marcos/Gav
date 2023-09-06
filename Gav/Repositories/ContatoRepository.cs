using Gav.Data;
using Gav.Models;
using Gav.Repositories.Interfaces;

namespace Gav.Repositories;

public class ContatoRepository : Repository<Contato>, IContatoRepository
{
    public ContatoRepository(ApplicationDbContext context) : base(context)
    {
    }
}