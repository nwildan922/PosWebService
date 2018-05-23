using Jil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Helpers.Helper
{
    public static class JilHelper
    {

        public static string Serialize(object model)
        {
            using (var json = new StringWriter())
            {
                JSON.Serialize(
                   model,
                    json,
                    Options.ISO8601ExcludeNullsJSONPIncludeInheritedUtcCamelCase
                );
                return json.ToString();
            }
                
        }

    }
}
