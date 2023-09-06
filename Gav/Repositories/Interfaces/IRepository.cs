namespace Gav.Repositories.Interfaces;

public interface IRepository<TEntity>
{
    /// <summary>
    /// Irá adicionar o objeto no em memória
    /// OBS: PRA SALVAR NO BANCO, CHAME O MÉTODO Salvar()
    /// </summary>
    public void Adicionar(TEntity obj);

    /// <summary>
    /// Irá atualizar o objeto no em memória
    /// OBS: PRA SALVAR NO BANCO, CHAME O MÉTODO Salvar()
    /// </summary>
    public void Atualizar(TEntity obj);

    public TEntity BuscarPorId(int id);
    public IQueryable<TEntity> BuscarTodos();
    public int Salvar();
    void Remover(int id);
    int AdicionarAtualizarSalvar(List<TEntity> objs);
    int AdicionarAtualizarSalvarAttached(TEntity obj);
    void AttachUpdate(TEntity obj);
    void AttachUpdate(List<TEntity> objs);
    void AttachAdd(TEntity obj);
    void AttachAdd(List<TEntity> objs);
    void Atualizar(List<TEntity> obj);
    void Adicionar(List<TEntity> obj);
    public int AdicionarAtualizarSalvar(TEntity obj);
    int RemoverSalvar(TEntity obj);
    int RemoverSalvar(List<TEntity> objs);
}