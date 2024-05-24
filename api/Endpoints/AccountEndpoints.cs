namespace api.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder app){
        var routes = app.MapGroup("/api/account").WithOpenApi();

        #region  Register User
         routes.MapPost("/register",async Task<IResult> ([FromBody]RegisterDto registerDto,IAccountService _service)=>{
            try{
               var result=await _service.RegisterAsync(registerDto);
               return TypedResults.Ok(new Response(StatusCodes.Status200OK,result));
            }
            catch(UserExistsException ex){
                return TypedResults.BadRequest(new Response(StatusCodes.Status400BadRequest,ex.Message));
            }
            catch(Exception ex){
                return TypedResults.Problem(ex.Message,statusCode:500);
            }
         })
         .WithName("register")
         .WithTags("Account")
         .WithSummary(ConstantMessages.Register)
         .WithRequestValidation<RegisterDto>()
         .Produces<Response>(StatusCodes.Status200OK)
         .Produces<Response>(StatusCodes.Status400BadRequest)
         .Produces(StatusCodes.Status500InternalServerError);
        #endregion
    }
}
