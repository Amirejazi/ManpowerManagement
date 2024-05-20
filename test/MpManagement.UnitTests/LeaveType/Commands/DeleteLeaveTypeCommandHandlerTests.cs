using AutoMapper;
using Moq;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Application.DTOs.LeaveType;
using MpManagement.Application.Features.LeaveTypes.Handlers.Commands;
using MpManagement.Application.Features.LeaveTypes.Requests;
using MpManagement.Profile;
using MpManagement.UnitTests.Mocks;
using Shouldly;

namespace MpManagement.UnitTests.LeaveType.Commands
{
	public class DeleteLeaveTypeCommandHandlerTests
	{
		private IMapper _mapper;
		private Mock<ILeaveTypeRepository> _mockRepository;
		CreateLeaveTypeDTO _createLeaveDto;

		public DeleteLeaveTypeCommandHandlerTests()
		{
			_mockRepository = MockLeaveRepository.GetLeaveTypeRepository();

			var mapper = new MapperConfiguration(m =>
			{
				m.AddProfile<MappingProfile>();
			});
			_mapper = mapper.CreateMapper();

			_createLeaveDto = new CreateLeaveTypeDTO
			{
				Name = "Vacation",
				DefaultDay = 15
			};
		}

		[Fact]
		public async Task DeleteLeaveType()
		{
			var handler = new DeleteLeaveTypeCommandHandler(_mockRepository.Object, _mapper);
			var result = await handler.Handle(new DeleteLeaveTypeCommand() { Id = 2 }, CancellationToken.None);

			var leaveTypes = await _mockRepository.Object.GetAllEntity();

			leaveTypes.Count.ShouldBe(1);
		}
	}
}
