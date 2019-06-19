using System.Reflection;

namespace RuffusValidator
{
    internal class NotEmptyValidator : IValidator
    {
        public IValidator NextValidator
        {
            get
            {
                IValidator next = new MinValueValidator();
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
            if (rule.RuleType == ValidationRuleType.NOT_EMPTY)
            {
                object value = property.GetValue(rule.Entity, null);

                if (string.IsNullOrEmpty(value.ToString()))
                    throw new RuffusValidationException(property.Name, rule.Message);
            }

            NextValidator.Valid();
        }
    }
}
