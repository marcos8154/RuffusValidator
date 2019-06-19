using System.Reflection;

namespace RuffusValidator
{
    internal class NotNullValidation : IValidator
    {
        private ValidationRule rule;
        private PropertyInfo property;

        public IValidator NextValidator
        {
            get
            {
                IValidator next = new NotEmptyValidator();
                next.Configure(rule, property);
                return next;
            }
        }

        public void Configure(ValidationRule rule, PropertyInfo property)
        {
            this.rule = rule;
            this.property = property;
        }

        public void Valid()
        {
            if (rule.RuleType == ValidationRuleType.NOT_NULL)
            {
                object value = property.GetValue(rule.Entity, null);
                if (value == null)
                    throw new RuffusValidationException(property.Name, rule.Message);
            }

            NextValidator.Valid();
        }
    }
}
