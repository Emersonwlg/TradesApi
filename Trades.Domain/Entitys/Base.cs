using System;
using System.ComponentModel.DataAnnotations;

namespace Trades.Domain.Entitys
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
