using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartExample.Shipping
{
	public class CheapShipper: IShipper
	{
		public double CalculateShippingCost(double weight, string address)
		{
			//in the real world this would make a request to a vendor system
			return weight * 2;
		}
	}
}
