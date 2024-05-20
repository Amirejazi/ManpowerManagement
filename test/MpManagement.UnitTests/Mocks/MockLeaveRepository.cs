using Moq;
using MpManagement.Application.Contracts.Persistence;

namespace MpManagement.UnitTests.Mocks
{
	public static class MockLeaveRepository
	{
		public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
		{
			var leaveTypes = new List<Domain.LeaveType>()
			{
				new Domain.LeaveType{
					Id = 1,
					Name = "test Vacation",
					DefaultDay = 14
				},
				new Domain.LeaveType{
					Id = 2,
					Name = "test Sick",
					DefaultDay = 10
				}
			};

			var mockRepo = new Mock<ILeaveTypeRepository>();

			mockRepo.Setup(r => r.GetAllEntity()).ReturnsAsync(leaveTypes);

			// در این قسمت تعیین میکنیم که این تابع تنها این تایپ را میپذیرد It.IsAny<LeaveType>())
			mockRepo.Setup(r => r.AddEntity(It.IsAny<Domain.LeaveType>())).ReturnsAsync((Domain.LeaveType leaveType) =>
			{
				leaveTypes.Add(leaveType);
				return leaveType;
			});

			mockRepo.Setup(r => r.DeleteEntity(It.IsAny<Domain.LeaveType>())).Returns((Domain.LeaveType leaveType) =>
			{
				leaveTypes.Remove(leaveType);
				return Task.CompletedTask;
			});

			mockRepo.Setup(r => r.GetEntityBYId(It.IsAny<int>())).ReturnsAsync((int id) =>
			{
				return leaveTypes.FirstOrDefault(l => l.Id == id);
			});

			return mockRepo; 
		}
	}
}
