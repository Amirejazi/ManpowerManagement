using AutoMapper;
using Hanssens.Net;
using MpManagement.Web.Contracts;
using MpManagement.Web.Services.Base;
using MpManagement.Web.Services.Client.Impeliments;
using MpManagement.Web.Services.Client.Interfaces;
using MpManagement.Web.ViewModels.LeaveTypes;

namespace MpManagement.Web.Services
{
	public class LeaveTypeService : BaseHttpService, ILeaveTypeService
	{
		private readonly IMapper _mapper;
		private readonly IClient _client;

		public LeaveTypeService(IMapper mapper, IClient client, ILocalStorage localStorage) : base(client, localStorage)
		{
			_mapper = mapper;
			_client = client;
		}

		public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
		{
			try
			{
				var response = new Response<int>();
				CreateLeaveTypeDTO createLeaveType = _mapper.Map<CreateLeaveTypeDTO>(leaveType);
				var apiResponse = await _client.LeaveTypePOSTAsync(createLeaveType);
				if (apiResponse.Success)
				{
					response.Data = apiResponse.Id;
					response.Success = true;
				}
				else
				{
					foreach (var err in apiResponse.Errors)
					{
						response.ValidationErrors += err + Environment.NewLine;
					}
				}
				return response;
			}
			catch (ApiException ex)
			{
				return ConvertApiException<int>(ex);
			}
		}

		public async Task<Response<int>> DeleteLeaveType(int id)
		{
			try
			{
				await _client.LeaveTypeDELETEAsync(id);
				return new Response<int> { Success = true };
			}
			catch (ApiException ex)
			{
				return ConvertApiException<int>(ex);
			}
		}

		public async Task<LeaveTypeVM> GetLeaveType(int id)
		{
			var leaveType = await _client.LeaveTypeGETAsync(id);
			return _mapper.Map<LeaveTypeVM>(leaveType);
		}

		public async Task<List<LeaveTypeVM>> GetLeaveTypes()
		{
			var leaveTypes = await _client.LeaveTypeAllAsync();
			return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
		}

		public async Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
		{
			try
			{
				leaveType.Id = id;
				var leaveTypeDto = _mapper.Map<UpdateLeaveTypeDTO>(leaveType);
				await _client.LeaveTypePUTAsync(id.ToString(), leaveTypeDto);
				return new Response<int> { Success = true };
			}
			catch (ApiException ex)
			{
				return ConvertApiException<int>(ex);
			}

		}
	}
}
