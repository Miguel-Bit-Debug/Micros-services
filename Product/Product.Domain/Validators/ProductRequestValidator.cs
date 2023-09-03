using FluentValidation;
using Product.Domain.DTOs.Request;

namespace Product.Domain.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequestDTO>
    {
        public ProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome do produto deve ser preenchido")
                .NotNull().WithMessage("Nome do produto deve ser preenchido")
                .MinimumLength(5).WithMessage("Produto deve ter no minimo 5 caracteres")
                .OverridePropertyName("Nome");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Descrição do produto deve ser preenchido")
                .NotNull().WithMessage("Descrição do produto deve ser preenchido")
                .MinimumLength(5).WithMessage("Descrição deve ter no minimo 5 caracteres")
                .OverridePropertyName("Descricao");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Preço do produto deve ser preenchido")
                .NotNull().WithMessage("Preço do produto deve ser preenchido")
                .OverridePropertyName("Preco");
        }
    }
}
