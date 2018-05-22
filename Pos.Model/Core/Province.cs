using Pos.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pos.Model.Core
{
    public class Province : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        //-------------------------------------------------------------
        public ICollection<City> Cities { get; set; }

    }
}