

using Microsoft.AspNetCore.Http.HttpResults;

namespace api.Endpoints;

public static class PortfolioEndpoints
{
     public static void MapPortfolioEndpoints(this IEndpointRouteBuilder app){
         var routes = app.MapGroup("/api/portfolio").WithOpenApi();
         #region Get Portfolio

         routes.MapGet("",async Task<IResult> (UserManager<AppUser> userManager,IPortfolioRepository _repo,IStockRepository _stockrepo,HttpContext _context)=>{
                var userName=_context.User.GetUserName();
                var user=await userManager.FindByNameAsync(userName);
                var portfolio=await _repo.GetUserPortfolio(user);
                return TypedResults.Ok(portfolio);
         })
         .WithName("getPortfolio")
         .WithTags("Portfolio")
         .WithSummary("Get Portfolio")
         .RequireAuthorization();

         #endregion

         #region Create Portfolio
         
         routes.MapPost("",async Task<IResult> (IStockRepository _repo,IPortfolioRepository _portRepo,UserManager<AppUser> userManager,HttpContext _context,string symbol)=>{
                var userName=_context.User.GetUserName();
                var user=await userManager.FindByNameAsync(userName);
                var stock=await _repo.GetStockBySymbolAsync(symbol);

                if (stock is null) return TypedResults.BadRequest("Stock not found");
                var userPortfolio=await _portRepo.GetUserPortfolio(user);

                if(userPortfolio.Any(s=>s.Symbol==symbol)) return TypedResults.BadRequest("Stock already exists in portfolio");

                var portfolioModel=new Portfolio{
                    AppUserId=user.Id,
                    StockId=stock.Id
                };
                await _portRepo.AddAsync(portfolioModel);
                
                if(portfolioModel is null) return TypedResults.BadRequest("Failed to create portfolio");
                //return TypedResults.CreatedAtRoute(new DataResponse<Portfolio>(StatusCodes.Status201Created,Messages<Portfolio>.Create,portfolioModel), "getPortfolio", new { id = portfolioModel.StockId });
                return TypedResults.CreatedAtRoute();
         })     
         .WithName("createPortfolio")
         .WithTags("Portfolios")
         .WithSummary("Create Portfolio")
         .RequireAuthorization();

         #endregion

         #region Delete Portfolio

         routes.MapDelete("{id}",async Task<IResult> (IStockRepository _repo,IPortfolioRepository _portRepo,UserManager<AppUser> userManager,HttpContext _context,string symbol)=>{
                var userName=_context.User.GetUserName();
                var user=await userManager.FindByNameAsync(userName);
                var userPortfolio=await _portRepo.GetUserPortfolio(user);

                var filteredStock=userPortfolio.Where(s=>s.Symbol==symbol).ToList();

                if(filteredStock.Count==1){
                     var model=await _portRepo.DeletePortfolio(user,symbol);
                     await _portRepo.DeleteAsync(model);
                }
                else{
                     return TypedResults.BadRequest("Stock not in your portfolio");
                }

                return TypedResults.Ok();
         })
         .WithName("deletePortfolio")
         .WithTags("Portfolios")
         .WithSummary("Delete Portfolio")
         .RequireAuthorization();

         #endregion
     }
}
