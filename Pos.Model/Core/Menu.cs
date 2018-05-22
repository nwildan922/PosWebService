using Pos.Model.Core;
using System.ComponentModel.DataAnnotations;

namespace Pos.Model.Core
{

    public class Menu : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}