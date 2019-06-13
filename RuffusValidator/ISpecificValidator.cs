using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuffusValidator
{
    public interface ISpecificValidator
    {
        bool IsValid(object value);
    }
}
