using System;
using System.ComponentModel.DataAnnotations;

namespace Trades.Domain.Entitys
{
    public class Base
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
