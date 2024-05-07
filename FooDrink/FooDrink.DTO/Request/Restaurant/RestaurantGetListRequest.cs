using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooDrink.DTO.Request.Restaurant
{
    public class RestaurantGetListRequest 
    {
        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page Index
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Search string
        /// </summary>
        public string SearchString { get; set; } = string.Empty;
    }
}
