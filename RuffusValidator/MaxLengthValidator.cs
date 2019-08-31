using System;
using System.Reflection;

namespace RuffusValidator
{
    internal class MaxLengthValidator : IValidator
    {
        public IValidator NextValidator
        {
            get
            {
                throw new NotImplementedException("Nothing");
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
            object value = property.GetValue(rule.Entity, null);

            if (rule.RuleType == ValidationRuleType.MAX_LENGTH)
            {
                string minStr = value.ToString();
                int minStrCompare = int.Parse(rule.BaseCompareValue.ToString());
                if (minStr.Length < minStrCompare)
                    throw new RuffusValidationException(property.Name, rule.Message);
            }
            else if (rule.RuleType == ValidationRuleType.ESPECIFIC_METHOD)
                RunSpecificValidator(value);
        }

        private void RunSpecificValidator(object value)
        {
            if (rule.Validator != null)
            {
                ISpecificValidator validator = (ISpecificValidator)Activator.CreateInstance(rule.Validator);
                bool valid = validator.IsValid(value);
                if (!valid)
                    throw new RuffusValidationException(rule.Message);
            }
        }
    }
}