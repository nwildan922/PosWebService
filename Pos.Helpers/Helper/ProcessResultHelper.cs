using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Helpers.Helper
{
    public static class ProcessResultHelper
    {
        private static ProcessResult _result;
        public static ProcessResult Set(bool status, string msg)
        {
            _result = new ProcessResult();
            _result.isSucceed = status;
            _result.message = msg;
            return _result;
        }
        public static ProcessResult Set(bool status, string msg, object returnvalue)
        {
            _result = new ProcessResult();
            _result.isSucceed = status;
            _result.message = msg;
            _result.ReturnValue = returnvalue;
            return _result;
        }
    }
}
