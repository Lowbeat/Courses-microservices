using MonitoringServiceB.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<MonitoringService>();
builder.WebHost.UseUrls("http://localhost:5005");

var app = builder.Build();

var monitoringService = app.Services.GetRequiredService<MonitoringService>();
var pollingTask = Task.Run(() => monitoringService.PollProductAvailability());

app.Run();