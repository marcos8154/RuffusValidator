using System.Reflection;

namespace RuffusValidator.Standard
{
    internal class MaxValueValidator : IValidator
    {
        public IValidator NextValidator
        {
            get
            {
                IValidator next = new MinLengthValidator();
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
                object value = property.GetValue(rule.Entity, null);
                decimal min = decimal.Parse(value.ToString());
                decimal minCompare = decimal.Parse(rule.BaseCompareValue.ToString());
                if (min < minCompare)
                    throw new RuffusValidationException(property.Name, rule.Message);
            }

            NextValidator.Valid();
        }
    }
}