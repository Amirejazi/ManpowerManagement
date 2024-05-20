using AutoMapper;
using Moq;
using MP_Management.Application.DTOs.LeaveType;
using MP_Management.Application.Features.LeaveTypes.Handlers.Commands;
using MP_Management.Application.Features.LeaveTypes.Requests;
using MP_Management.Application.Features.LeaveTypes.Requests.Commands;
using MP_Management.Contracts.Persistence;
using MP_Management.Profile;
using MP_Management.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.UnitTests.LeaveType.Commands
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
