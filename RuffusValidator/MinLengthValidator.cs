using System.Reflection;

namespace RuffusValidator
{
    internal class MinLengthValidator : IValidator
    {
        public IValidator NextValidator
        {
            get
            {
                IValidator next = new MaxLengthValidator();
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
            if (rule.RuleType == ValidationRuleType.MIN_LENGTH)
            {
                object value = property.GetValue(rule.Entity, null);
                string minStr = value.ToString();
                int minStrCompare = int.Parse(rule.BaseCompareValue.ToString());
                if (minStr.Length < minStrCompare)
                    throw new RuffusValidationException(property.Name, rule.Message);
            }

            NextValidator.Valid();
        }
    }
}