using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuffusValidator
{
    public class ValidationDomain
    {
        public Type EntityType { get; private set; }
        public List<ValidationRule> Rules { get; private set; }

        public ValidationDomain(Type entityType)
        {
            EntityType = entityType;
            Rules = new List<ValidationRule>();
        }

        public ValidationDomain NotNull(string property, string message)
        {
            Rules.Add(new ValidationRule(ValidationRuleType.NOT_NULL, property, message, null, null));
            return this;
        }

        public ValidationDomain NotNullOrEmpty(string property, string message)
        {
            NotNull(property, message);
            NotEmpty(property, message);
            return this;
        }

        public ValidationDomain NotEmpty(string property, string message)
        {
            Rules.Add(new ValidationRule(ValidationRuleType.NOT_EMPTY, property, message, null, null));
            return this;
        }

        public ValidationDomain Min(string property, string message, decimal baseCompare)
        {
            Rules.Add(new ValidationRule(ValidationRuleType.MIN, property, message, baseCompare));
            return this;
        }

        public ValidationDomain Max(string property, string message, decimal baseCompare)
        {
            Rules.Add(new ValidationRule(ValidationRuleType.MAX, property, message, baseCompare));
            return this;
        }

        public ValidationDomain Equal(string property, string message, object baseCompare)
        {
            Rules.Add(new ValidationRule(ValidationRuleType.MIN_LENGTH, property, message, baseCompare));
            return this;
        }

        public ValidationDomain EspecificMethod(string property, Type validator, string message)
        {
            Rules.Add(new ValidationRule(ValidationRuleType.ESPECIFIC_METHOD, property, message, null, validator));
            return this;
        }

        public ValidationDomain MinLength(string property, string message, object baseCompare)
        {
            Rules.Add(new ValidationRule(ValidationRuleType.MIN_LENGTH, property, message, baseCompare));
            return this;
        }

        public ValidationDomain MaxLength(string property, string message, object baseCompare)
        {
            Rules.Add(new ValidationRule(ValidationRuleType.MAX_LENGTH, property, message, baseCompare));
            return this;
        }
    }
}
