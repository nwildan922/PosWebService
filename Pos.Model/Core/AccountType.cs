using Pos.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pos.Model.Core
{

    public class AccountType : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Period { get; set; }
        [Required]
        public int PlusActiveDay { get; set; }

        //-------------------------------------------------------------
        public ICollection<Account> Acounts { get; set; }
    }
}