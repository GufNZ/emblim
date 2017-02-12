function ProductDataConsolidator(lawnmowersRepo, phoneCasesRepo, teeShirtsRepo) {
	this.lawnmowersRepo = lawnmowersRepo || new LawnmowerRepository();
	this.phoneCasesRepo = phoneCasesRepo || new PhoneCaseRepository();
	this.teeShirtsRepo = teeShirtsRepo || new TShirtRepository();
}

ProductDataConsolidator.prototype.get = function(noFormatPrice) {
	var toProduct = function(type) {
		return function(product) {
			return {
				id: product.id,
				name: product.name,
				price: product.price,
				type: type
			};
		};
	};

	var products = [].concat(this.lawnmowersRepo.getAll().map(toProduct("Lawnmower")),
		this.phoneCasesRepo.getAll().map(toProduct("Phone Case")),
		this.teeShirtsRepo.getAll().map(toProduct("T-Shirt"))
	);

	if (!noFormatPrice) {
		products = products.map(function(p) {
			p.price = p.price.toFixed(2);
			return p;
		});						// ...map(p => (p.price = p.price.toFixed(2), p)) isn't readable enough for most people...
	}

	return products;
};

ProductDataConsolidator.prototype.getProductsWithModifiedPrice = function(priceRatio) {
	return this.get(true)
		.map(function(p) {
			p.price = (p.price * priceRatio).toFixed(2);
			return p;
		});
};

ProductDataConsolidator.prototype.getInUSDollars = function() {
	return this.getProductsWithModifiedPrice(0.76);
};

ProductDataConsolidator.prototype.getInEuros = function() {
	return this.getProductsWithModifiedPrice(0.67);
};
