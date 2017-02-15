function Currencies() {
};

Currencies.prototype.currenciesList = [ 'NZD', 'USD', 'Euro' ];

Currencies.prototype.conversionTable = {
	NZD: 1,
	USD: 0.76,
	Euro: 0.67
};

Currencies.prototype.getConversionRateFromNZD = function(currency) {
	return this.conversionTable[currency];
};
