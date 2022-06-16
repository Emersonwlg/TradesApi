using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trades.Domain.Entitys
{
    [Table(name: "TradeCategory")]
    [Index(nameof(Value), nameof(ClientSector))]
    public class TradeCategory : Base
    {
        [Required]
        [MaxLength(25)]
        public string Category { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        [MaxLength(25)]
        public string ClientSector { get; set; }
    }
}
