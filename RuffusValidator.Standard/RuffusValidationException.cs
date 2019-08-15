using System;

namespace RuffusValidator.Standard
{
    public class RuffusValidationException : Exception
    {
        public string PropertyName { get; private set; }

        internal RuffusValidationException(string property, string message)
            : base(message)
        {
            PropertyName = property;
        }

        public RuffusValidationException(string message) : base(message)
        {
            PropertyName = "NothingProperty";
        }
    }
}
