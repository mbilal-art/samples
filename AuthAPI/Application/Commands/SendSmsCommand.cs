using FluentValidation;
using MediatR;

namespace Application.Commands
{
    public class SendSmsCommand : IRequest<SendSmsCommandResult>
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class SendSmsCommandValidator : AbstractValidator<SendSmsCommand>
    {
        public SendSmsCommandValidator()
        {
            RuleFor(x => x.To).NotEmpty().NotNull().WithMessage("Phone number is required.");
            RuleFor(x => x.Subject).NotEmpty().NotNull().WithMessage("Subject is required.");
            RuleFor(x => x.Body).NotEmpty().NotNull().MinimumLength(3).WithMessage("Body is empty or must be less than 3 characters.");
        }
    }
}
