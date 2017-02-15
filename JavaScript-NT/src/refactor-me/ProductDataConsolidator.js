function ProductDataConsolidator(lawnmowersRepo, phoneCasesRepo, teeShirtsRepo) {
	this.lawnmowersRepo = lawnmowersRepo || new LawnmowerRepository();
	this.phoneCasesRepo = phoneCasesRepo || new PhoneCaseRepository();
	this.teeShirtsRepo = teeShirtsRepo || new TShirtRepository();
}

ProductDataConsolidator.prototype.get = function() {
	var toProduct = function(type) {
		return function(product) {
			return new Product(product.id, product.name, product.price, type);
		};
	};

	return [].concat(this.lawnmowersRepo.getAll().map(toProduct("Lawnmower")),
		this.phoneCasesRepo.getAll().map(toProduct("Phone Case")),
		this.teeShirtsRepo.getAll().map(toProduct("T-Shirt"))
	);
};
