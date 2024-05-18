using Moq;
using MP_Management.Contracts.Persistence;
using MP_Management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.UnitTests.Mocks
{
	public static class MockLeaveRepository
	{
		public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
		{
			var leaveTypes = new List<LeaveType>()
			{
				new LeaveType{ 
					Id = 1,
					Name = "test Vacation",
					DefaultDay = 14},
				new LeaveType{
					Id = 2,
					Name = "test Sick",
					DefaultDay = 10},
			};

			var mockRepo = new Mock<ILeaveTypeRepository>();

			mockRepo.Setup(r => r.GetAllEntity()).ReturnsAsync(leaveTypes);

			// در این قسمت تعیین میکنیم که این تابع تنها این تایپ را میپذیرد It.IsAny<LeaveType>())
			mockRepo.Setup(r => r.AddEntity(It.IsAny<LeaveType>())).ReturnsAsync( (LeaveType leaveType) =>
			{
				leaveTypes.Add(leaveType);
				return leaveType;
			});

			return mockRepo;
		}
	}
}
