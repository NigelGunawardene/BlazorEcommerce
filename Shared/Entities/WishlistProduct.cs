using BlazorEcommerce.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Entities;
public class WishlistProduct : BaseEntity<int>
{
    public int UserId { get; set; }
    public int ProductId { get; set; }

    public User User { get; set; }
    public Product Product { get; set; }
    public DateTime AddedDate { get; set; }
}
