using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTSR.Domain.Enums;

namespace NTSR.Domain.Entities;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OrderNumber { get; set; } = string.Empty;
    public OrderType OrderType { get; set; }

    public int? TableId { get; set; }
    public Table? Table { get; set; }

    public Guid? CashierId { get; set; }
    public ApplicationUser? Cashier { get; set; }

    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.New;
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;
    public PaymentMethod? PaymentMethod { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}