using System;
using SSI.FastConnect.Client;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using SSI.FastConnect.DataContracts.Realtime;
using SSI.FastConnect.RealTimeClient;
using System.IO;
using SSI.FastConnect.DataContracts.Market.Request;
using SSI.FastConnect.DataContracts.Market.Response;
using SSI.FastConnect.Client.Helpers;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
namespace DotnetClientTest
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var resource = new ResourceTestTemplateV2();
        LoopStart:
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
            bool condition = (getKey >= ConsoleKey.NumPad0 && getKey <= ConsoleKey.NumPad9) || (getKey >= ConsoleKey.D1 && getKey <= ConsoleKey.D9);
            if (condition)
            {
                switch (getKey)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        resource.TestSecuritiesList();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        resource.TestSecuritiesDetail();
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        resource.TestIndexComponent();
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        resource.TestIndexList();
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        resource.TestDailyOHLC();
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        resource.TestIntradayOHLC();
                        break;
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        resource.TestDailyIndex();
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8:
                        resource.TestDailyStockPrice();
                        break;
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
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
