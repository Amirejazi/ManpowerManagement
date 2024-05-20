using Microsoft.EntityFrameworkCore;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Persistence.Context;

namespace MpManagement.Persistence.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly MpMangementDbContext _context;
		public readonly DbSet<TEntity> _dbSet;

		public GenericRepository(MpMangementDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<TEntity>();
		}

		public IQueryable<TEntity> GetQuery()
		{
			return _dbSet.AsQueryable();
		}

		public async Task<TEntity> AddEntity(TEntity entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task DeleteEntity(TEntity entity)
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> ExistEntity(int id)
		{
			var entity = await GetEntityBYId(id);
			return entity != null;
		}

		public async Task<TEntity> GetEntityBYId(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<IReadOnlyList<TEntity>> GetAllEntity()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task UpdateEntity(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
