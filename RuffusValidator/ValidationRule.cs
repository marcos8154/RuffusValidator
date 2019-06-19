using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuffusValidator
{
    public class ValidationRule
    {
        public Type Validator { get; private set; }
        public ValidationRuleType RuleType { get; private set; }
        public string Property { get; private set; }
        public object BaseCompareValue { get; private set; }
        public string Message { get; private set; }

        internal object Entity { get; private set; }

        internal void SetEntity(object entity)
        {
            Entity = entity;
        }

        public ValidationRule(ValidationRuleType type, string property,
            string message, object baseCompareValue = null)
        {
            RuleType = type;
            Property = property;
            Message = message;
            BaseCompareValue = baseCompareValue;
        }

        public ValidationRule(ValidationRuleType type, string property, string message, object baseCompareValue = null, Type validator = null)
        {
            RuleType = type;
            Property = property;
            Message = message;
            BaseCompareValue = baseCompareValue;
            Validator = validator;
        }
    }
}
