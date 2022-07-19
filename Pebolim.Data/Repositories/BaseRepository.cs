using Microsoft.EntityFrameworkCore;
using Pebolim.Data.Context;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PebolimDbContext _pebolimDbContext;

        public BaseRepository(PebolimDbContext pebolimDbContext)
        {
            _pebolimDbContext = pebolimDbContext;
        }

        public virtual async Task<bool> Insert(TEntity obj)
        {
            try
            {
                await _pebolimDbContext.Set<TEntity>().AddAsync(obj);
                _pebolimDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public virtual async Task<IList<TEntity>> Select()
        {
            var entities = await _pebolimDbContext.Set<TEntity>().ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity?> Select(int id)
        {
            try
            {
                var entity = await _pebolimDbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id == id);
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public virtual async Task<bool> Update(TEntity obj)
        {
            try
            {
                _pebolimDbContext.Entry(obj).State = EntityState.Modified;
                await _pebolimDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await Select(id);

                if (entity == null)
                    return false;

                _pebolimDbContext.Set<TEntity>().Remove(entity);
                _pebolimDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
