var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Добавляем явное указание слушать на 0.0.0.0:5000
builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

app.MapControllers();

app.Run();
