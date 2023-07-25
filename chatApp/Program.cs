using chatApp.Data;
using chatApp.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
//Reggister dbcontext
var connectionString=builder.Configuration.GetConnectionString("MyDbContext");
builder.Services.AddDbContext<MyDbContext>(Options => Options.UseSqlServer(connectionString));

//SignalR
builder.Services.AddSignalR();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/Home/Index");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
