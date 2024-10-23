using Orchestrator.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5001");
builder.Services.AddSingleton<QueueManager>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();