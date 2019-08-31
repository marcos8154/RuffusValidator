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
            if (rule.RuleType == ValidationRuleType.MAX)
            {
                decimal value = decimal.Parse(property.GetValue(rule.Entity, null).ToString());
                decimal maxCompare = decimal.Parse(rule.BaseCompareValue.ToString());
                if (value > maxCompare)
                    throw new RuffusValidationException(property.Name, rule.Message);
            }

            NextValidator.Valid();
        }
    }
}