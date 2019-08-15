using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuffusValidator.Standard
{
    public interface ISpecificValidator
    {
        bool IsValid(object value);
    }
}
