using Gav.Data;
using Gav.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gav.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected ApplicationDbContext Db;
    protected readonly DbSet<TEntity> DbSet;
    
    protected Repository(ApplicationDbContext context)
    {
        Db = context;
        DbSet = Db.Set<TEntity>();
    }
    public void Adicionar(TEntity obj)
    {
        if (obj == null)
            return;

        DbSet.Add(obj);
    }
    public void Adicionar(List<TEntity> obj)
    {
        if (obj == null || obj.Count == 0)
            return;

        DbSet.AddRange(obj);
    }

    public void Atualizar(TEntity obj)
    {
        if (obj == null)
            return;

        DbSet.Update(obj);
    }
    public void Atualizar(List<TEntity> obj)
    {
        if (obj == null || obj.Count == 0)
            return;

        DbSet.UpdateRange(obj);
    }
    public void Remover(int id)
    {
        DbSet.Remove(DbSet.Find(id));
    }
    public virtual TEntity BuscarPorId(int id)
    {
        return DbSet.Find(id);
    }
    public IQueryable<TEntity> BuscarTodos()
    {
        return DbSet;
    }
    public int Salvar()
    {
        return Db.SaveChanges();
    }
    public int AdicionarAtualizarSalvar(List<TEntity> objs)
    {
        var objsInDb = new List<TEntity>();
        var objsNew = new List<TEntity>();
        foreach (var obj in objs)
        {
            var objId = obj.GetType().GetProperty("Id")?.GetValue(obj);
            if (objId != null && DbSet.Find(objId) != null)
                objsInDb.Add(obj);
            else
                objsNew.Add(obj);
        }

        Atualizar(objsInDb);
        Adicionar(objsNew);
        return Salvar();
    }
    public int AdicionarAtualizarSalvar(TEntity obj)
    {
        if (obj is null) return 0;

        var objId = obj.GetType().GetProperty("Id")?.GetValue(obj);
        if (objId != null && DbSet.Find(objId) != null)
            Atualizar(obj);
        else
            Adicionar(obj);

        return Salvar();
    }
    public int AdicionarAtualizarSalvarAttached(TEntity obj)
    {
        if (obj is null) return 0;

        var objId = obj.GetType().GetProperty("Id")?.GetValue(obj);
        if (objId != null && DbSet.Find(objId) != null)
            AttachUpdate(obj);
        else
            AttachAdd(obj);

        return Salvar();
    }
    public void AttachUpdate(TEntity obj)
    {
        if (obj == null)
            return;

        DbSet.AsNoTracking().Append(obj);
        Db.Entry(obj).State = EntityState.Modified;
    }
    public void AttachUpdate(List<TEntity> objs)
    {
        foreach (var obj in objs)
        {
            AttachUpdate(obj);
        }
    }
    public void AttachAdd(TEntity obj)
    {
        if (obj == null)
            return;

        DbSet.AsNoTracking().Append(obj);
        Db.Entry(obj).State = EntityState.Added;
    }
    public void AttachAdd(List<TEntity> objs)
    {
        foreach (var obj in objs)
        {
            AttachAdd(obj);
        }
    }
    public int RemoverSalvar(TEntity obj)
    {
        if (obj == null)
            return 0;

        DbSet.Remove(obj);
        return Salvar();
    }
    public int RemoverSalvar(List<TEntity> objs)
    {
        if (!objs.Any())
            return 0;

        DbSet.RemoveRange(objs);
        return Salvar();
    }
}