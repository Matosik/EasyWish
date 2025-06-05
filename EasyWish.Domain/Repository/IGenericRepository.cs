namespace EasyWish.Domain.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(object id);
    Task Create(TEntity entity);
    Task<bool> Delete(object id);
    Task Update(TEntity entity);
}