using AwesomeReads.API.Contracts.Livros;
using AwesomeReads.API.Filters;
using AwesomeReads.Application;
using AwesomeReads.Infrastructure;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1) Registra CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200", "https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            // só use isso se você precisar mandar cookie/Authorization com credenciais do browser
            // .AllowCredentials()
            ;
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "AwesomeReads API", Version = "v1" });
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);


// Adiciona no topo, antes de tudo
AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
{
    Console.WriteLine($"UNHANDLED EXCEPTION: {e.ExceptionObject}");
};



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "AwesomeReads API v1");
    });
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseCors("AngularDev"); // <-- antes de Authorization/MapControllers

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
