using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).MaximumLength(16);
            RuleFor(u => u.Password).Matches(@"[A-Z]+");
            RuleFor(u => u.Password).Matches(@"[a-z]+");
            RuleFor(u => u.Password).Matches(@"[0-9]+");
            RuleFor(u => u.Password).Matches(@"[\!\?\*\.]+");
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            

        }
    }
}