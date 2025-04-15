
using School_API.App.DTO;
using School_API.App.Interfaces;
using School_API.Core.Exceptions;
using School_API.Core.Models;
using School_API.Core.Security;
using School_API.Infrastructure.Security;

namespace School_API.App.Services 
{
    public class AuthService
    {
        private IUnitOfWork _unitOfWork;
        private IHashProvider _hashProvider;
        private ILogger _logger;
        private JwtProvider _jwtProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IUnitOfWork unitOfWork, IHashProvider hashProvider, JwtProvider jwtProvider, ILogger<AuthService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _hashProvider = hashProvider;
            _logger = logger;
            _jwtProvider = jwtProvider;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<LoginResponseDTO> Login(LoginDTO login)
        {
            User? user = await _unitOfWork.UserRepository.GetByEnrollment(login.Enrollment);

            if (user == null) throw new AuthenticationException("Invalid username or password");

            bool reply = _hashProvider.Verify(user.Salt!, user.Password!, login.Password);

            if (!reply) throw new AuthenticationException("Invalid username or password");
            
            CreateJwtDTO createJwt = new CreateJwtDTO
            {
                Id = user.Id,
                Role = user.Role!
            };

            string jwt = _jwtProvider.GenerateSecurityToken(createJwt);
            
            return new LoginResponseDTO{ 
                Token = jwt,  
                Role = user.Role!, 
            };
        }
    }
}