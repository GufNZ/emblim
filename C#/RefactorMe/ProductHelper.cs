using RefactorMe.DontRefactor.Models;

namespace RefactorMe
{
	public static class ProductHelper
	{
		public static Product ToProduct(this Lawnmower lawnmower)
		{
			return new Product
			{
				Id = lawnmower.Id,
				Name = lawnmower.Name,
				Price = lawnmower.Price,		//FIXME: Prices REALLY should have been Decimal not Double...
				Type = "Lawnmower"				//FIXME: Type really should be an enum...
			};
		}

		public static Product ToProduct(this PhoneCase phoneCase)
		{
			return new Product
			{
				Id = phoneCase.Id,
				Name = phoneCase.Name,
				Price = phoneCase.Price,		//FIXME: Prices REALLY should have been Decimal not Double...
				Type = "Phone Case"				//FIXME: Type really should be an enum...
			};
		}

		public static Product ToProduct(this TShirt tShirt)
		{
			return new Product
			{
				Id = tShirt.Id,
				Name = tShirt.Name,
				Price = tShirt.Price,			//FIXME: Prices REALLY should have been Decimal not Double...
				Type = "T-Shirt"				//FIXME: Type really should be an enum...
			};
		}
	}
}
