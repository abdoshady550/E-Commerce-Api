using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual ICollection<OrderDetail> OrderItems { get; set; } = new List<OrderDetail>();
}
