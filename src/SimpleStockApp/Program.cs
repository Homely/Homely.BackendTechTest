using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace SimpleStockApp
{
    public static class Program
    {
        // NOTE: Stock API reference: https://iextrading.com/developer/docs/
        //       It's a free Stock API.

        public static void Main(string[] args)
        {
            Console.WriteLine("** Simple Stock App **");

            // Grab a list of stocks (ordered by most gainst 'recently').
            var stocks = GetLatestGainingStocks();

            // Save the stock information to disk. 1 file per stock.
            var stocksWithPrice = GetStockPrices(stocks);

            // Now save these prices to disk.
            SaveStockPricesToDisk(stocksWithPrice);

            Console.WriteLine("Done!");
            Console.WriteLine("Press any key to finish.");
            Console.ReadKey();
        }

        private static IList<Stock> GetLatestGainingStocks()
        {
            using (var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.iextrading.com/")
            })
            {
                // Get a list of the top stock gainers 'recently'.
                var topStockGainers = httpClient.GetAsync("1.0/stock/market/list/gainers").Result;

                // Conver this to a list of Stock's.
                return JsonConvert.DeserializeObject<IList<Stock>>(topStockGainers.Content.ReadAsStringAsync().Result);
            }
        }

        private static IList<Stock> GetStockPrices(IList<Stock> stocks)
        {
            var stocksWithPrice = new List<Stock>();

            for (var i = 0; i < stocks.Count; i++)
            {
                using (var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://api.iextrading.com/")
                })
                {
                    // Get a stock's price.
                    var stockLogoUrl = httpClient.GetAsync("1.0/stock/" + stocks[i].Symbol + "/price").Result;
                    var price = stockLogoUrl.Content.ReadAsStringAsync().Result;

                    // Remember this stock and the latest price.
                    var stock = new Stock
                    {
                        Symbol = stocks[i].Symbol,
                        CompanyName = stocks[i].CompanyName,
                        PrimaryExchange = stocks[i].PrimaryExchange,
                        Price = price
                    };

                    stocksWithPrice.Add(stock);
                }
            }

            return stocksWithPrice;
        }

        private static void SaveStockPricesToDisk(IList<Stock> stocksWithPrice)
        {
            for (int i = 0; i < stocksWithPrice.Count; i++)
            {
                var json = JsonConvert.SerializeObject(stocksWithPrice[i]);
                File.WriteAllText("C:\\Temp\\Stock-" + stocksWithPrice[i].Symbol + ".json", json);
            }
        }
    }
}
