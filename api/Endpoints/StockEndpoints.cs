using api.Data;
using api.Dtos.Stock.Request;
using api.Dtos.Stock.Response;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Endpoints;


public static class StockEndpoints
{

    public static void MapStockEndpoints(this IEndpointRouteBuilder routes)
    {

        routes.MapGet("/api/stocks", async Task<IResult> (ApplicationDbContext _context, IMapper _mapper) =>
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
        ApplicationDbContext _context, IMapper _mapper) =>
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

        routes.MapPost("/api/stock/addStock", async Task<IResult> ([FromBody] CreateStockDto stockDto, 
        ApplicationDbContext _context, IMapper _mapper) =>
        {
            try
            {
                var stock = _mapper.Map<Stock>(stockDto);
                _context.Stocks.Add(stock);
                await _context.SaveChangesAsync();
                return TypedResults.CreatedAtRoute(_mapper.Map<StockDto>(stock),"getStock",new {id=stock.Id});
            }
            catch (Exception e)
            {
                return TypedResults.Problem(e.Message, statusCode: 500);
            }
        })
        .WithName("addStock")
        .WithTags("Stocks")
        .Produces<StockDto>(StatusCodes.Status201Created);

    }
}
