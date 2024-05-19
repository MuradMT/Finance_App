using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api;


public static class StockEndpoints
{
    
    public static void MapStockEndpoints(this IEndpointRouteBuilder routes)
    {
        
        routes.MapGet("/api/stocks", async Task<IResult>  (ApplicationDbContext _context,IMapper _mapper) =>
        {
            try
            {
                var stocks = await _context.Stocks.ToListAsync();
                return TypedResults.Ok(_mapper.Map<List<StockDto>>(stocks));

            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("getAllStocks")
        .WithTags("Stocks")
        .Produces<List<StockDto>>(StatusCodes.Status200OK);

        routes.MapGet("/api/stock/{id}", async Task<Results<Ok<StockDto>, NotFound, ProblemHttpResult>> ([FromRoute] int id, 
        ApplicationDbContext _context,IMapper _mapper) =>
        {
            try
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);

                return stock is not null ? TypedResults.Ok(_mapper.Map<StockDto>(stock)) : TypedResults.NotFound();
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
