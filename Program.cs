using TodoApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoAppDbContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
