using System.ComponentModel.DataAnnotations;

namespace Staff.BL.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public int Money { get; set; }
    }
}
