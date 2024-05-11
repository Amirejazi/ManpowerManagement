namespace MP_Management.Persistence.Contracts
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		Task<TEntity> GetEntityBYId(int Id);
		Task<IReadOnlyList<TEntity>> GetAllEntity();
		Task<bool> ExistEntity(int Id);
		Task AddEntity(TEntity entity);
		void UpdateEntity(TEntity entity);
		Task DeleteEntity(TEntity entity);
	}
}
