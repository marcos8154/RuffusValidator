using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuffusValidator.Standard
{
    public enum ValidationRuleType
    {
        NOT_NULL = 0,
        NOT_EMPTY = 1,
        MIN = 2,
        MAX = 3,
        ESPECIFIC_METHOD = 5,
        MIN_LENGTH = 6,
        MAX_LENGTH = 7
    }
}
