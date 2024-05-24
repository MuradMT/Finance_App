using api.Endpoints.APIResponse;

namespace api.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder app)
    {
        var routes = app.MapGroup("/api/account").WithOpenApi();

        #region  Register User
        routes.MapPost("/register", async Task<IResult> ([FromBody] RegisterDto registerDto, IAccountService _service) =>
        {
            try
            {
                var result = await _service.RegisterAsync(registerDto);
                return TypedResults.Ok(new DataResponse<NewUserDto>(StatusCodes.Status200OK, ConstantMessages.User_Created, result));
            }
            catch (UserExistsException ex)
            {   
                return TypedResults.BadRequest(new Response(StatusCodes.Status400BadRequest, ex.Message));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message, statusCode: 500);
            }
        })
        .WithName("register")
        .WithTags("Account")
        .WithSummary(ConstantMessages.Register)
        .WithRequestValidation<RegisterDto>()
        .Produces<DataResponse<NewUserDto>>(StatusCodes.Status200OK)
        .Produces<Response>(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status500InternalServerError)
        .AllowAnonymous();
        #endregion

        #region Login User
        routes.MapPost("/login", async Task<IResult> ([FromBody] LoginDto loginDto, IAccountService _service) =>
        {
            try
            {
                var result = await _service.LoginAsync(loginDto);
                return TypedResults.Ok(new DataResponse<TokenDto>(StatusCodes.Status200OK, ConstantMessages.Login_Success, result));
            }
            catch (UnauthorizedAccessException ex)
            {
                return TypedResults.Problem(ex.Message, statusCode: 401);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message, statusCode: 500);
            }
        })
        .WithName("login")
        .WithTags("Account")
        .WithSummary(ConstantMessages.Login)
        .WithRequestValidation<LoginDto>()
        .Produces<DataResponse<TokenDto>>(StatusCodes.Status200OK)
        .Produces<Response>(StatusCodes.Status401Unauthorized)
        .Produces(StatusCodes.Status500InternalServerError)
        .AllowAnonymous();
        #endregion
    }
}
