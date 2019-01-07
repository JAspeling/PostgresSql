using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.ErrorHandling;

namespace Test
{
    public static class Extensions
    {
        public static ExceptionObject Simplify(this Exception ex, string message = null, int code = 500) {
            var exceptionMessage = new ExceptionObject(ex, message);
            return exceptionMessage;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
