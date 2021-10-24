using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorExample.Test
{
	[TestClass]
	public class CalculatorTests
	{
		[TestMethod]
		public void TestAdditionCalculationPasses()
		{
			var calculator = new CalculatorExample.Calculator();

			var result = calculator.Add(2, 3);

			//Assert will compare the result we "know"
			//with the one the unit under test returns
			Assert.AreEqual(5, result);
		}
		[TestMethod]
		public void TestAdditionCalculationFails()
		{
			var calculator = new CalculatorExample.Calculator();

			var result = calculator.Add(2, 3);

			//Assert will compare the result we "know"
			//with the one the unit under test returns
			Assert.AreNotEqual(27, result);
		}
	}
}
