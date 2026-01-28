using FluentValidation;

public class AtualizarFornecedorPFCommandValidator : AbstractValidator<AtualizarFornecedorCommandPF>
{
    public AtualizarFornecedorPFCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome do fornecedor é obrigatório")
            .MaximumLength(100);
    }
}