angular.module("app", [])
	.controller("main", function($scope) {
		var currencies = new Currencies();

		var dataSource = new ProductDataConsolidator();
		var products = dataSource.get();

		var convertPriceFromNZD = function(currency) {
			var priceRatio = currencies.getConversionRateFromNZD(currency);

			return products.map(function(product) {
				return product.changePrice(product.price * priceRatio);
			});
		};

		$scope.products = {};
		currencies.currenciesList
			.map(function(currency) {
				$scope.products[currency] = convertPriceFromNZD(currency);
			});
	})
	.directive("productTable", function() {
		return {
			scope: {
				currency: '@',
				products: '=products'
			},
			/*
			templateUrl: 'src/productTable.html'	// Cross origin request breach when loaded as file://
			/*/
			template: '<table class="table table-striped">'
					+ '	<thead>'
					+ '		<tr><th colspan="3">Products ({{currency}})</th></tr>'
					+ '		<tr>'
					+ '			<th>Name</th>'
					+ '			<th>Price</th>'
					+ '			<th>Type</th>'
					+ '		</tr>'
					+ '	</thead>'
					+ '	<tbody>'
					+ '		<tr ng-repeat="product in products">'
					+ '			<td>{{product.name}}</td>'
					+ '			<td>{{product.price | currency}}</td>'
					+ '			<td>{{product.type}}</td>'
					+ '		</tr>'
					+ '	</tbody>'
					+ '</table>'
			/**/
		};
	});
