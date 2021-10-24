using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorExample.Calculations
{
	public class Addition: ICalculate
	{
		public double Calculate(double item1, double item2)
		{
			return item1 + item2;
		}
	}
}
