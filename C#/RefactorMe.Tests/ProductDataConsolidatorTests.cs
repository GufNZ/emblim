using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe.Tests
{
	[TestClass]
	public class ProductDataConsolidatorTests
	{
		private Mock<IReadOnlyRepository<T>> GetRepositoryMock<T>(T[] items)
			where T : class
		{
			var mock = new Mock<IReadOnlyRepository<T>>();
			mock.Setup(r => r.GetAll())
				.Returns(items.AsQueryable());

			return mock;
		}


		[Owner("The whole team..!")]
		[TestMethod, TestCategory("Helper unit tests")]
		public void GetAll()
		{
			var lawnmowerRepoMock = GetRepositoryMock(
				new[]
				{
					new Lawnmower
					{
						Id = Guid.NewGuid(),
						Name = "RideOn Lawnmower1",
						Price = 1.0,
						FuelEfficiency = "efficient",
						IsVehicle = true
					}
				}
			);
			var phoneCaseRepoMock = GetRepositoryMock(
				new[]
				{
					new PhoneCase
					{
						Id = Guid.NewGuid(),
						Name = "Fancy",
						Price = 20.0,
						Colour = "red gofaster stripes",
						Material = "diamond",
						TargetPhone = "All your phone are belong to us!"
					},
					new PhoneCase
					{
						Id = Guid.NewGuid(),
						Name = "Boring",
						Price = 0.11,
						Colour = "brown",
						Material = "wood",
						TargetPhone = "flip fones"
					}
				}
			);
			var teeShirtRepoMock = GetRepositoryMock(
				new[]
				{
					new TShirt
					{
						Id = Guid.NewGuid(),
						Name = "Minecraft",
						Colour = "Green",
						Price = 81.24,
						ShirtText = "CreeperFace"
					}
				}
			);


			var consolidator = new ProductDataConsolidator(
				lawnmowerRepoMock.Object,
				phoneCaseRepoMock.Object,
				teeShirtRepoMock.Object
			);


			var products = consolidator.GetAll()
				.ToList();


			Assert.AreEqual(4, products.Count, "Count mismatch!");
			CollectionAssert.AllItemsAreNotNull(products, "Contains null!");
			CollectionAssert.AllItemsAreInstancesOfType(products, typeof(Product), "Bad type contents!");
			CollectionAssert.AllItemsAreUnique(products, "Doubleup!");
			Assert.AreEqual(1, products.Count(p => p.Type == "Lawnmower"), "lawn count!");
			Assert.AreEqual(2, products.Count(p => p.Type == "Phone Case"), "case count!");
			Assert.AreEqual(1, products.Count(p => p.Type == "T-Shirt"), "shirt count!");
		}
	}
}
