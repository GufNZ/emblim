function Product(id, name, price, type) {
	this.id = id,
	this.name = name,
	this.price = price,
	this.type = type
};

Product.prototype.changePrice = function(newPrice) {
	return new Product(this.id, this.name, newPrice, this.type);
};
