using Business.Abstractions.IO.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.User
{
    public class UserInsertInputValidator : AbstractValidator<UserInsertInput>
    {
        public UserInsertInputValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .MaximumLength(50).WithMessage("O nome do usuário deve ter no máximo 50 caracteres.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("O e-mail do usuário é obrigatório.")
                .EmailAddress().WithMessage("O e-mail do usuário não é válido.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("A senha do usuário é obrigatória.")
                .MinimumLength(6).WithMessage("A senha do usuário deve ter no mínimo 6 caracteres.");

            RuleFor(user => user.Role)
                .NotEmpty().WithMessage("O papel do usuário é obrigatório.");

        }
    }
}
