using Felix.WebService.Common.Exceptions.Auth;
using Felix.WebService.DAL;
using Felix.WebService.DTO.Authentication;

using FluentValidation;

namespace Felix.WebService.Validation
{
    public class RegistrationValidator : AbstractValidator<RegisterDTO>
    {
        private const string _userNameErrorMessage = "Please choose a username!";
        private const string _passwordsAreNotEqual = "The passwords do not match!";

        public RegistrationValidator(UnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserName).NotNull()
                                    .NotEmpty()
                                    .WithMessage(_userNameErrorMessage)
                                    .CustomAsync(async (userName, context, cancellationToken) =>
                                    {
                                        if (!(await unitOfWork.UserRepository.IsUserNameUnique(userName, cancellationToken)))
                                            throw new UserAlreadyExistsException();
                                    })
                                    ;

            RuleFor(x => x.Password).NotNull()
                                    .NotEmpty()
                                    .Equal(y => y.PasswordRepeat)
                                    .WithMessage(_passwordsAreNotEqual)
                                    ;
        }
    }
}
