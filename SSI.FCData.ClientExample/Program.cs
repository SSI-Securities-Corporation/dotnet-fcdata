using Microsoft.Extensions.Configuration;
using SSI.FCData;
using Serilog;
using Newtonsoft.Json;
using SSI.FCData.Models.Request;
using SSI.FCData.Models.Response;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("data.json", true, reloadOnChange: true);

        var configuration = builder.Build();

        var logger =  new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();
        var apiUrl = configuration["FastConnectUrl"];
        var conId = configuration["ConsumerId"];
        var conSecret = configuration["ConsumerSecret"];
        var channelSub = configuration["channels"];
        var streamURL = configuration["StreamURL"];

        var apiClient = new APIClient(apiUrl, conId, conSecret, logger);
        var streamingClient = new StreamingClient(streamURL, apiClient, logger);

        while (true)
        {
            Console.WriteLine("1. FCData Streaming");
            Console.WriteLine("2. FCData API");
            Console.WriteLine("3. Exit");
            var command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    await TestStreamingData(streamingClient, channelSub??"", logger);
                    break;
                case "2":
                    await FCDataAPI(apiClient, configuration, logger);
                    break;
                case "3":
                    break;
                default:
                    break;

            }

        }
    }
    public static async Task TestStreamingData(StreamingClient client, string channels, ILogger _logger)
    {
        try
        {
            await client.Start();
            await client.SwitchChannels(channels);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Failed to TestStreamingData");
        }
    }
    public static T Get<T>(IConfiguration configuration, string name)
    {
        return configuration.GetSection(name).Get<T>();
    }
    public static async Task FCDataAPI(APIClient client, IConfiguration configuration, ILogger logger)
    {
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
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetSecuritiesList(Get<SecuritiesListRequest>(configuration, "SecuritiesListRequest"))));
                    break;
                case "2":
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetSecuritiesDetails(Get<SecuritiesDetailsRequest>(configuration, "SecuritiesDetailsRequest"))));
                    break;
                case "3":
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetIndexComponent(Get<IndexComponentRequest>(configuration, "IndexComponentRequest"))));
                    break;
                case "4":
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetIndexList(Get<IndexListRequest>(configuration, "IndexListRequest"))));
                    break;
                case "5":
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetDailyOhlc(Get<DailyOHLCRequest>(configuration, "DailyOhlcRequest"))));
                    break;
                case "6":
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetIntradayOhlc(Get<IntradayOHLCRequest>(configuration, "IntradayOhlcRequest"))));
                    break;
                case "7":
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetDailyIndex(Get<DailyIndexRequest>(configuration, "DailyIndexRequest"))));
                    break;
                case "8":
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetStockPrice(Get<StockPriceRequest>(configuration, "StockPriceRequest"))));
                    break;
                /*case "9":
                    Console.WriteLine(JsonConvert.SerializeObject(await client.GetIntradayByTick(Get<IntradayByTickRequest>(configuration, "IntradayByTickRequest"))));
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