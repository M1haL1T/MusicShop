using FluentValidation;
using MusicShop.Models;

namespace MusicShop.Validators;

public class BuyerValidator : AbstractValidator<Buyer>
{
    public BuyerValidator()
    {
        RuleFor(b => b.FullName)
            .NotEmpty().WithMessage("ФИО обязательно")
            .MaximumLength(150);

        RuleFor(b => b.Email)
            .NotEmpty().WithMessage("Email обязателен")
            .EmailAddress().WithMessage("Некорректный email")
            .MaximumLength(200);

        RuleFor(b => b.Phone).MaximumLength(30);
        RuleFor(b => b.DeliveryAddress).MaximumLength(500);
    }
}

public class OrderFormValidator : AbstractValidator<OrderFormData>
{
    public OrderFormValidator()
    {
        RuleFor(f => f.FullName).NotEmpty().MaximumLength(150);
        RuleFor(f => f.Email).NotEmpty().EmailAddress();
        RuleFor(f => f.ShipTo).NotEmpty().MaximumLength(500);
    }
}

public class OrderFormData
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string ShipTo { get; set; } = string.Empty;
}
