using Microsoft.AspNetCore.HttpOverrides;
using MyApi.Handlers;
using MyApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSystemd();

var services = builder.Services;

services.AddScoped<ICounterService, CounterService>()
    .AddScoped<IDatabaseHandler, DatabaseHandler>();

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();