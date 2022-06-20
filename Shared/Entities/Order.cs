using BlazorEcommerce.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Entities;
public class Order : BaseEntity<int>
{
    public int UserId { get; set; }

    // add reference to user and make it non nullable
    //[Required] // this annotation is not actually required. it is not nullable by default unless you add a ?
    [IgnoreDataMember]
    public User User { get; set; }
    public double TotalPrice { get; set; }
    public string PublicOrderNumber { get; set; }
    public string Message { get; set; }
    public DateTime OrderDate { get; set; }
    public Boolean IsComplete { get; set; }
    public Boolean IsDeleted { get; set; }


    // one to many relationship between order and order products
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
