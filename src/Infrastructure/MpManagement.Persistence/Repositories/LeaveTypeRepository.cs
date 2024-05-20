using MpManagement.Application.Contracts.Persistence;
using MpManagement.Domain;
using MpManagement.Persistence.Context;

namespace MpManagement.Persistence.Repositories
{
	public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypeRepository(MpMangementDbContext context) : base(context)
		{
		}
	}
}
