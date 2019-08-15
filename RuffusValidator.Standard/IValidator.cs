using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RuffusValidator.Standard
{
    interface IValidator
    {
        IValidator NextValidator { get; }

        void Configure(ValidationRule rule, PropertyInfo property);

        void Valid();
    }
}
