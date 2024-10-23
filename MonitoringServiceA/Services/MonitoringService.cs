using System.Text;
using Newtonsoft.Json;
using SharedModels;

namespace MonitoringServiceA.Services;

public class MonitoringService
{
    private readonly HttpClient _httpClient;
    private readonly string _orchestratorUrl = "http://localhost:5001/orchestrator/notify";

    public MonitoringService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task PollProductAvailability()
    {
        while (true)
        {
            var productAvailable = CheckProductAvailability();
            if (productAvailable)
            {
                Console.WriteLine("Product is available!");
                var eventPayload = new ProductAvailabilityEvent
                {
                    ProductTitle = "King Arthur's sword",
                    UserId = GetNextUserId()
                };

                var content = new StringContent(JsonConvert.SerializeObject(eventPayload), Encoding.UTF8, "application/json");
                await _httpClient.PostAsync(_orchestratorUrl, content);
            }
            else
            {
                Console.WriteLine("Product is not available!");
            }

            await Task.Delay(new Random().Next(1000, 5000));
        }
    }

    private bool CheckProductAvailability()
    {
        return new Random().Next(1, 10) > 7;
    }

    private int GetNextUserId()
    {
        return new Random().Next(1, 5);
    }
}
