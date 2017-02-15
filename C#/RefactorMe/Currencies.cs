using System.Collections.Generic;

namespace RefactorMe
{
	public enum Currency
	{
		NZD,
		USD,
		Euro
	}


	public static class Currencies
	{
		private static Dictionary<Currency, decimal> ConversionTable = new Dictionary<Currency, decimal>
		{
			{ Currency.NZD, 1.0m },
			{ Currency.USD, 0.76m },
			{ Currency.Euro, 0.67m }
		};


		public static decimal GetConversionRateFromNZD(Currency currency)
		{
			return ConversionTable[currency];
		}
	}
}
