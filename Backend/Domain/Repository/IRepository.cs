namespace Domain.Repository;

public interface IRepository<TEntity, TKey>
{
    TEntity GetById(TKey id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TKey id);
}
