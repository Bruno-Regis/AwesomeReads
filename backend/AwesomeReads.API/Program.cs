using AwesomeReads.Application;
using AwesomeReads.Infrastructure;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200", "https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Components ??= new OpenApiComponents();

        if (document.Components.SecuritySchemes == null)
            document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>();

        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Informe o token JWT"
        };

        return Task.CompletedTask;
    });

    options.AddOperationTransformer((operation, context, cancellationToken) =>
    {
        var hasAuthorize = context.Description.ActionDescriptor.EndpointMetadata
            .OfType<Microsoft.AspNetCore.Authorization.AuthorizeAttribute>()
            .Any();

        if (hasAuthorize)
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer")] = []
            });
        }

        return Task.CompletedTask;
    });
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
{
    Console.WriteLine($"UNHANDLED EXCEPTION: {e.ExceptionObject}");
};

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("AwesomeReads API")
            .WithTheme(ScalarTheme.Moon);
    });
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("AngularDev");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();