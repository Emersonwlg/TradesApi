﻿using System;

namespace Trades.Application.Dtos
{
    public class TradeCategoryDto
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
