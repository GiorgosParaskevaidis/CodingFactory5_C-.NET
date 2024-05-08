using FirstWebDBApp.DTO;
using FluentValidation;

namespace FirstWebDBApp.Validators
{
    public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateDTO>
    {

        public CustomerUpdateValidator()
        {
            RuleFor(c => c.Firstname)
                .NotEmpty()
                .WithMessage("To πεδίο δεν μπορεί να είναι κενό")
                .Length(2, 50)
                .WithMessage("To πεδίο πρέπει να είναι μεταξύ 2 και 50 χαρκτήρων");

            RuleFor(c => c.Lastname)
                .NotEmpty()
                .WithMessage("To πεδίο δεν μπορεί να είναι κενό")
                .Length(2, 50)
                .WithMessage("To πεδίο πρέπει να είναι μεταξύ 2 και 50 χαρκτήρων");

            RuleFor(c => c.Age)
                .NotEmpty()
                .WithMessage("To πεδίο δεν μπορεί να είναι κενό")
                .InclusiveBetween(18, 80)
                .WithMessage("Ηλικιες μεταξύ 18 και 80 χαρκτήρων");


            RuleFor(c => c.Region)
                .NotEmpty()
                .WithMessage("To πεδίο δεν μπορεί να είναι κενό")
                .Length(2, 50)
                .WithMessage("To πεδίο πρέπει να είναι μεταξύ 2 και 50 χαρκτήρων");
        }
    }
}
