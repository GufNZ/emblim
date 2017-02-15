function MockRepo(items) {
	this.getAll = function() {
		return items;
	}
}

QUnit.test("ProductDataConsolidator.get", function(assert) {
	var productDataConsolidator = new ProductDataConsolidator(
		new MockRepo([
			{
				id: 1,
				name: "mower1",
				fuelEfficiency: "something",
				isVehicle: false,
				price: 12.34
			}
		]),
		new MockRepo([
			{
				id: 10,
				name: "case1",
				colour: "black",
				material: "plastic",
				targetPhone: "the small ones",
				price: 20
			},
			{
				id: 11,
				name: "case2",
				colour: "purple",
				material: "glue",
				targetPhone: "the big ones",
				price: 99
			},
		]),
		new MockRepo([
			{
				id: 100,
				name: "shirt1",
				shirtText: "something",
				colour: "grey",
				price: 1
			}
		])
	);

	var products = productDataConsolidator.get();

	console.log(products);
	console.log(products.filter(function(p) { return p.type === "T-Shirt"; }).length);

	assert.equal(products.length, 4, "length");
	assert.equal(products.filter(function(p) { return p.type === "Lawnmower"; }).length, 1, "mower#");
	assert.equal(products.filter(function(p) { return p.type === "Phone Case"; }).length, 2, "case#");
	assert.equal(products.filter(function(p) { return p.type === "T-Shirt"; }).length, 1, "shirt#");
});


QUnit.test("new Product", function(assert) {
	var product = new Product(1, "theProduct", 123.45, "type");

	assert.equal(product.id, 1);
	assert.equal(product.name, "theProduct");
	assert.equal(product.price, 123.45);
	assert.equal(product.type, "type");
});

QUnit.test("Product.changePrice", function(assert) {
	var product = new Product(1, "theProduct", 123.45, "type");

	var adjusted = product.changePrice(42);

	assert.notEqual(product, adjusted, "refEqualityCheck");
	assert.equal(product.price, 123.45);
	assert.equal(adjusted.id, product.id);
	assert.equal(adjusted.name, product.name);
	assert.equal(adjusted.price, 42);
	assert.equal(adjusted.type, product.type);
});


QUnit.test("Currencies.currenciesList", function(assert) {
	var currencies = new Currencies();

	assert.deepEqual(currencies.currenciesList, [ 'NZD', 'USD', 'Euro' ]);
});

QUnit.test("Currencies.getConversionRateFromNZD", function(assert) {
	var currencies = new Currencies();

	var results = currencies.currenciesList.map(function(currency) {
		return currencies.getConversionRateFromNZD(currency);
	});

	assert.deepEqual(results, [ 1, 0.76, 0.67 ]);
});
