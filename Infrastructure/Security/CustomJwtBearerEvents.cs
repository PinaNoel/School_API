


using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using School_API.App.DTO;

namespace School_API.Infrastructure.Security
{
    public class CustomJwtBearerEvents : JwtBearerEvents
    {

        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            context.NoResult();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            ApiResponse<ErrorDTO> response = new ApiResponse<ErrorDTO>
            {
                StatusCode = context.Response.StatusCode,
                Method = context.Request.Method,
                Path = context.Request.Path,
                Error = new ErrorDTO{
                    Type = "AuthenticationFailed",
                    Message = "Invalid or expired token",
                }
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        public override Task Challenge(JwtBearerChallengeContext context)
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            ApiResponse<ErrorDTO> response = new ApiResponse<ErrorDTO>
            {
                StatusCode = context.Response.StatusCode,
                Method = context.Request.Method,
                Path = context.Request.Path,
                Error = new ErrorDTO{
                    Type = "Challenge",
                    Message = "Missing or unauthorized token",
                }
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        public override Task Forbidden(ForbiddenContext context)
        {
            // context.NoResult();
            context.Response.StatusCode = 403;
            context.Response.ContentType = "application/json";

            ApiResponse<ErrorDTO> response = new ApiResponse<ErrorDTO>
            {
                StatusCode = context.Response.StatusCode,
                Method = context.Request.Method,
                Path = context.Request.Path,
                Error = new ErrorDTO{
                    Type = "Forbidden",
                    Message = "User does not have sufficient permissions",
                }
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}