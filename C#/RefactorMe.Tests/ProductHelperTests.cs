using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RefactorMe.DontRefactor.Models;

namespace RefactorMe.Tests
{
	[TestClass]
	public class ProductHelperTests
	{
		[Owner("The whole team..!")]
		[TestMethod, TestCategory("Helper unit tests")]
		public void LawnmowerToProduct()
		{
			var id = Guid.NewGuid();
			var lawnMower = new Lawnmower
			{
				Id = id,
				Name = "Briggs & Stratton",
				Price = 42.0,				//FIXME: Prices REALLY should have been Decimal not Double...
				FuelEfficiency = "Average",
				IsVehicle = false
			};


			var product = lawnMower.ToProduct();

			Assert.AreEqual(lawnMower.Id, product.Id, "ID mismatch!");
			Assert.AreEqual(lawnMower.Name, product.Name, "Name mismatch!");
			Assert.AreEqual(lawnMower.Price, product.Price, "Price mismatch!");
			Assert.AreEqual("Lawnmower", product.Type, "Type mismatch!");
		}

		[Owner("The whole team..!")]
		[TestMethod, TestCategory("Helper unit tests")]
		public void PhoneCaseToProduct()
		{
			var id = Guid.NewGuid();
			var lawnMower = new PhoneCase
			{
				Id = id,
				Name = "Extra sparkly",
				Price = 13.37,				//FIXME: Prices REALLY should have been Decimal not Double...
				Colour = "Silver",
				Material = "Tungsten",
				TargetPhone = "Nexus 7"
			};


			var product = lawnMower.ToProduct();

			Assert.AreEqual(lawnMower.Id, product.Id, "ID mismatch!");
			Assert.AreEqual(lawnMower.Name, product.Name, "Name mismatch!");
			Assert.AreEqual(lawnMower.Price, product.Price, "Price mismatch!");
			Assert.AreEqual("Phone Case", product.Type, "Type mismatch!");
		}

		[Owner("The whole team..!")]
		[TestMethod, TestCategory("Helper unit tests")]
		public void TeeShirtToProduct()
		{
			var id = Guid.NewGuid();
			var lawnMower = new TShirt
			{
				Id = id,
				Name = "Geek",
				Price = 12.34,				//FIXME: Prices REALLY should have been Decimal not Double...
				Colour = "Blue",
				ShirtText = "<Geek> / </Geek>"
			};


			var product = lawnMower.ToProduct();

			Assert.AreEqual(lawnMower.Id, product.Id, "ID mismatch!");
			Assert.AreEqual(lawnMower.Name, product.Name, "Name mismatch!");
			Assert.AreEqual(lawnMower.Price, product.Price, "Price mismatch!");
			Assert.AreEqual("T-Shirt", product.Type, "Type mismatch!");
		}
	}
}
