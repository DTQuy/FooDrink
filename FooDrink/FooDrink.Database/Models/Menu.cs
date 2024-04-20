﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooDrink.Database.Models
{
    public class Menu : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public Guid RestaurantId { get; set; }
    }
}
