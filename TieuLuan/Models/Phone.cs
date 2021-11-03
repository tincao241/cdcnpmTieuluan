using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TieuLuan.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        [Range(128, int.MaxValue, ErrorMessage = "Dung lượng phải lớn hơn 127")]
        public int Storage { get; set; }

    }
}
