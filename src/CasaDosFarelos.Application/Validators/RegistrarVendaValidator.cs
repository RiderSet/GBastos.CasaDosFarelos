using FluentValidation;
using CasaDosFarelos.Application.Commands.Vendas;

namespace src.CasaDosFarelos.Application.Validators;

public class RegistrarVendaValidator : AbstractValidator<RegistrarVendaCommand>
{
    public RegistrarVendaValidator()
    {
        RuleFor(x => x.ClienteId).NotEmpty();
        RuleFor(x => x.ValorTotal).GreaterThan(0);
        RuleFor(x => x.DataVenda).NotEmpty();
    }
}