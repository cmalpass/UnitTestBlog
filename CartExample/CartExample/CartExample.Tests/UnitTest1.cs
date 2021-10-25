using CartExample.Shipping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CartExample.Tests
{
	[TestClass]
	public class UnitTest1
	{

		[TestMethod]
		public void TestOrderTotalCalculation()
		{
			//now create a mock object that serves in place of our external vendor shipping system
			var shippingServiceMock = new Mock<IShipper>();

			//then define the substitute behaviors
			//here we are telling our mock that any request for CalculateShippingCost can accept
			//any parameters that match the expected types and we will always have it return 500
			//this can be adjusted as desired and set to reflect specific input values, as well
			shippingServiceMock
				.Setup(x => x.CalculateShippingCost(
					It.IsAny<double>(),
					It.IsAny<string>()))
				.Returns(45.98);

			//populate a sample order object for our test use
			var order = new Order
			{

				OrderItems = new System.Collections.Generic.List<OrderItem>
				{
					new OrderItem
					{
						Id = 1,
						ItemName = "Gear",
						Price = 45.78,
						Weight = 12
					},
					new OrderItem
					{
						Id = 16,
						ItemName = "Gear with Sprocket Attached",
						Price = 76.22,
						Weight = 19.23
					},
					new OrderItem
					{
						Id = 54,
						ItemName = "Sprocket",
						Price = 22.12,
						Weight = 8.33
					}
				},
				Address = "123 Maple Street, Anytown, NH 43432, USA"
			};

			//calculate the subtotal of all items in the order
			var orderItemTotal = order.GetItemTotal();

			//calculate the order total with shipping included
			var orderTotal = order.GetOrderTotal(shippingServiceMock.Object);

			//now we ensure that the result from the GetOrderTotal method matches what we manually defined in the mock setup in the beginning of the test
			Assert.AreEqual(45.98, orderTotal);
		}
	}
}
