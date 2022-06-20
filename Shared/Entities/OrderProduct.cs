using BlazorEcommerce.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Entities;
public class OrderProduct : BaseEntity<int>
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double TotalPrice { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}
