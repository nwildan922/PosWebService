using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Helpers
{
    public static class GlobalHelper
    {
        public static bool IsNullHelper(string data)
        {
            if (!string.IsNullOrEmpty(data) && !string.IsNullOrWhiteSpace(data))
            {
                return false;
            }
            return true;
        }
        public static bool IsNullHelper(int data)
        {
            if (data != 0)
            {
                return false;
            }
            return true;
        }

    }
}
