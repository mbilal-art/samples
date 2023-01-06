using FluentValidation;
using MediatR;

namespace Application.Commands
{
    public class SendBulkSmsCommand : IRequest<SendBulkSmsCommandResult>
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class SendBulkSmsCommandValidator : AbstractValidator<SendBulkSmsCommand>
    {
        public SendBulkSmsCommandValidator()
        {
            RuleFor(x => x.To).Must(x => x != null || x.Any()).WithMessage("Atleast 1 Phone number is required.");
            RuleFor(x => x.Subject).NotEmpty().NotNull().WithMessage("Subject is required.");
            RuleFor(x => x.Body).NotEmpty().NotNull().MinimumLength(3).WithMessage("Body is empty or must be less than 3 characters.");
        }
    }
}
