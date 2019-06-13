using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RuffusValidator
{
    public class Ruffus
    {
        private static object locker = new object();
        public void Valid(object entity)
        {
            CoreValidator cv = new CoreValidator();
            ValidationDomain domain = cv.GetDomainByEntityType(entity.GetType());

            foreach (ValidationRule rule in domain.Rules)
            {
                PropertyInfo property = entity.GetType().GetProperty(rule.Property);
                object value = property.GetValue(entity, null);

                switch (rule.RuleType)
                {
                    case ValidationRuleType.NOT_NULL:
                        if (value == null)
                            throw new Exception(rule.Message);
                        break;

                    case ValidationRuleType.NOT_EMPTY:
                        if (string.IsNullOrEmpty(value.ToString()))
                            throw new Exception(rule.Message);
                        break;

                    case ValidationRuleType.MIN:
                        decimal min = decimal.Parse(value.ToString());
                        decimal minCompare = decimal.Parse(rule.BaseCompareValue.ToString());
                        if (min < minCompare)
                            throw new Exception(rule.Message);
                        break;

                    case ValidationRuleType.MAX:
                        decimal max = decimal.Parse(value.ToString());
                        decimal maxCompare = decimal.Parse(rule.BaseCompareValue.ToString());
                        if (max > maxCompare)
                            throw new Exception(rule.Message);
                        break;

                    case ValidationRuleType.MIN_LENGTH:
                        string minStr = value.ToString();
                        int minStrCompare = int.Parse(rule.BaseCompareValue.ToString());
                        if (minStr.Length < minStrCompare)
                            throw new Exception(rule.Message);
                        break;

                    case ValidationRuleType.MAX_LENGTH:
                        string maxStr = value.ToString();
                        int maxStrCompare = int.Parse(rule.BaseCompareValue.ToString());
                        if (maxStr.Length > maxStrCompare)
                            throw new Exception(rule.Message);
                        break;

                    case ValidationRuleType.ESPECIFIC_METHOD:
                        ISpecificValidator validator = (ISpecificValidator)Activator.CreateInstance(rule.Validator);
                        bool valid = validator.IsValid(value);
                        if (!valid)
                            throw new Exception(rule.Message);
                        break;
                }
            }
        }
    }
}
