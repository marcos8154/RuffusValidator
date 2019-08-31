using System;
using System.Reflection;

namespace RuffusValidator
{
    internal class MinValueValidator : IValidator
    {
        public IValidator NextValidator
        {
            get
            {
                IValidator next = new MaxValueValidator();
                next.Configure(rule, property);
                return next;
            }
        }

        private ValidationRule rule;
        private PropertyInfo property;

        public void Configure(ValidationRule rule, PropertyInfo property)
        {
            this.rule = rule;
            this.property = property;
        }

        public void Valid()
        {
            if (rule.RuleType == ValidationRuleType.MIN)
            {
                decimal value = decimal.Parse( property.GetValue(rule.Entity, null).ToString());
                decimal minCompare = decimal.Parse(rule.BaseCompareValue.ToString());
                if (value < minCompare)
                    throw new RuffusValidationException(property.Name, rule.Message);
            }

            NextValidator.Valid();
        }
    }
}
