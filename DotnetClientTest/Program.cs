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

        LoopStart:
            Console.WriteLine("0. Stream with FCData");
            Console.WriteLine("1. SecuritiesRequest");
            Console.WriteLine("2. SecuritiesDetailRequest");
            Console.WriteLine("3. IndexComponentsRequest");
            Console.WriteLine("4. IndexListRequest");
            Console.WriteLine("5. DailyOhlcRequest");
            Console.WriteLine("6. IntradayOhlcRequest");
            Console.WriteLine("7. DailyIndexRequest");
            Console.WriteLine("8. DailyStockPriceRequest");
            Console.WriteLine("9. Exit");

        LoopReadKey:
            var getKey = Console.ReadKey(true).Key;
            bool condition = (getKey >= ConsoleKey.NumPad0 && getKey <= ConsoleKey.NumPad9) || (getKey >= ConsoleKey.D0 && getKey <= ConsoleKey.D9);
            if (condition)
            {
                switch (getKey)
                {
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.D0:
                        Console.WriteLine(0);
                        await resource.TestStreamData();
                        break;
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine(1);
                        resource.TestSecuritiesList();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine(2);
                        resource.TestSecuritiesDetail();
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine(3);
                        resource.TestIndexComponent();
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        Console.WriteLine(4);
                        resource.TestIndexList();
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        Console.WriteLine(5);
                        resource.TestDailyOHLC();
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        Console.WriteLine(6);
                        resource.TestIntradayOHLC();
                        break;
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        Console.WriteLine(7);
                        resource.TestDailyIndex();
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8:
                        Console.WriteLine(8);
                        resource.TestDailyStockPrice();
                        break;
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
                        Console.WriteLine(9);
                        break;
                    default:
                        break;

                }

                if (!(getKey == ConsoleKey.NumPad9 || getKey == ConsoleKey.D9))
                {
                    goto LoopReadKey;
                }

            }
            else
            {
                Console.WriteLine("----- enter key number  ------------");
                goto LoopStart;
            }
        }

    }
}
