using Business.Abstractions.IO.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.User
{
    public class UserUpdateInputValidator : AbstractValidator<UserUpdateInput>
    {
        public UserUpdateInputValidator()
        {
            RuleFor(user => user.IdUser)
                       .NotEmpty().WithMessage("O identificador do usuario é obrigatório.")
                       .GreaterThanOrEqualTo(1).WithMessage("O identificador do usuario deve ser maior ou igual a 1.");
        }
    }
}
