using MpManagement.Web.Services.Client.Impeliments;

namespace MpManagement.Web.Services.Client.Interfaces
{
	[System.CodeDom.Compiler.GeneratedCode("NSwag", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
	public partial interface IClient
	{
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveAllocationDTO>> LeaveAllocationAllAsync();

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveAllocationDTO>> LeaveAllocationAllAsync(System.Threading.CancellationToken cancellationToken);

		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<BaseCommandResponse> LeaveAllocationPOSTAsync(CreateLeaveAllocationDTO body);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<BaseCommandResponse> LeaveAllocationPOSTAsync(CreateLeaveAllocationDTO body, System.Threading.CancellationToken cancellationToken);

		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<LeaveAllocationDTO> LeaveAllocationGETAsync(int id);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<LeaveAllocationDTO> LeaveAllocationGETAsync(int id, System.Threading.CancellationToken cancellationToken);

		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveAllocationPUTAsync(string id, UpdateLeaveAllocationDTO body);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveAllocationPUTAsync(string id, UpdateLeaveAllocationDTO body, System.Threading.CancellationToken cancellationToken);

		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveAllocationDELETEAsync(int id);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveAllocationDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveRequestDTO>> LeaveRequestAllAsync();

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveRequestDTO>> LeaveRequestAllAsync(System.Threading.CancellationToken cancellationToken);

		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<int> LeaveRequestPOSTAsync(CreateLeaveRequestDTO body);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<int> LeaveRequestPOSTAsync(CreateLeaveRequestDTO body, System.Threading.CancellationToken cancellationToken);

		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<LeaveRequestDTO> LeaveRequestGETAsync(int id);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<LeaveRequestDTO> LeaveRequestGETAsync(int id, System.Threading.CancellationToken cancellationToken);

		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveRequestPUTAsync(string id, UpdateLeaveRequestDTO body);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveRequestPUTAsync(string id, UpdateLeaveRequestDTO body, System.Threading.CancellationToken cancellationToken);

		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveRequestDELETEAsync(int id);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveRequestDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task ChangeApprvalAsync(int id, ChangeLeaveRequestApprovalDTO body);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task ChangeApprvalAsync(int id, ChangeLeaveRequestApprovalDTO body, System.Threading.CancellationToken cancellationToken);

		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveTypeDTO>> LeaveTypeAllAsync();

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<System.Collections.Generic.ICollection<LeaveTypeDTO>> LeaveTypeAllAsync(System.Threading.CancellationToken cancellationToken);

		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<BaseCommandResponse> LeaveTypePOSTAsync(CreateLeaveTypeDTO body);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<BaseCommandResponse> LeaveTypePOSTAsync(CreateLeaveTypeDTO body, System.Threading.CancellationToken cancellationToken);

		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<LeaveTypeDTO> LeaveTypeGETAsync(int id);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>Success</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task<LeaveTypeDTO> LeaveTypeGETAsync(int id, System.Threading.CancellationToken cancellationToken);

		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveTypePUTAsync(string id, UpdateLeaveTypeDTO body);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveTypePUTAsync(string id, UpdateLeaveTypeDTO body, System.Threading.CancellationToken cancellationToken);

		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveTypeDELETEAsync(int id);

		/// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
		/// <returns>No Content</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		System.Threading.Tasks.Task LeaveTypeDELETEAsync(int id, System.Threading.CancellationToken cancellationToken);

	}
}
