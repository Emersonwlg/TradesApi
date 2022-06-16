using System;
using System.Collections.Generic;
using System.Text;

namespace Trades.Application.Dtos
{
    public class TradeCategoryDto
    {
        public string Category { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
