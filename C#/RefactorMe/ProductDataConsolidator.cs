using System;

using RefactorMe.DontRefactor.Models;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Data.Implementation;

namespace RefactorMe
{
	public class ProductDataConsolidator : IReadOnlyRepository<Product>
	{
		private static readonly Lazy<ProductDataConsolidator> Instance = new Lazy<ProductDataConsolidator>(
			() => new ProductDataConsolidator(		//LATER: proper DependencyInjection if we prove the need for it.
				new LawnmowerRepository(),
				new PhoneCaseRepository(),
				new TShirtRepository()
			)
		);


		public static List<Product> Get()		// To match the existing API.
		{
			return Instance.Value.GetAll().ToList();
		}


		private readonly IReadOnlyRepository<Lawnmower> lawnmowerRepository;
		private readonly IReadOnlyRepository<PhoneCase> phoneCaseRepository;
		private readonly IReadOnlyRepository<TShirt> teeShirtRepository;


		public ProductDataConsolidator(
			IReadOnlyRepository<Lawnmower> lawnmowerRepository,
			IReadOnlyRepository<PhoneCase> phoneCaseRepository,
			IReadOnlyRepository<TShirt> teeShirtRepository
		)
		{
			this.lawnmowerRepository = lawnmowerRepository;
			this.phoneCaseRepository = phoneCaseRepository;
			this.teeShirtRepository = teeShirtRepository;
		}


		public IQueryable<Product> GetAll()
		{
			var lawnmowers = lawnmowerRepository.GetAll();
			var phoneCases = phoneCaseRepository.GetAll();
			var tShirts = teeShirtRepository.GetAll();

			return lawnmowers.Select(ProductHelper.ToProduct)
				.Union(phoneCases.Select(ProductHelper.ToProduct))
				.Union(tShirts.Select(ProductHelper.ToProduct))
				.AsQueryable();
		}

		public IQueryable<Product> Get(Expression<Func<Product, bool>> predicate)
		{
			return GetAll()
				.Where(predicate);
		}
	}
}
