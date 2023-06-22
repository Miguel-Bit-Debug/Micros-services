using Messagehub.CrossCutting.DI;
using Messagehub.Domain.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencyInjection();
builder.AddMessagehubDependencyInjection();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapHub<MessageHub>("/hub");

app.UseAuthorization();

app.MapControllers();

app.Run();
