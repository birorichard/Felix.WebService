using AutoMapper;
using Felix.WebService.Common.Exceptions.Api;
using Felix.WebService.DAL;
using Felix.WebService.Data.Models.Identity;
using Felix.WebService.DTO.Authentication;
using Felix.WebService.Services.Extensions;
using Felix.WebService.Services.Interfaces;
using Felix.WebService.Validation;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(
            IMapper mapper, 
            UnitOfWork unitOfWork,
            ILogger<AuthenticationService> logger
            )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ClaimsPrincipal> Authenticate(LoginDTO dto, CancellationToken cancellationToken = default)
        {
            User user = await _unitOfWork.UserRepository.SingleOrDefaultAsync(filter: x => x.UserName == dto.UserName && !x.IsDeleted, cancellationToken: cancellationToken);

            if (user == null)
            {
                _logger.LogError($"User '{dto.UserName}' is not found!");
                throw new UnauthorizedException();
            }

            bool passwordIsValid = PasswordHandler.CheckPassword(user, dto.Password);
            if (!passwordIsValid)
            {
                _logger.LogError($"Password error for user '{dto.UserName}'!");
                throw new UnauthorizedException();
            }

            return await user.ToClaimsPrincipalAsync(cancellationToken);
        }

        public async Task Register(RegisterDTO dto, CancellationToken cancellationToken = default)
        {
            RegistrationValidator validator = new(_unitOfWork);
            validator.ValidateAndThrow(dto);

            User user = _mapper.Map<User>(dto);

            string salt = PasswordHandler.CreateRandomSalt();
            string hashedPassword = PasswordHandler.GetHashedPassword(salt, dto.Password);
            
            user.Salt = salt;
            user.Password = hashedPassword;

            _unitOfWork.UserRepository.Create(user);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
