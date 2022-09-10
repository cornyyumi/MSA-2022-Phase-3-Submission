using FluentValidation;
using MSA_Phase_3.Domain.Models;
using MSA_Phase_3.Service.Services;
namespace MSA_Phase_3.API.Validators
{
    public class RegisterValidator : AbstractValidator<UserLogin>
    {
        private readonly ITextFilterService _textFilter = new TextFilterService();
        public RegisterValidator()
        {
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.UserName).Custom((name, context) =>
            {
                if (_textFilter.ContainsProfanity(name))
                {
                    context.AddFailure("Username contains profanity");
                }
            });
            RuleFor(u => u.UserName).Length(0, 20);
            RuleFor(u => u.Password).Length(0, 20);
        }
    }
}
