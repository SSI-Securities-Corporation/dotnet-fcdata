using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DotnetClientTest
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddNewtonsoftJsonFile("data.json", true, reloadOnChange: true);

            var configuration = builder.Build();

            var logger = MyLogger.CreateLogger();
            var resource = new ResourceTestTemplateV2(configuration, logger);

            while (true)
            {
                Console.WriteLine("1. FCData Streaming");
                Console.WriteLine("2. FCData API");
                Console.WriteLine("3. Exit");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        await resource.TestStreamData();
                        break;
                    case "2":
                        FCDataAPI();
                        break;
                    case "3":
                        break;
                    default:
                        break;

                }

            }
        }
        public static async void FCDataAPI()
        {
            var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddNewtonsoftJsonFile("data.json", true, reloadOnChange: true);

            var configuration = builder.Build();

            var logger = MyLogger.CreateLogger();
            var resource = new ResourceTestTemplateV2(configuration, logger);
            var isCheck = true;
            while (true)
            {
                Console.WriteLine("1. SecuritiesRequest");
                Console.WriteLine("2. SecuritiesDetailRequest");
                Console.WriteLine("3. IndexComponentsRequest");
                Console.WriteLine("4. IndexListRequest");
                Console.WriteLine("5. DailyOhlcRequest");
                Console.WriteLine("6. IntradayOhlcRequest");
                Console.WriteLine("7. DailyIndexRequest");
                Console.WriteLine("8. DailyStockPriceRequest");
                //Console.WriteLine("9. IntradayByTickRequest");
                Console.WriteLine("10. Exit");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        resource.TestSecuritiesList();
                        break;
                    case "2":
                        resource.TestSecuritiesDetail();
                        break;
                    case "3":
                        resource.TestIndexComponent();
                        break;
                    case "4":
                        resource.TestIndexList();
                        break;
                    case "5":
                        resource.TestDailyOHLC();
                        break;
                    case "6":
                        resource.TestIntradayOHLC();
                        break;
                    case "7":
                        resource.TestDailyIndex();
                        break;
                    case "8":
                        resource.TestDailyStockPrice();
                        break;
                    /*case "9":
                        resource.TestIntradayByTick();
                        break;*/
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Input again!");
                        return;

                }
            }
        }
    }
}

