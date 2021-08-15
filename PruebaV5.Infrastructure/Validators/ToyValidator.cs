using FluentValidation;
using PruebaV5.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Infrastructure.Validators
{
    public class ToyValidator : AbstractValidator<ToyDto>
    {
        public ToyValidator()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .Length(1,50);

            RuleFor(c => c.Description)
                .Length(1, 100);

            RuleFor(c => c.Company)
                .NotNull()
                .Length(1, 50);
        }
    }
}
