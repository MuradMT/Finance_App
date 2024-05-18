using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;


public static class StockEndpoints
{

    public static void MapStockEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/stock", async (ApplicationDbContext _context) =>
        {
            try
            {
                return Results.Ok(await _context.Stocks.ToListAsync());
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message,statusCode:500);
            }
        })
        .WithName("getAllStocks")
        .WithTags("Stocks")
        .Produces<List<Stock>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError);

        routes.MapGet("/api/stock/{id}", async ([FromRoute] int id, ApplicationDbContext _context) =>
        {
            try
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);

                return stock is not null ? Results.Ok(stock) : Results.NotFound();
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message,statusCode:500);
            }
        })
        .WithName("getStock")
        .WithTags("Stocks")
        .Produces<Stock>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);
    }
}
