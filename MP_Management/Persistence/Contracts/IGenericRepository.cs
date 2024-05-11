namespace MP_Management.Persistence.Contracts
{
	public interface IGenericRepository<TEntity>: IAsyncDisposable where TEntity : class
	{
		Task<TEntity> GetEntityBYId(int Id);
		Task<IReadOnlyList<TEntity>> GetAllEntity();
		Task AddEntity(TEntity entity);
		Task UpdateEntity(TEntity entity);
		Task DeleteEntity(TEntity entity);
	}
}
