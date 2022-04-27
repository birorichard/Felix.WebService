using Felix.WebService.DTO.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Services.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<UserDTO>> GetAll(CancellationToken cancellationToken);
        Task Delete(int userId, CancellationToken cancellationToken);
        Task ChangePassword(ChangePasswordDTO dto, CancellationToken cancellationToken);
    }
}
