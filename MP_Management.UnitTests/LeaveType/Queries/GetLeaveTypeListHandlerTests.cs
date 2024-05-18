using AutoMapper;
using Moq;
using MP_Management.Application.DTOs.LeaveType;
using MP_Management.Application.Features.LeaveTypes.Handlers.Queries;
using MP_Management.Application.Features.LeaveTypes.Requests.Queries;
using MP_Management.Contracts.Persistence;
using MP_Management.Profile;
using MP_Management.UnitTests.Mocks;
using Shouldly;

namespace MP_Management.UnitTests.LeaveType.Queries
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
