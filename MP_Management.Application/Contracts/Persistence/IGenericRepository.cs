﻿namespace MP_Management.Persistence.Contracts
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> GetQuery();
		Task<TEntity> GetEntityBYId(int id);
		Task<IReadOnlyList<TEntity>> GetAllEntity();
		Task<bool> ExistEntity(int id);
		Task<TEntity> AddEntity(TEntity entity);
		Task UpdateEntity(TEntity entity);
		Task DeleteEntity(TEntity entity);
	}
}
