using RefactorMe.DontRefactor.Models;

namespace RefactorMe
{
	public static class ProductExtensions
	{
		public static Product ChangePrice(this Product product, double newPrice)
		{
			return new Product
			{
				Id = product.Id,
				Name = product.Name,
				Price = newPrice,
				Type = product.Type
			};
		}
	}
}
