using Authentication_Login.Dtos.Users;
using Authentication_Login.Models;
using Authentication_Login.Repository.Abstract;
using FluentValidation;

namespace Authentication_Login.Validation
{
    public class AuthenticationUserValidator : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .Must(ValidateUserName)
                .WithMessage("Field userName can not be null o empty");
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Field password can not be empty");
            RuleFor(x => x.EmailAddress).NotNull().NotEmpty().EmailAddress()
            .WithMessage("Field email can not be null o empty");
        }

        bool ValidateUserName(string users)
        {
            if (_userRepository.validateUserName(users))
            {
                return true;
            }
            return false;
        }
    }
        
}
