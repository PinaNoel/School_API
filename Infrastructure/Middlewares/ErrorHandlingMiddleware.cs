using System.Net;
using System.Text.Json;
using School_API.App.DTO;

using School_API.Core.Exceptions;


namespace School_API.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogTrace($"Request: {context.Request.Method} {context.Request.Path}");
                await _next(context);
            }

            catch (NotFoundException notFound)
            {
                _logger.LogError($"NotFoundException: {notFound.Message}");
                await NotFoundExceptionAsync(context, notFound);
            }

            catch (BadRequestException ex)
            {
                _logger.LogError($"BadRequestException: {ex.Message}");
                await BadRequestExceptionAsync(context, ex);
            }

            catch (ModelStateException modelState)
            {
                _logger.LogError($"ModelStateException: {modelState.Message}");
                await ModelStateException(context, modelState);
            }

            catch(AuthenticationException authenticationException)
            {
                _logger.LogError($"Authentication exception: {authenticationException.Message}");
                await AuthenticationException(context, authenticationException);
            }

            catch (Exception ex)
            {
                _logger.LogError($"UnexpectedError: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }


        private static async Task NotFoundExceptionAsync(HttpContext context, NotFoundException notFoundException)
        {
            context.Response.StatusCode = 404;

            ErrorDTO error = new ErrorDTO
            {
                Type = notFoundException.GetType().Name,
                Message = notFoundException.Message,
                Details = ""
            };

            await ConfigErrorResponse(context, error);
        }


        private static async Task BadRequestExceptionAsync(HttpContext context, BadRequestException badRequestException)
        {
            context.Response.StatusCode = 400;

            ErrorDTO error = new ErrorDTO
            {
                Type = badRequestException.GetType().Name,
                Message = badRequestException.Message,
                Details = ""
            };

            await ConfigErrorResponse(context, error);
        }


        private static async Task ModelStateException(HttpContext context, ModelStateException modelStateException)
        {
            context.Response.StatusCode = 400;

            List<ModelStateErrorsDTO> errors = modelStateException.Errors;

            await ConfigErrorResponse(context, errors);
        }


        private static async Task AuthenticationException(HttpContext context, AuthenticationException authenticationException)
        {
            context.Response.StatusCode = 401;

            ErrorDTO error = new ErrorDTO
            {
                Type = authenticationException.GetType().Name,
                Message = authenticationException.Message,
                Details = ""
            };

            await ConfigErrorResponse(context, error);
        }


        private static async Task DataBaseException(HttpContext context, AuthenticationException dataBaseException)
        {
            context.Response.StatusCode = 500;

            ErrorDTO error = new ErrorDTO
            {
                Type = dataBaseException.GetType().Name,
                Message = dataBaseException.Message,
                Details = dataBaseException.InnerException?.Message ?? ""
            };

            await ConfigErrorResponse(context, error);
        }


        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ErrorDTO error = new ErrorDTO
            {
                Type = exception.GetType().Name,
                Message = "Unexpected Error",
                Details = exception.Message
            };

            await ConfigErrorResponse(context, error);
        }


        private static async Task ConfigErrorResponse<T>(HttpContext context, T error)
        {
            context.Response.ContentType = "application/json";

            ApiResponse<T> response = new ApiResponse<T> {
                StatusCode = context.Response.StatusCode,
                Method = context.Request.Method,
                Path = context.Request.Path,
                Error = error
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}