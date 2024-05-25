

using Microsoft.AspNetCore.Http.HttpResults;

namespace api.Endpoints;

public static class PortfolioEndpoints
{
     public static void MapPortfolioEndpoints(this IEndpointRouteBuilder app){
         var routes = app.MapGroup("/api/portfolio").WithOpenApi();

         #region Get All Portfolios

         routes.MapGet("",async Task<IResult> (UserManager<AppUser> userManager,IPortfolioRepository _repo,IStockRepository _stockrepo,HttpContext _context)=>{
                var userName=_context.User.GetUserName();
                var user=await userManager.FindByNameAsync(userName);
                var portfolio=await _repo.GetUserPortfolio(user);
                return TypedResults.Ok(portfolio);
         })
         .WithName("getPortfolios")
         .WithTags("Portfolios")
         .WithSummary("Get All Portfolios")
         .RequireAuthorization();
         #endregion
     }
}
