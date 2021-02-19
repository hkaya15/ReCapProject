using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(150000).When(c => c.BrandId == 1);
            RuleFor(c => c.ModelYear).Must(StartWith2).WithMessage("Araç Modeli En az 2000 olmalı");
        }

        private bool StartWith2(int arg)
        {
            return arg.ToString().StartsWith("2");
        }
    }
}
