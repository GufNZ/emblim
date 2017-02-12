angular.module("app", [])
	.controller("main", function($scope) {
		var dataSource = new ProductDataConsolidator();
		$scope.products = {
			NZD: dataSource.get(),
			USD: dataSource.getInUSDollars(),
			Euro: dataSource.getInEuros(),
		};
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
					+ '			<td>{{product.price}}</td>'
					+ '			<td>{{product.type}}</td>'
					+ '		</tr>'
					+ '	</tbody>'
					+ '</table>'
			/**/
		};
	});
