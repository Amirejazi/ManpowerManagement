using AutoMapper;
using Moq;
using MpManagement.Application.DTOs.LeaveType;
using MpManagement.Application.Features.LeaveTypes.Handlers.Queries;
using MpManagement.Application.Features.LeaveTypes.Requests.Queries;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Profile;
using MpManagement.UnitTests.Mocks;
using Shouldly;

namespace MpManagement.UnitTests.LeaveType.Queries
{
	public class GetLeaveTypeListHandlerTests
	{
		private IMapper _mapper;
		private Mock<ILeaveTypeRepository> _mockRepository;

        public GetLeaveTypeListHandlerTests()
        {
            _mockRepository = MockLeaveRepository.GetLeaveTypeRepository();

			var mapper = new MapperConfiguration(m =>
			{
				m.AddProfile<MappingProfile>();
			});
			_mapper = mapper.CreateMapper();
        }

		[Fact]
		public async Task GetLeaveTypeListHandlerTest()
		{
			var handler = new GetLeaveTypeListHandler(_mockRepository.Object, _mapper);
			var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

			result.ShouldBeOfType<List<LeaveTypeDTO>>();
			result.Count.ShouldBe(2);
		}
    }
}
