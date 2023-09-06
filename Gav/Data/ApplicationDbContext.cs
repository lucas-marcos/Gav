using System.Reflection;
using Gav.Models;
using Microsoft.EntityFrameworkCore;

namespace Gav.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Contato> Contatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Gav.db;");
    }
}