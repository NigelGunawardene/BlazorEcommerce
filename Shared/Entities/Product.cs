using BlazorEcommerce.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Entities;
public class Product : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public double Price { get; set; }
    public int QuantityInStock { get; set; }
    public bool OnSale { get; set; }
    public int Discount { get; set; }
    public DateTime AddedDate { get; set; }



    public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    public virtual ICollection<CartProduct>? CartProducts { get; set; }
    public virtual ICollection<WishlistProduct>? WishlistProducts { get; set; }
    public virtual ICollection<ProductCategory>? Categories { get; set; }
}
