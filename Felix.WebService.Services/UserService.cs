using AutoMapper;
using Felix.WebService.Common.Exceptions;
using Felix.WebService.Common.Exceptions.Auth;
using Felix.WebService.DAL;
using Felix.WebService.Data.Models.Identity;
using Felix.WebService.DTO.Identity;
using Felix.WebService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ChangePassword(ChangePasswordDTO dto, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(filter: x => x.UserName == dto.UserName && !x.IsDeleted, cancellationToken: cancellationToken);

            if (user == null)
                throw new PasswordChangingFailedException();

            if (PasswordHandler.GetHashedPassword(user.Salt, dto.OldPassword) != user.Password)
            {
                throw new PasswordChangingFailedException();
            }
            string salt = PasswordHandler.CreateRandomSalt();
            string hashedNewPassword = PasswordHandler.GetHashedPassword(salt, dto.NewPassword);

            user.Salt = salt;
            user.Password = hashedNewPassword;

            await _unitOfWork.SaveAsync(cancellationToken);
        }
            
        public async Task Delete(int userId, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.UserRepository.SingleOrDefaultAsync(
                filter: x => x.Id == userId && !x.IsDeleted, cancellationToken: cancellationToken
                );

            List<int> adminIds = (await _unitOfWork.UserRepository.GetAsync(x => x.IsAdmin && !x.IsDeleted)).Select(x => x.Id).ToList();
            
            if (await _unitOfWork.UserRepository.CountAsync(x => !x.IsDeleted && x.IsAdmin) <= 1 && adminIds.Contains(userId))
                throw new DeleteOperationForbiddenException("The last administrator account can not be deleted!");
            
            user.IsDeleted = true;

            await _unitOfWork.SaveAsync(cancellationToken);
        }

        public async Task<ICollection<UserDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetAsync(
                filter: x => !x.IsDeleted, cancellationToken: cancellationToken);

            var dtos = _mapper.Map<List<UserDTO>>(result);

            return dtos;
        }
            

    }
}
