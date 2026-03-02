using Scalar.AspNetCore;
using AwesomeReads.Infrastructure;
using AwesomeReads.Application;

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
builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options
        .WithTitle("GerenciadorLivro API")
        .WithTheme(ScalarTheme.Purple);
    }
    );
}

app.UseHttpsRedirection();

app.UseCors("AngularDev"); // <-- antes de Authorization/MapControllers

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
