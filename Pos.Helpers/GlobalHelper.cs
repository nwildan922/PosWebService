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
                return true;
            }
            return false;
        }
        public static bool IsNullHelper(int data)
        {
            if (data != 0)
            {
                return true;
            }
            return false;
        }

    }
}
