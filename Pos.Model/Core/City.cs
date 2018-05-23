using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Model.Core
{

    public class City : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        public Province TmProvince { get; set; }
        public string ProvinceId { get; set; }
        //-------------------------------------------------------------
        public ICollection<Account> Accounts { get; set; }
    }
}