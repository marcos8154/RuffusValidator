using System;
using System.Reflection;

namespace RuffusValidator
{
    internal class ValidationEngine
    {
        /// <summary>
        /// Validation Next Order:
        ///   ValidationRuleType:
        ///     1 - NOT_NULL
        ///     2 - NOT_EMPTY
        ///     3 - MIN (value)
        ///     4 - MAX (value)
        ///     5 - MIN_LENGTH
        ///     6 - MAX_LENGTH
        ///     7 - ESPECIFIC_METHOD
        /// </summary>
        private IValidator Validator { get; set; }
        internal ValidationEngine(ValidationRule rule,
            PropertyInfo property)
        {
            Validator = new NotNullValidation();
            Validator.Configure(rule, property);
        }

        internal void RunValidation()
        {
            Validator.Valid();
        }
    }
}
