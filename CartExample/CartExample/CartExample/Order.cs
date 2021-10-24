using System;
using System.Collections.Generic;
using System.Linq;
using CartExample.Shipping;

namespace CartExample
{
	public class OrderItem
	{
		public int Id { get; set; }
		public double Price { get; set; }
		public string ItemName { get; set; }
		public double Weight { get; set; }
	}
	public class Order
	{
		public List<OrderItem> OrderItems { get; set; }
		public string Address { get; set; }

		public double GetItemTotal()
		{
			return OrderItems.Sum(x => x.Price);
		}
		public double GetShippingTotal(IShipper shipper)
		{
			//we need to contact an external service to accomplish this task
			var shippingCost = 
				shipper.CalculateShippingCost(
					OrderItems.Sum(x => x.Weight), 
					this.Address
				);

			return shippingCost;
		}
		public double GetOrderTotal(IShipper shipper)
		{
			var shippingTotal = GetShippingTotal(shipper);
			var itemTotal = GetItemTotal();

			return shippingTotal + itemTotal;
		}


	}
}
