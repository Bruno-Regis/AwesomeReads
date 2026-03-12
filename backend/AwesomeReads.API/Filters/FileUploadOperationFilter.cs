using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi;          // OpenApiSchema NOVO namespace (v2)
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AwesomeReads.API.Filters
{
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var formFileProperties = context.MethodInfo
                .GetParameters()
                .SelectMany(p => p.ParameterType.GetProperties())
                .Where(p => p.PropertyType == typeof(IFormFile))
                .Select(p => p.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            if (!formFileProperties.Any()) return;
            if (operation.RequestBody?.Content == null) return;
            if (!operation.RequestBody.Content.ContainsKey("multipart/form-data")) return;

            var schema = operation.RequestBody.Content["multipart/form-data"].Schema;
            if (schema?.Properties == null) return;

            foreach (var propName in schema.Properties.Keys.ToList())
            {
                if (formFileProperties.Contains(propName))
                {
                    // Só o campo IFormFile vira binary
                    schema.Properties[propName] = new OpenApiSchema
                    {
                        Type = JsonSchemaType.String,
                        Format = "binary"
                    };
                }
                else
                {
                    // Remove format binary de campos que não são arquivo
                    var existing = schema.Properties[propName];
                    if (existing.Format == "binary")
                    {
                        schema.Properties[propName] = new OpenApiSchema
                        {
                            Type = JsonSchemaType.String
                        };
                    }
                }
            }
        }
    }
}