using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;


public static class StockEndpoints
{
    
    public static void MapStockEndpoints(this IEndpointRouteBuilder routes)
    {
        
        routes.MapGet("/api/stock", async Task<IResult>  (ApplicationDbContext _context) =>
        {
            try
            {
                var stocks = await _context.Stocks.ToListAsync();
                return TypedResults.Ok(stocks);

            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getAllStocks")
        .WithTags("Stocks")
        .Produces<List<Stock>>(StatusCodes.Status200OK);

        routes.MapGet("/api/stock/{id}", async Task<Results<Ok<Stock>, NotFound, ProblemHttpResult>> ([FromRoute] int id, ApplicationDbContext _context) =>
        {
            try
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);

                return stock is not null ? TypedResults.Ok(stock) : TypedResults.NotFound();
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getStock")
        .WithTags("Stocks");

    }
}
