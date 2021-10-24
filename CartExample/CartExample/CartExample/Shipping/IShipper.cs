using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartExample.Shipping
{
	public interface IShipper
	{
		double CalculateShippingCost(double weight, string address);
	}
}
