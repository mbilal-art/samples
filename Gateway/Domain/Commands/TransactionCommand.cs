using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class TransactionCommand : IRequest<TransactionCommandResult>
    {
        public long ProcessingCode { get; set; }
        public int SystemTraceNr { get; set; }
        public int FunctionCode { get; set; }
        public long CardNo { get; set; }
        public string CardHolder { get; set; }
        public int AmountTrxn { get; set; }
        public int CurrencyCode { get; set; }
    }

    public class TransactionCommandValidator : AbstractValidator<TransactionCommand>
    {
        public TransactionCommandValidator()
        {
            RuleFor(x => x.ProcessingCode).NotNull().NotEmpty();
            RuleFor(x => x.SystemTraceNr).NotNull().NotEmpty();
            RuleFor(x => x.FunctionCode).NotNull().NotEmpty();
            RuleFor(x => x.CardNo).NotNull().NotEmpty();
            RuleFor(x => x.CardHolder).NotNull().NotEmpty();
            RuleFor(x => x.AmountTrxn).NotNull().NotEmpty();
            RuleFor(x => x.CurrencyCode).NotNull().NotEmpty();
        }
    }
}
