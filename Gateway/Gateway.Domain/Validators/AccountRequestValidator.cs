using FluentValidation;
using Gateway.Domain.DTOs.Request;
using System.Text.RegularExpressions;

namespace Gateway.Domain.Validators
{
    public class AccountRequestValidator : AbstractValidator<AccountRequestDTO>
    {
        public AccountRequestValidator()
        {
            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Idade deve ser preenchida")
                .NotNull().WithMessage("Idade deve ser preenchida")
                .OverridePropertyName("Idade");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Email deve ser preenchido")
                .Must(p => Regex.IsMatch(p, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                    .WithMessage("Email está com o formato incorreto");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Nome deve ser ter no minimo 3 caracteres")

                .NotNull().WithMessage("Nome deve ser ter no minimo 3 caracteres")
                .MinimumLength(3)
                .WithMessage("Nome deve ser ter no minimo 3 caracteres");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Senha deve ser preenchida")
                .Equal(x => x.ConfirmPassword)
                    .WithMessage("Senhas devem ser iguais")
                .MinimumLength(6)
                    .WithMessage("Senha deve conter no minimo 6 caracteres")
                .Must(p => Regex.IsMatch(p, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z]).{6,}$"))
                    .WithMessage("Senha deve ter letras maiusculas, minusculas e numeros");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Confirmação de senha deve ser preenchida")
                .Equal(x => x.Password)
                    .WithMessage("Senhas devem ser iguais")
                .MinimumLength(6)
                    .WithMessage("Confirmação de senha deve conter no minimo 6 caracteres")
                .Must(p => Regex.IsMatch(p, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z]).{6,}$"))
                    .WithMessage("Senha deve ter letras maiusculas, minusculas, numeros e caracteres especiais EX: [!@#$%.]");
        }
    }
}
