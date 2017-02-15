using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactorMe.Tests
{
	[TestClass]
	public class ProductExtensionsTests
	{
		[Owner("The whole team..!")]
		[TestMethod, TestCategory("Extensions unit tests")]
		public void ChangePriceTest()
		{
			var product = new Product
			{
				Id = Guid.NewGuid(),
				Name = "name",
				Price = 123.45,
				Type = "type"
			};

			var adjusted = product.ChangePrice(42.0);

			Assert.IsFalse(Object.ReferenceEquals(product, adjusted), "refEqualCheck!");
			Assert.AreEqual(123.45, product.Price, "price unchanged check");
			Assert.AreEqual(42.0, adjusted.Price, "price changed check");
		}
	}
}
