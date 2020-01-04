using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myShop.Core.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();  
        }
        public string Id { get; set; }
        public string Category { get; set; }
    }
}
