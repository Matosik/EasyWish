using EasyWish.Domain;
using Microsoft.EntityFrameworkCore;
namespace EasyWish.Domain.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
{
    protected readonly EasyWishContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(EasyWishContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAll() => await _dbSet.ToListAsync();

    public async Task<TEntity> GetById(object id) => await _dbSet.FindAsync(id);

    public async Task Create(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(object id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}