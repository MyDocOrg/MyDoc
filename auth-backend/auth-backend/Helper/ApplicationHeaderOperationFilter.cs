using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

public class ApplicationHeaderOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Solo Login
        if (context.ApiDescription.RelativePath == null ||
            !context.ApiDescription.RelativePath.ToLower().Contains("login"))
            return;

        if (operation.Parameters == null)
        {
            operation.Parameters = new List<IOpenApiParameter>();
        }

        // Evitar duplicados
        foreach (var p in operation.Parameters)
        {
            if (p.Name == "X-Application-Name")
                return;
        }

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Application-Name",
            In = ParameterLocation.Header,
            Required = true,
            Description = "Nombre de la aplicación",
            Schema = new OpenApiSchema
            {
                Type = JsonSchemaType.String
            }
        });
    }
}
