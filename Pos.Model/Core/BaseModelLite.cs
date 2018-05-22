using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Core
{
    public class BaseModelLite
    {
        [Key]
        [Required]
        public string Id { get; set; }
    }
}
