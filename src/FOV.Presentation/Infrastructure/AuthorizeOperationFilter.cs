using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FOV.Presentation.Infrastructure;

public class AuthorizeOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var authorizeAttributes = context.MethodInfo.GetCustomAttributes(true)
            .OfType<AuthorizeAttribute>()
            .ToList();

        if (authorizeAttributes.Count == 0)
        {
            authorizeAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .ToList();
        }

        if (authorizeAttributes.Any())
        {
            var roles = GetRoles(authorizeAttributes);
            operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.Add("Allow", new OpenApiResponse { Description = $"{(roles.Count != 0 ? string.Join(", ", roles) : "All")}" });
            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    roles
                }
            };

            operation.Security = new List<OpenApiSecurityRequirement> { securityRequirement };
        }
    }

    private IList<string> GetRoles(IEnumerable<AuthorizeAttribute> attributes)
    {
        var roles = new List<string>();

        foreach (var attribute in attributes)
        {
            if (!string.IsNullOrWhiteSpace(attribute.Roles))
            {
                roles.AddRange(attribute.Roles.Split(','));
            }
        }

        return roles;
    }
}
