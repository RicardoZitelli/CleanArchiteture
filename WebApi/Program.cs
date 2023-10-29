using Presentation;
using Infrastructure;
using Application;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAplication();
builder.Services.AddInfrastructure();
builder.Services.AddPresentation();    

builder.Host.UseSerilog((context, configuration) =>  
    configuration.ReadFrom.Configuration(context.Configuration)); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.Run();