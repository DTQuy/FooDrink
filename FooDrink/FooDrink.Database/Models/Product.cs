using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooDrink.Database.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string CategoryList { get; set; }
        public string ImageList { get; set; }
        public Guid MenuId { get; set; }
    }
}
