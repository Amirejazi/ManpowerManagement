using MpManagement.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpManagement.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthResponse authResponse);
        Task<RegisterationResponse> Register(RegisterationRequest registerationRequest);

    }
}
