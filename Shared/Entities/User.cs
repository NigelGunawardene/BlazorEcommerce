using BlazorEcommerce.Shared.Common;
using BlazorEcommerce.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Entities;
public class User : BaseEntity<int>
{
    public string UserName { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
    public Role Role { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenAddedTime { get; set; }


    // one to many relationship between user and orders
    public ICollection<Order>? Orders { get; set; }
    // one to one relationship between user and user authentication
    public UserAuthentication UserAuthentication { get; set; }
    // many to many relationship between user and wishlist
    public virtual ICollection<WishlistProduct>? WishlistProducts { get; set; }
    // one to many relationship between user and cart
    public virtual ICollection<CartProduct>? CartProducts { get; set; }
}
