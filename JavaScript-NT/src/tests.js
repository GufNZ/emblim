function MockRepo(items) {
	this.getAll = () => items;
}

QUnit.test("ProductDataConsolidator.get", assert => {
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
