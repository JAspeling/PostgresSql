using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ErrorHandling {
    public class ExceptionObject {
        public ExceptionObject(Exception ex, string message = null) {
            this.Message = message;
            Error = ex.Message;
            if (ex.InnerException != null) {
                InnerException = new ExceptionObject(ex.InnerException);
            }
        }

        public bool ShouldSerializeMessage() {
            return Message != null && Message != "";
        }

        public bool ShouldSerializeInnerException() {
            return InnerException != null;
        }

        public string Message { get; set; } = null;
        public string Error { get; set; }
        public ExceptionObject InnerException { get; set; }
    }
}
