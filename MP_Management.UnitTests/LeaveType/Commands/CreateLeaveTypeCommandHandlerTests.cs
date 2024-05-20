using AutoMapper;
using Moq;
using MP_Management.Application.DTOs.LeaveType;
using MP_Management.Application.Features.LeaveTypes.Handlers.Commands;
using MP_Management.Application.Features.LeaveTypes.Requests.Commands;
using MP_Management.Application.Responses;
using MP_Management.Contracts.Persistence;
using MP_Management.Profile;
using MP_Management.UnitTests.Mocks;
using Shouldly;

namespace MP_Management.UnitTests.LeaveType.Commands
{
	public class CreateLeaveTypeCommandHandlerTests
	{
		private IMapper _mapper;
		private Mock<ILeaveTypeRepository> _mockRepository;
		CreateLeaveTypeDTO _createLeaveDto;

		public CreateLeaveTypeCommandHandlerTests()
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
		public async Task CreateLeaveType()
		{
			var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object, _mapper);
			var result = await handler.Handle(new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _createLeaveDto }, CancellationToken.None);

			result.ShouldBeOfType<BaseCommandResponse>();

			var leaveTypes = await _mockRepository.Object.GetAllEntity();

			leaveTypes.Count.ShouldBe(3);

		}
	}
}
