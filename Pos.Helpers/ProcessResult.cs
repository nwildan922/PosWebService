using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Helpers
{
    public class ProcessResult
    {
        public System.Collections.Generic.Dictionary<string, object> CustomField
        {
            get;
            set;
        }
        public Object ReturnValue
        {
            get;
            set;
        }
        public bool isSucceed
        {
            get;
            set;
        }

        public string message
        {
            get;
            set;
        }

        public ProcessResult()
        {
            this.isSucceed = false;
            this.message = "";

            this.CustomField = new System.Collections.Generic.Dictionary<string, object>();
        }
    }
}
